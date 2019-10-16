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
			std::for_each(total.begin(), total.end(), [this](auto &elem) { free.insert(&elem); });
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
			if (Available())
			{
				T *data = *free.begin();
				free.erase(data);
				return *data;
			}

			throw std::exception("No more space in pool!");
		};

		bool Available() const
		{
			return free.size() != 0;
		};

		void Release(T &data)
		{
			free.insert(&data);
		}

	private:
		std::unordered_set<T*> free;
		std::vector<T> total;

	};
}
