#pragma once

#include "DunCraw.h"

#include <stdexcept>

namespace DunCraw
{
	template<typename T>
	class Pool
	{
	public:
		struct Element
		{
			T data;
			bool free;
		};

		Pool(size_t numElements) : elements(numElements) { };
		Pool(const Pool<T> &pool) = delete;
		Pool(Pool<T> &&pool) = delete;
		Pool& operator=(const Pool<T> &pool) = delete;
		Pool& operator=(Pool<T> &&pool) = delete;

		Element &Aquire() const
		{
			for (auto it = elements.begin(); it != elements.end(); it++)
			{
				Element& element = *it;
				if (element.free)
				{
					element.free = true;
					return element;
				}
			}

			throw std::exception("No more space in pool!");
		};

		bool Available() const
		{
			for (auto it = elements.begin(); it != elements.end(); it++)
			{
				Element& element = *it;
				if (element.free)
					return true;
			}

			return false;
		};

	private:
		std::vector<Element> elements;

	};
}
