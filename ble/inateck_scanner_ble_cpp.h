#include <cstdarg>
#include <cstdint>
#include <cstdlib>
#include <ostream>
#include <new>

extern "C" {

const char *inateck_scanner_ble_init();

const char *inateck_scanner_ble_set_discover_callback(void (*callback)(const char*));

const char *inateck_scanner_ble_wait_available();

const char *inateck_scanner_ble_start_discover();

const char *inateck_scanner_ble_stop_discover();

const char *inateck_scanner_ble_get_devices();

const char *inateck_scanner_ble_connect(const char *device_id);

const char *inateck_scanner_ble_check_communication(const char *device_id);

const char *inateck_scanner_ble_auth(const char *device_id);

const char *inateck_scanner_ble_set_code_callback(const char *device_id,
                                                  void (*callback)(const char*));

const char *inateck_scanner_ble_set_disconnect_callback(const char *device_id,
                                                        void (*callback)(const char*));

const char *inateck_scanner_ble_disconnect(const char *device_id);

const char *inateck_scanner_ble_get_battery(const char *device_id);

const char *inateck_scanner_ble_get_hardware_version(const char *device_id);

const char *inateck_scanner_ble_bee_or_shake(const char *device_id);

const char *inateck_scanner_set_bee(const char *device_id,
                                    uint8_t voice_time,
                                    uint8_t silent_time,
                                    uint8_t count);

const char *inateck_scanner_set_led(const char *device_id,
                                    uint8_t color,
                                    uint8_t light_time,
                                    uint8_t dark_time,
                                    uint8_t count);

const char *inateck_scanner_ble_get_software_version(const char *device_id);

const char *inateck_scanner_ble_get_mac(const char *device_id);

const char *inateck_scanner_ble_get_setting_info(const char *device_id, int device_type);

const char *inateck_scanner_ble_set_setting_info(const char *device_id,
                                                 const char *cmd,
                                                 int device_type);

const char *inateck_scanner_ble_set_name(const char *device_id, const char *name);

const char *inateck_scanner_ble_set_time(const char *device_id, long time);

const char *inateck_scanner_ble_inventory_clear_cache(const char *device_id);

const char *inateck_scanner_ble_inventory_upload_cache(const char *device_id);

const char *inateck_scanner_ble_inventory_upload_cache_number(const char *device_id);

const char *inateck_scanner_ble_reset(const char *device_id);

const char *inateck_scanner_ble_restart(const char *device_id);

const char *inateck_scanner_ble_close_all_code(const char *device_id);

const char *inateck_scanner_ble_open_all_code(const char *device_id);

const char *inateck_scanner_ble_reset_all_code(const char *device_id);

const char *inateck_scanner_ble_get_prefix(const char *device_id);

const char *inateck_scanner_ble_set_prefix(const char *device_id,
                                           const uint8_t *prefix,
                                           uintptr_t prefix_len);

const char *inateck_scanner_ble_get_suffix(const char *device_id);

const char *inateck_scanner_ble_set_suffix(const char *device_id,
                                           const uint8_t *suffix,
                                           uintptr_t suffix_len);

const char *inateck_scanner_ble_sdk_version();

int inateck_scanner_ble_set_debug(int is_debug);

} // extern "C"
