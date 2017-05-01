#include "bridge.h"
#include "emscripten.h"

callback_message_received_from_js message_received_from_js_callback;

void set_callbacks(callback_message_received_from_js callback)
{
	message_received_from_js_callback = callback;
}

void EMSCRIPTEN_KEEPALIVE message_received_from_js(const char* message)
{
	message_received_from_js_callback(message);
}