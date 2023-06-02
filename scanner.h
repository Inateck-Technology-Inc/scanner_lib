#include <cstdarg>
#include <cstdint>
#include <cstdlib>
#include <ostream>
#include <new>

extern "C" {

const char *scan();

const char *_connect(const char *device_id,
                    const char *app_id,
                    const char *developer_id,
                    const char *app_key,
                    void (*callback)(const char*));

const char *disconnect(const char *device_id);

const char *get_basic_properties(const char *device_id, const char *property_key);

const char *get_properties_info_by_key(const char *device_id, const char *property_key);

const char *edit_properties_info_by_key(const char *device_id,
                                        const char *property_key,
                                        const char *data);

const char *get_all_barcode_properties(const char *device_id);

const char *get_basic_device_info(const char *device_id);

} // extern "C"
