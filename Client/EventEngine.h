#pragma once

#include <stdint.h>
#include <functional>
#include <map>
#include <vector>
#include <queue>

#include "Config.h"

#include "Pool.h"

namespace DunCraw
{
	struct EventData
	{
		int64_t A;
		int64_t B;
		int64_t C;
		void *Extra;

		template<typename T>
		void SetA(T value) { A = static_cast<int64_t>(value); };
		template<typename T>
		void SetB(T value) { B = static_cast<int64_t>(value); };
		template<typename T>
		void SetC(T value) { C = static_cast<int64_t>(value); };

		template<typename T>
		T GetA() const { return static_cast<T>(A); };
		template<typename T>
		T GetB() const { return static_cast<T>(B); };
		template<typename T>
		T GetC() const { return static_cast<T>(C); };
		template<typename T>
		T *GetExtra() const { return reinterpret_cast<T*>(Extra); };
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

		Pool<EventData> eventDataPool;

		int maxEventsPerTick;

		Config &config;

		const int POOL_SIZE;

	};
}
