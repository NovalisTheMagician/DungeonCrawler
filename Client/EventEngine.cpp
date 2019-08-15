#include "EventEngine.h"

#include "Log.h"

using std::vector;
using std::map;
using std::queue;
using std::pair;

namespace DunCraw
{
	EventEngine::EventEngine(Config &config)
		: config(config)
	{
		maxEventsPerTick = config.GetInt("ev_maxevpertick", 50);
		Log::Info("Using " + std::to_string(maxEventsPerTick) + " events per tick");
	}

	EventEngine::~EventEngine()
	{

	}

	void EventEngine::RegisterCallback(EventType eventName, CallbackFun callbackFunction)
	{
		vector<CallbackFun> &callbackFunctions = eventCallbacks[eventName];
		callbackFunctions.push_back(callbackFunction);
	}

	void EventEngine::SendEvent(EventType eventName, EventData data, bool immediatly)
	{
		if (eventCallbacks.count(eventName) == 0)
			return;

		if (immediatly)
		{
			const vector<CallbackFun> &functions = eventCallbacks[eventName];
			for (CallbackFun function : functions)
			{
				function(data);
			}
		}
		else
		{
			eventQueue.push(std::make_pair(eventName, data));
		}
	}

	void EventEngine::ProcessQueue()
	{
		for (int i = 0; i < maxEventsPerTick; ++i)
		{
			if (eventQueue.empty())
				break;

			const pair<EventType, EventData> &event = eventQueue.front();
			EventType eventName = event.first;
			EventData data = event.second;
			SendEvent(eventName, data, true);
			eventQueue.pop();
		}
	}
}
