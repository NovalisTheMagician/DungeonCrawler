#include "DXAudioEngine.h"

using Microsoft::WRL::ComPtr;

namespace DunCraw
{
	DXAudioEngine::DXAudioEngine(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator)
		: config(config), eventEngine(eventEngine), initiallized(false), systems(systemLocator)
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

		CoInitialize(nullptr);

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

		initiallized = true;
		return true;
	}

	void DXAudioEngine::Destroy()
	{
		if (!initiallized)
			return;

		xaudio.Reset();
	}
}
