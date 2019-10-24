#pragma once

#include <exception>
#include <string>

namespace DunCraw
{
	struct GameSystemException : public std::exception
	{
		GameSystemException(const std::string &system)
			: systemName(system)
		{
		}

		const char *what() const throw() 
		{
			return (systemName + " failed to intialize!").c_str();
		}

	private:
		std::string systemName;
	};
}
