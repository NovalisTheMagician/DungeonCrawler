#pragma once

typedef int Index;

#include <streambuf>
#include <iostream>
#include <istream>
#include <ostream>

struct MemBuffer : public std::basic_streambuf<char>
{
	MemBuffer(char* s, std::size_t n)
	{
		setg(s, s, s + n);
		setp(s, s + n);
	}
};
