#include <Windows.h>
#include <iostream>

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPWSTR lpCmdLine, int nCmdShow)
{
	MessageBox(nullptr, L"Hello World!", L"", MB_OK);
	return 0;
}
