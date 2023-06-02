#include <iostream>
#include "scanner.h"
#include <Windows.h>
#include <chrono>
#include <thread>

typedef const char* (*MY_CONNECT_FUNCTION)();
typedef const char* (*MY_CONNECT_FUNCTION2)(const char*,const char*,const char*,const char*,void (*callback)(const char*));
typedef const char* (*MY_CONNECT_FUNCTION3)(const char*,const char*);
typedef const char* (*MY_CONNECT_FUNCTION4)(const char*,const char*,const char*);

void my_callback(const char* message) {
    std::cout << "Received message: " << message << std::endl;
}

int main() {
    HINSTANCE hinstLib = LoadLibrary(TEXT("E:\\project\\cpp_sdk\\lib\\scanner_windows.dll"));
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
            const char* result = myConnectFunction2("7B:AA:8C:98:10:71","**","**","**",&my_callback);
            std::cout << "connect result: " << result << std::endl;
        }

        std::this_thread::sleep_for(std::chrono::milliseconds(3000));
        MY_CONNECT_FUNCTION3 myConnectFunction3 = (MY_CONNECT_FUNCTION3)GetProcAddress(hinstLib, "get_properties_info_by_key");

        if (myConnectFunction3 != NULL)
        {
            const char* result = myConnectFunction3("7B:AA:8C:98:10:71","lighting_lamp_control");
            std::cout << "get result: " << result << std::endl;
        }

        MY_CONNECT_FUNCTION4 myConnectFunction4 = (MY_CONNECT_FUNCTION4)GetProcAddress(hinstLib, "edit_properties_info_by_key");

        if (myConnectFunction3 != NULL)
        {
            const char* result = myConnectFunction4("7B:AA:8C:98:10:71","GS1-128","1");
            std::cout << "edit result: " << result << std::endl;
        }
    }

    return 0;
}
