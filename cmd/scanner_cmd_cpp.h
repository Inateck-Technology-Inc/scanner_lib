#include <cstdarg>
#include <cstdint>
#include <cstdlib>
#include <ostream>
#include <new>

extern "C" {

const char *inateck_scanner_cmd_notify_data_result(const uint8_t *data, uintptr_t length);

const char *inateck_scanner_cmd_auth();

int inateck_scanner_cmd_check_auth_result(const uint8_t *data, uintptr_t length);

const char *inateck_scanner_cmd_software_version();

const char *inateck_scanner_cmd_software_result(const uint8_t *data, uintptr_t length);

const char *inateck_scanner_cmd_set_bee(uint8_t voice_time, uint8_t silent_time, uint8_t count);

uint8_t inateck_scanner_cmd_check_result(const uint8_t *data, uintptr_t length);

const char *inateck_scanner_cmd_set_led(uint8_t color,
                                        uint8_t light_time,
                                        uint8_t dark_time,
                                        uint8_t count);

const char *inateck_scanner_cmd_set_name(const char *name);

const char *inateck_scanner_cmd_set_time(long time);

const char *inateck_scanner_cmd_get_settings();

const char *inateck_scanner_cmd_get_settings_result(int device_type,
                                                    const uint8_t *data,
                                                    uintptr_t data_length);

const char *inateck_scanner_cmd_set_settings(int device_type,
                                             const uint8_t *read_data,
                                             uintptr_t read_data_length,
                                             const char *cmd);

const char *inateck_scanner_cmd_open_all_code();

const char *inateck_scanner_cmd_close_all_code();

const char *inateck_scanner_cmd_reset_all_code();

const char *inateck_scanner_cmd_get_prefix();

const char *inateck_scanner_cmd_set_prefix(const uint8_t *data, uintptr_t length);

const char *inateck_scanner_cmd_get_suffix();

const char *inateck_scanner_cmd_set_suffix(const uint8_t *data, uintptr_t length);

const char *inateck_scanner_cmd_get_affix_result(const uint8_t *data, uintptr_t length);

const char *inateck_scanner_cmd_get_reset();

const char *inateck_scanner_cmd_get_restart();

const char *inateck_scanner_cmd_get_inventory_upload_cache();

const char *inateck_scanner_cmd_get_inventory_upload_count();

const char *inateck_scanner_cmd_get_inventory_clear_cache();

const char *inateck_scanner_cmd_get_mac();

const char *inateck_scanner_cmd_get_mac_result(const uint8_t *data, uintptr_t data_length);

const char *inateck_scanner_cmd_get_version();

} // extern "C"
