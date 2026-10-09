using System;
using System.Runtime.InteropServices;

namespace GamesMasterEngine.Services
{
    public static class EngineBridge
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct EngineMetrics
        {
            public float CurrentFps;
            public float NeonLoadPercent;
            public uint ActiveBuffersCount;

            [MarshalAs(UnmanagedType.I1)]
            public bool ZeroCopyActive;
        }

        [DllImport("engine", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetEngineTelemetry(ref EngineMetrics outMetrics);

        public static EngineMetrics FetchTelemetry()
        {
            EngineMetrics metrics = new EngineMetrics();
            try
            {
                GetEngineTelemetry(ref metrics);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EngineBridge] Błąd odczytu natywnego C++: {ex.Message}");
            }
            return metrics;
        }
    }
}
