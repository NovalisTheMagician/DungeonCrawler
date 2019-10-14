#pragma once

#include "DunCraw.h"

#include <stdexcept>

namespace DunCraw
{
	template<typename T>
	class Pool
	{
	public:
		Pool(size_t numElements) : total(numElements) 
		{
			//std::for_each(total.begin(), total.end(), [this](auto elem) { free.push_back(&elem); });
			for (auto it = total.begin(); it != total.end(); it++)
			{
				free.push_back(&(*it));
			}
		};

		~Pool()
		{
			total.clear();
		}

		Pool(const Pool<T> &pool) = delete;
		Pool(Pool<T> &&pool) = delete;
		Pool& operator=(const Pool<T> &pool) = delete;
		Pool& operator=(Pool<T> &&pool) = delete;

		T &Aquire()
		{
			aqCnt++;
			if (Available())
			{
				T &data = *(free.back());
				free.pop_back();
				return data;
			}

			throw std::exception("No more space in pool!");
		};

		bool Available() const
		{
			return free.size() != 0;
		};

		void Release(T &data)
		{
			relCnt++;
			free.push_back(&data);
			/*
			for (auto it = total.begin(); it != total.end(); it++)
			{
				if (&data == &(*it))
				{
					free.push_back(&data);
				}
			}
			*/
		}

	private:
		std::vector<T*> free;
		std::vector<T> total;

		int aqCnt, relCnt;

	};
}
