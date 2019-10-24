#pragma once

#include "IAudioEngine.h"

#include "DunCraw.h"

#include <Windows.h>

#include <C:\Program Files (x86)\Microsoft DirectX SDK (June 2010)\Include\comdecl.h>
#include <C:\Program Files (x86)\Microsoft DirectX SDK (June 2010)\Include\xaudio2.h>
#include <C:\Program Files (x86)\Microsoft DirectX SDK (June 2010)\Include\xaudio2fx.h>
#include <C:\Program Files (x86)\Microsoft DirectX SDK (June 2010)\Include\xapofx.h>
#pragma warning(push)
#pragma warning(disable : 4005)
#include <C:\Program Files (x86)\Microsoft DirectX SDK (June 2010)\Include\x3daudio.h>
#pragma warning(pop)
#pragma comment(lib,"x3daudio.lib")
#pragma comment(lib,"xapofx.lib")

#include <wrl.h>

namespace DunCraw
{
	class DXAudioEngine : public IAudioEngine
	{
	public:
		DXAudioEngine(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator);
		~DXAudioEngine();
		DXAudioEngine(const DXAudioEngine &ae) = delete;
		DXAudioEngine& operator=(const DXAudioEngine &ae) = delete;

		bool LoadSound(const std::byte *data, size_t size, const Index &index) override;
		void UnloadSound(const Index &index) override;

	private:
		void OnPlaySound(EventData &data);

	private:
		struct WaveData
		{
			WAVEFORMATEXTENSIBLE format;
			std::byte *buffer;
			size_t size;
		};

		struct Channel;

		class VoiceCallback : public IXAudio2VoiceCallback
		{
		public:
			VoiceCallback() : channel(nullptr) {};
			~VoiceCallback() {};

			void SetChannel(Channel *channel)
			{
				this->channel = channel;
			}

			void __stdcall OnStreamEnd() override
			{
				channel->free = true;
			};

			void __stdcall OnVoiceProcessingPassEnd() override { }
			void __stdcall OnVoiceProcessingPassStart(uint32_t samplesRequired) override { }
			void __stdcall OnBufferEnd(void *bufferContext) override { }
			void __stdcall OnBufferStart(void *bufferContext) override { }
			void __stdcall OnLoopEnd(void *bufferContext) override { }
			void __stdcall OnVoiceError(void *bufferContext, HRESULT Error) override { }

		private:
			Channel *channel;

		};

		struct Channel
		{
			IXAudio2SourceVoice *voice;
			bool free;
			VoiceCallback callback;
		};

	private:
		Microsoft::WRL::ComPtr<IXAudio2> xaudio;
		IXAudio2MasteringVoice *masteringVoice;
		IXAudio2SubmixVoice *soundVoice;
		IXAudio2SubmixVoice *musicVoice;
		IXAudio2SubmixVoice *speechVoice;

		std::vector<Channel> channels;

		std::map<Index, WaveData> sounds;

		Config &config;
		EventEngine &eventEngine;
		const SystemLocator &systems;
	};
}
