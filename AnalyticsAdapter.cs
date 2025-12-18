namespace LoggingAdapterProject;

/// <summary>
/// adapter, ktery propojuje ILogger s ModernAnalyticsLibrary
/// Implementuje ILogger, takze ho zbytek aplikace může pouzivat beze zmen
/// </summary>
public class AnalyticsAdapter : ILogger
{
    private readonly ModernAnalyticsLibrary _analyticsLibrary;

    public AnalyticsAdapter(ModernAnalyticsLibrary analyticsLibrary)
    {
        _analyticsLibrary = analyticsLibrary;
    }

    public void Log(string message)
    {
        // převod (adaptace) volání Log na TrackEvent
        // message: eventName; severity: 1
        _analyticsLibrary.TrackEvent(message, 1);
    }
}
