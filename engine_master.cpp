#include <iostream>
#include <chrono>
#include <thread>

extern "C" {
    struct EngineMetrics {
        int fps;
        float neonLoad;
        int activeBuffers;
    };

    // Funkcja generująca dynamiczną telemetrię w pętli
    __attribute__((visibility("default")))
    void GetEngineMetrics(EngineMetrics* metrics, int iteration) {
        // Symulacja zmiennego obciążenia procesora i FPS zależnego od iteracji
        metrics->fps = 58 + (iteration % 5);
        metrics->neonLoad = 32.0f + (iteration * 1.5f);
        if (metrics->neonLoad > 85.0f) metrics->neonLoad = 40.0f; // reset pętli obciążenia
        metrics->activeBuffers = 4 + (iteration % 3);
    }
}
