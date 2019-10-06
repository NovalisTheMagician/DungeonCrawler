#pragma once

#include <stdint.h>
#include <functional>
#include <map>
#include <vector>
#include <queue>

#include "Config.h"

namespace DunCraw
{
	struct EventData
	{
		int64_t A;
		int64_t B;
		int64_t C;
		void *Extra;
	};

	enum EventType
	{
		//window/renderer stuff
		EV_RESIZE,
		EV_WINDOWCHANGE,
		EV_SHOWCURSOR,
		EV_EXIT,

		//input stuff
		EV_KEYDOWN,
		EV_KEYUP,
		EV_MOUSEMOVEABS,
		EV_MOUSEMOVEREL,
		EV_MOUSEWHEEL,
		EV_MOUSEDOWN,
		EV_MOUSEUP,
		EV_CHAR,

		//audio stuff
		EV_PLAYSOUND,
		EV_STOPSOUND,
		EV_PLAYMUSIC,
		EV_STOPMUSIC,

		//scripting stuff


		//gameplay stuff


		//physics stuff


		//custom event start id
		EV_CUSTOM
	};

	typedef std::function<void(EventData)> CallbackFun;

	class EventEngine
	{
	public:
		EventEngine(Config &config);
		~EventEngine();
		EventEngine(const EventEngine &ee) = delete;
		EventEngine& operator=(const EventEngine &ee) = delete;

		void RegisterCallback(EventType eventName, CallbackFun callbackFunction);

		void SendEvent(EventType, EventData data, bool immediatly = false);

		void ProcessQueue();

	private:
		std::map<EventType, std::vector<CallbackFun>> eventCallbacks;
		std::queue<std::pair<EventType, EventData>> eventQueue;

		int maxEventsPerTick;

		Config &config;

	};
}
