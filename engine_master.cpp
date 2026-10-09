#include <cstdint>

struct EngineMetrics {
    float currentFps;
    float neonLoadPercent;
    uint32_t activeBuffersCount;
    bool zeroCopyActive;
};

#ifdef __cplusplus
extern "C" {
#endif

__attribute__((visibility("default"))) 
void GetEngineTelemetry(EngineMetrics* outMetrics) {
    if (outMetrics == nullptr) return;
    outMetrics->currentFps = 60.0f;
    outMetrics->neonLoadPercent = 35.5f;
    outMetrics->activeBuffersCount = 4;
    outMetrics->zeroCopyActive = true;
}

#ifdef __cplusplus
}
#endif
