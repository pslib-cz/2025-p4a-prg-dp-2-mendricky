namespace LoggingAdapterProject;

/// <summary>
/// simulace moderni analyticke knihovny od treti strany
/// tato trida je zamcena (napr. v dll)
/// </summary>
public class ModernAnalyticsLibrary
{
    public void TrackEvent(string eventName, int severity)
    {
        Console.WriteLine($"[Analytics] Tracking event: '{eventName}' with severity: {severity}");
    }
}
