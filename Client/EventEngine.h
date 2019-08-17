#pragma once

#include <functional>
#include <map>
#include <vector>
#include <queue>

#include "Config.h"

namespace DunCraw
{
	struct EventData
	{
		int A;
		int B;
		int C;
		void *Extra;
	};

	enum LoadResourceType
	{
		RT_TEXTURE,
		RT_SOUND,
		RT_MODEL,
		RT_TEXT,
		RT_LAYOUT,
		RT_SCRIPT,
		RT_CUSTOM
	};

	enum EventType
	{
		//window/renderer stuff
		EV_RESIZE,
		EV_EXIT,

		//input stuff
		EV_KEYDOWN,
		EV_KEYUP,
		EV_MOUSEMOVE,
		EV_MOUSEWHEEL,
		EV_CHAR,

		//audio stuff
		EV_PLAYSOUND,
		EV_STOPSOUND,
		EV_PLAYMUSIC,
		EV_STOPMUSIC,

		//resource stuff
		EV_LOADRESOURCE,

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
