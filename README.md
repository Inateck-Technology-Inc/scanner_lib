# [Inateck Scanner SDK](https://docs.inateck.com/scanner-sdk-en/)

The Inateck Scanner Software Development Kit (SDK) provides the perfect solution for integrating our scanners into your company's applications and systems. It can seamlessly capture data and control scanner functions. By using the Inateck SDK, applications can efficiently collect data and utilize it within the application to improve operational efficiency and your company's productivity.

## Supported Platforms

| OS | Support |
| ------- | ------- |
| iOS | &#x2705; |
| Android | &#x2705; |
| Windows | &#x2705; |
| Linux | &#x2705; |
| Mac | &#x2705; |

## Supported Architectures
The supported architectures are as follows, and you can find the corresponding library files [here](https://github.com/Inateck-Technology-Inc/scanner_lib).

| Architecture | Support |
| ------- | ------- |
| aarch64-apple-ios | &#x2705; |
| aarch64-linux-android | &#x2705; |
| x86_64-apple-darwin | &#x2705; |
| aarch64-apple-darwin  | &#x2705; |
| x86_64-pc-windows-msvc | &#x2705; |
| i686-pc-windows-msvc | &#x2705; |
| x86_64-unknown-linux-gnu | &#x2705; |
| i686-unknown-linux-gnu | &#x2705; |
| armv7-unknown-linux-gnueabihf | &#x2705; |
| aarch64-unknown-linux-gnu | &#x2705; |

## SDK
### [Bluetooth Library (with Bluetooth functionality)](https://docs.inateck.com/scanner-sdk-en/ble/desktop/)
This library includes Bluetooth search, connection, data transmission, and other functions. Users can use this library to communicate with devices.

### [Parsing Library (without Bluetooth functionality)](https://docs.inateck.com/scanner-sdk-en/cmd/desktop/)
This library includes functions for parsing data returned by devices. Users can use this library to parse data returned by devices. Users need to implement Bluetooth search, connection, data transmission, and other functions themselves.

## Supported Devices

| Device Model | Firmware Upgrade Required | Ready to Use |
| ------- | ------- | ------- |
| BCST-73 | SN 2K to before 3C29 | SN 3C29 and later |
| BCST-42 | SN 3B09 to before 3D11 | SN 3D11 and later |
| BCST-91 | No upgrade required | All versions |
| BCST-21 | No upgrade required | All versions |
| Pro 8 | No upgrade required | All versions |
| BCST-23 | No upgrade required | All versions |
| BCST-75 | No upgrade required | All versions |

For devices that require a **firmware upgrade** before using our SDK and APP, please email [support@inateck.com](mailto:support@inateck.com) to contact our customer service for the upgrade software.
