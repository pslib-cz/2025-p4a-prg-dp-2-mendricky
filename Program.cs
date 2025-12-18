using LoggingAdapterProject;

Console.WriteLine("=== Ukázka vzoru Adapter ===");

// 1. připravení nové knihovny - adaptee
ModernAnalyticsLibrary newLibrary = new ModernAnalyticsLibrary();

// 2. zabalení do adaptéru
ILogger logger = new AnalyticsAdapter(newLibrary);

// 3. zbytek aplikace volá ILogger jako vždy (Client)
// nikdo netuší, že pod kapotou je úplně jiná knihovna.
logger.Log("Uživatel se přihlásil");
logger.Log("Objednávka byla vytvořena");
logger.Log("Chyba při nahrávání souboru");

Console.WriteLine("\nHotovo. Všimněte si, že jsme volali jen metodu Log(), ale výstup je z ModernAnalyticsLibrary.");
