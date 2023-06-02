#include <iostream>
#include "scanner.h"
#include <dlfcn.h>


typedef const char* (*MY_CONNECT_FUNCTION)();
typedef const char* (*MY_CONNECT_FUNCTION2)(const char*,const char*,const char*,const char*,void (*callback)(const char*));
void my_callback(const char* message) {
    std::cout << "Received message: " << message << std::endl;
}

int main() {
    void* hinstLib = dlopen("./lib/scanner_macos.dylib",RTLD_LAZY);
    if (hinstLib != NULL)
    {
        MY_CONNECT_FUNCTION myConnectFunction = (MY_CONNECT_FUNCTION)dlsym(hinstLib, "scan");
        if (myConnectFunction != NULL)
        {
            const char* result = myConnectFunction();
            std::cout << "scan result: " << result << std::endl;
        }
        MY_CONNECT_FUNCTION2 myConnectFunction2 = (MY_CONNECT_FUNCTION2)dlsym(hinstLib, "connect");

        if (myConnectFunction2 != NULL)
        {
            const char* result = myConnectFunction2("**","**","**","**",&my_callback);
            std::cout << "connect result: " << result << std::endl;
        }
    }
    return 0;
}
