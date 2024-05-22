cmake_minimum_required(VERSION 3.24)

project(cpp_sdk)

add_library(scannerBle SHARED IMPORTED )
set_target_properties( scannerBle PROPERTIES IMPORTED_LOCATION ${PROJECT_SOURCE_DIR}/lib/libscanner_ble_x86_64-apple-darwin.dylib )

add_executable(cpp_sdk main.cpp)

target_link_libraries(cpp_sdk scannerBle)
target_include_directories(cpp_sdk PUBLIC ${PROJECT_SOURCE_DIR}/include)
