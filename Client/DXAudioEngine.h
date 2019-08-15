#pragma once

#include "IAudioEngine.h"

#include "Config.h"

#include "EventEngine.h"

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
		DXAudioEngine(Config &config, EventEngine &eventEngine);
		~DXAudioEngine();
		DXAudioEngine(const DXAudioEngine &ae) = delete;
		DXAudioEngine& operator=(const DXAudioEngine &ae) = delete;

		bool Init() override;
		void Destroy() override;

	private:
		Microsoft::WRL::ComPtr<IXAudio2> xaudio;
		IXAudio2MasteringVoice *masteringVoice;
		IXAudio2SubmixVoice *soundVoice;
		IXAudio2SubmixVoice *musicVoice;
		IXAudio2SubmixVoice *speechVoice;

		bool initiallized;

		Config &config;
		EventEngine &eventEngine;

	};
}
