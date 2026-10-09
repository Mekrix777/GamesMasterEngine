using System;
using System.Threading.Tasks;
using GamesMasterEngine.Services;

namespace GamesMasterEngine
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("   GAMES MASTER ENGINE - INICJALIZACJA SYSTEMU   ");
            Console.WriteLine("==================================================");

            // Pobranie parametrów z natywnej biblioteki C++
            var metrics = EngineBridge.FetchTelemetry();
            Console.WriteLine($"[C++ CORE] Telemetria odebrana:");
            Console.WriteLine($"           - FPS: {metrics.CurrentFps}");
            Console.WriteLine($"           - Obciążenie NEON: {metrics.NeonLoadPercent}%");
            Console.WriteLine($"           - Aktywne bufory: {metrics.ActiveBuffersCount}");

            // Przekazanie danych do pamięci webowej
            await MemorySyncService.SendToWebMemoryAsync(metrics);

            Console.WriteLine("==================================================");
            Console.WriteLine("       PROCES DANE (#JestMoje) ZAKOŃCZONY         ");
            Console.WriteLine("==================================================");
        }
    }
}
