#include <iostream>
#include "inateck_scanner_ble_cpp.h"
#include <sstream>
#include <vector>

std::vector<std::string> split(const std::string &s, char delimiter) {
    std::vector<std::string> tokens;
    std::string token;
    std::istringstream tokenStream(s);
    while (std::getline(tokenStream, token, delimiter)) {
        tokens.push_back(token);
    }
    return tokens;
}

void scan_callback(const char *msg) {
    std::cout << msg << std::endl;
    return;
}

void connect_callback(const char *msg) {
    std::cout << msg << std::endl;
    return;
}

int main(int argc, char const *argv[])
{
    int status = inateck_scanner_ble_init(scan_callback);
    if (status != 0) {
        std::cout << "init failed: " << status << std::endl;
        return 1;
    }
    std::cout << "init success" << std::endl;
    std::cout << "you can input command: > scan, > stop, > devices, > connect, > disconnect, > version, > battery, > software, > settingInfo, > closeVolume, > openVolume, > destroy" << std::endl;
    while (true) {
        std::string input_str;
        std::getline(std::cin, input_str);
        std::cout << "input_str: " << input_str << std::endl;
        std::vector<std::string> words = split(input_str, ' ');
        std::string start = words[0];
        if (start != ">") {
            std::cout << "Invalid command, example: > scan" << std::endl;
            continue;
        }
        std::string method = words[1];
        if (method == "") {
            std::cout << "Invalid command, example: > scan" << std::endl;
            continue;
        }
        if (method == "scan") {
            status = inateck_scanner_ble_start_scan();
            std::cout << "status: " << status << std::endl;
        } else if (method == "stop") {
            status = inateck_scanner_ble_stop_scan();
            std::cout << "status: " << status << std::endl;
        } else if (method == "devices") {
            const char *devices = inateck_scanner_ble_get_devices();
            std::cout << "devices: " << devices << std::endl;
        } else if (method == "connect") {
            std::string mac = words[2];
            const char *device = inateck_scanner_ble_connect(mac.c_str(), connect_callback);
            inateck_scanner_ble_auth(mac.c_str());
            std::cout << "device: " << device << std::endl;
        } else if (method == "disconnect") {
            std::string mac = words[2];
            int device = inateck_scanner_ble_disconnect(mac.c_str());
            std::cout << "device: " << device << std::endl;
        } else if (method == "version") {
            std::string mac = words[2];
            const char *version = inateck_scanner_ble_get_hardware_version(mac.c_str());
            std::cout << "version: " << version << std::endl;
        } else if (method == "battery") {
            std::string mac = words[2];
            const char *battery = inateck_scanner_ble_get_battery(mac.c_str());
            std::cout << "battery: " << battery << std::endl;
        } else if (method == "software") {
            std::string mac = words[2];
            const char *software = inateck_scanner_ble_get_software_version(mac.c_str());
            std::cout << "software: " << software << std::endl;
        } else if (method == "settingInfo") {
            std::string mac = words[2];
            const char *settingInfo = inateck_scanner_ble_get_setting_info(mac.c_str());
            std::cout << "settingInfo: " << settingInfo << std::endl;
        } else if (method == "closeVolume") {
            std::string mac = words[2];
            const char *closeVolume = "[{\"area\":\"3\",\"value\":\"0\",\"name\":\"volume\"}]";
            const char *settingInfo = inateck_scanner_ble_set_setting_info(mac.c_str(), closeVolume);
            std::cout << "settingInfo: " << settingInfo << std::endl;
        } else if (method == "openVolume") {
            std::string mac = words[2];
            const char *openVolume = "[{\"area\":\"3\",\"value\":\"4\",\"name\":\"volume\"}]";
            const char *settingInfo = inateck_scanner_ble_set_setting_info(mac.c_str(), openVolume);
            std::cout << "settingInfo: " << settingInfo << std::endl;
        } else if (method == "destroy") {
            inateck_scanner_ble_destroy();
        } else {
            std::cout << "Invalid command, example: > scan" << std::endl;
        }
    }
    return 0;
}
