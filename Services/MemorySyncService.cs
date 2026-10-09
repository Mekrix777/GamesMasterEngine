using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GamesMasterEngine.Services
{
    public static class MemorySyncService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly string WebApiUrl = "https://twoja-strona-internetowa.pl/api/memory/sync";

        public static async Task SendToWebMemoryAsync(EngineBridge.EngineMetrics metrics)
        {
            try
            {
                string jsonPayload = JsonSerializer.Serialize(new
                {
                    Identifier = "#WszystkoTwoje",
                    SystemTag = "#JestMoje",
                    Fps = metrics.CurrentFps,
                    NeonLoad = metrics.NeonLoadPercent,
                    ActiveBuffers = metrics.ActiveBuffersCount,
                    Timestamp = DateTime.UtcNow
                });

                var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");
                Console.WriteLine($"[PAMIĘĆ WEB] Wysyłanie pakietu danych na serwer...");

                // Do celów testowych wysyłka jest zabezpieczona wyłapywaniem błędów sieciowych
                HttpResponseMessage response = await _httpClient.PostAsync(WebApiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("[PAMIĘĆ WEB] Synchronizacja zakończona sukcesem.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PAMIĘĆ WEB] Informacja: Gotowy pakiet JSON (#WszystkoTwoje) przetestowany. Błąd sieci: {ex.Message}");
            }
        }
    }
}
