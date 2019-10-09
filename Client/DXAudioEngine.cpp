#include "DXAudioEngine.h"

#include <istream>
#include <sstream>

using std::placeholders::_1;
using std::istream;
using Microsoft::WRL::ComPtr;

#define fourccRIFF 'FFIR'
#define fourccDATA 'atad'
#define fourccFMT ' tmf'
#define fourccWAVE 'EVAW'
#define fourccXWMA 'AMWX'
#define fourccDPDS 'sdpd'

namespace DunCraw
{
	DXAudioEngine::DXAudioEngine(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator)
		: config(config), eventEngine(eventEngine), initialized(false), systems(systemLocator),
			sounds(), channels(), masteringVoice(), musicVoice(), soundVoice(), speechVoice()
	{
	}

	DXAudioEngine::~DXAudioEngine()
	{
		Destroy();
	}

	bool DXAudioEngine::Init()
	{
		UINT flags = 0;
#ifdef _DEBUG
		flags |= XAUDIO2_DEBUG_ENGINE;
#endif

		(void)CoInitialize(nullptr);

		if (FAILED(XAudio2Create(&xaudio, flags, XAUDIO2_DEFAULT_PROCESSOR)))
		{
			Log::Error("Failed to initialized XAudio2!");
			return false;
		}

		if (FAILED(xaudio->CreateMasteringVoice(&masteringVoice)))
		{
			Log::Error("Failed to create the mastering voice!");
			return false;
		}

		if (FAILED(xaudio->CreateSubmixVoice(&soundVoice, 1, 44100)))
		{
			Log::Error("Failed to create the sound submixvoice!");
			return false;
		}

		if (FAILED(xaudio->CreateSubmixVoice(&musicVoice, 1, 44100)))
		{
			Log::Error("Failed to create the music submixvoice!");
			return false;
		}

		if (FAILED(xaudio->CreateSubmixVoice(&speechVoice, 1, 44100)))
		{
			Log::Error("Failed to create the speech submixvoice!");
			return false;
		}

		//TODO check volume range [0, 100]

		float masterVol = config.GetInt("s_mastervol", 100) / 100.0f;
		float soundVol = config.GetInt("s_soundvol", 100) / 100.0f;
		float speechVol = config.GetInt("s_speechvol", 100) / 100.0f;
		float musicVol = config.GetInt("s_musicvol", 100) / 100.0f;

		masteringVoice->SetVolume(masterVol);
		soundVoice->SetVolume(soundVol);
		speechVoice->SetVolume(speechVol);
		musicVoice->SetVolume(musicVol);

		int numChannels = config.GetInt("s_channels", 16);
		channels.resize(numChannels);
		for (auto it = channels.begin(); it != channels.end(); it++)
		{
			it->free = true;
			it->callback.SetChannel(&*it);
		}

		eventEngine.RegisterCallback(EV_PLAYSOUND, std::bind(&DXAudioEngine::OnPlaySound, this, _1));

		initialized = true;
		return true;
	}

	void DXAudioEngine::Destroy()
	{
		if (!initialized)
			return;

		for (auto it = channels.begin(); it != channels.end(); it++)
		{
			IXAudio2SourceVoice *voice = (*it).voice;
			if (voice)
			{
				voice->DestroyVoice();
			}
		}

		for (auto it = sounds.begin(); it != sounds.end(); it++)
		{
			delete[] (*it).second.buffer;
		}

		speechVoice->DestroyVoice();
		musicVoice->DestroyVoice();
		soundVoice->DestroyVoice();
		masteringVoice->DestroyVoice();
		xaudio.Reset();

		initialized = false;
	}

	static bool FindChunk(istream &dataStream, DWORD fourcc, size_t &chunkSize, size_t &chunkDataPosition)
	{
		dataStream.seekg(0, istream::beg);

		DWORD chunkType;
		DWORD chunkDataSize;
		DWORD riffDataSize = 0;
		DWORD bytesRead = 0;
		DWORD offset = 0;
		DWORD fileType;

		while (dataStream)
		{
			dataStream.read(reinterpret_cast<char*>(&chunkType), sizeof chunkType);
			dataStream.read(reinterpret_cast<char*>(&chunkDataSize), sizeof chunkDataSize);

			switch (chunkType)
			{
			case fourccRIFF:
				riffDataSize = chunkDataSize;
				chunkDataSize = 4;
				dataStream.read(reinterpret_cast<char*>(&fileType), sizeof fileType);
				break;
			default:
				dataStream.seekg(chunkDataSize, istream::cur);
			}

			offset += sizeof(DWORD) * 2;

			if (chunkType == fourcc)
			{
				chunkSize = static_cast<size_t>(chunkDataSize);
				chunkDataPosition = static_cast<size_t>(offset);
				return true;
			}

			offset += chunkDataSize;
		}

		return false;
	}

	static void ReadChunkData(istream &dataStream, void *buffer, size_t bufferSize, size_t bufferOffset)
	{
		dataStream.seekg(bufferOffset, istream::beg);
		dataStream.read(reinterpret_cast<char*>(buffer), bufferSize);
	}

	bool DXAudioEngine::LoadSound(const std::byte *data, size_t size, const Index &index)
	{
		std::byte *d = const_cast<std::byte*>(data);

		std::string str(reinterpret_cast<char*>(d), size);
		std::istringstream stream(str);

		size_t chunkSize;
		size_t chunkPosition;

		if (!FindChunk(stream, fourccRIFF, chunkSize, chunkPosition))
		{
			return false;
		}
		DWORD fileType;
		ReadChunkData(stream, &fileType, sizeof fileType, chunkPosition);
		if (fileType != fourccWAVE)
		{
			return false;
		}

		if (!FindChunk(stream, fourccFMT, chunkSize, chunkPosition))
		{
			return false;
		}
		WAVEFORMATEXTENSIBLE wfx = {0};
		ReadChunkData(stream, &wfx, chunkSize, chunkPosition);

		if (!FindChunk(stream, fourccDATA, chunkSize, chunkPosition))
		{
			return false;
		}
		std::byte *waveData = new std::byte[chunkSize];
		ReadChunkData(stream, waveData, chunkSize, chunkPosition);

		WaveData wave = { 0 };
		wave.buffer = waveData;
		wave.format = wfx;
		wave.size = chunkSize;

		sounds[index] = wave;

		return true;
	}

	void DXAudioEngine::UnloadSound(const Index &index)
	{
		if (sounds.count(index) > 0)
		{
			const WaveData &data = sounds[index];
			delete[] data.buffer;
			sounds.erase(index);
		}
	}

	void DXAudioEngine::OnPlaySound(EventData data)
	{
		Index index = data.GetA<Index>();
		int voiceType = data.GetB<int>();

		if (sounds.count(index) == 0)
		{
			//something is wrong
			return;
		}

		XAUDIO2_SEND_DESCRIPTOR xSendDesc = { 0, soundVoice };
		XAUDIO2_VOICE_SENDS xVoiceSends = { 1, &xSendDesc };

		WaveData &waveData = sounds.at(index);
		XAUDIO2_BUFFER xbuffer = { 0 };
		xbuffer.AudioBytes = static_cast<uint32_t>(waveData.size);
		xbuffer.pAudioData = reinterpret_cast<uint8_t*>(waveData.buffer);
		xbuffer.Flags = XAUDIO2_END_OF_STREAM;

		for (auto it = channels.begin(); it != channels.end(); it++)
		{
			Channel &channel = *it;
			int id = static_cast<int>(it - channels.begin());
			if (channel.free)
			{
				channel.free = false;
				if (channel.voice)
					channel.voice->DestroyVoice();
				xaudio->CreateSourceVoice(&channel.voice, reinterpret_cast<WAVEFORMATEX*>(&waveData.format), 0, XAUDIO2_DEFAULT_FREQ_RATIO, &channel.callback, &xVoiceSends, nullptr);
				channel.voice->SubmitSourceBuffer(&xbuffer);
				channel.voice->Start(0);
				break;
			}
		}

		switch (voiceType)
		{
		case 0:
			break;
		case 1:
			break;
		case 2:
			break;
		}
	}
}
