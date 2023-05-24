#include <iostream>
#include "scanner.h"
#include <Windows.h>


typedef const char* (*MY_CONNECT_FUNCTION)();
typedef const char* (*MY_CONNECT_FUNCTION2)(const char*,const char*,const char*,const char*);

int main() {
    HINSTANCE hinstLib = LoadLibrary(TEXT("E:\\project\\cpp_sdk\\lib\\scanner_c_abi.dll"));
    if (hinstLib != NULL)
    {
        MY_CONNECT_FUNCTION myConnectFunction = (MY_CONNECT_FUNCTION)GetProcAddress(hinstLib, "scan");

        if (myConnectFunction != NULL)
        {
            const char* result = myConnectFunction();
            std::cout << "scan result: " << result << std::endl;
        }


        MY_CONNECT_FUNCTION2 myConnectFunction2 = (MY_CONNECT_FUNCTION2)GetProcAddress(hinstLib, "connect");

        if (myConnectFunction2 != NULL)
        {
            const char* result = myConnectFunction2("**","**","**","**");
            std::cout << "connect result: " << result << std::endl;
        }
    }

    return 0;
}
