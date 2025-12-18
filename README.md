# Adaptér

Tento projekt demonstruje řešení problému nekompatibilních rozhraní pomocí návrhového vzoru **Adapter**.

## O co jde? (Lidsky vysvětleno)
Představte si, že jedete na dovolenou do USA. Máte svůj oblíbený fén na vlasy s českou (evropskou) zástrčkou. Ale v hotelovém pokoji jsou jen americké zásuvky.
Máte dvě možnosti:
1. Rozbít zeď a předělat celou elektroinstalaci hotelu na evropskou (měnit kód na stovkách míst v aplikaci).
2. Koupit si **adaptér**, do kterého píchnete svůj český fén a ten pak zapojíte do americké zásuvky.

V programování dělá Adapter úplně to samé. Máme "zásuvku" (rozhraní `ILogger`), kterou naše aplikace vyžaduje, a máme "spotřebič" (moderní analytickou knihovnu), která má jiný konektor (`TrackEvent`).

## Proč jsme to udělali takhle?
*   **Nechceme měnit fungující kód:** Aplikace už na stovkách míst volá `logger.Log(zprava)`. Kdybychom tam chtěli přímo dát novou knihovnu, museli bychom přepsat všechny tyto řádky na `newLibrary.TrackEvent(zprava, 1)`. To je pracné a riskantní.
*   **Knihovnu třetí strany nemůžeme měnit:** Dostali jsme ji jako .dll, takže do jejího vnitřního kódu nevidíme a nemůžeme jí vnutit naše rozhraní `ILogger`.

## Jak to funguje v kódu?
1.  **Cíl (Target):** rozhrani `ILogger`, které naše aplikace očekává.
2.  **Přizpůsobovaný (Adaptee):** třída `ModernAnalyticsLibrary`, která dělá to, co chceme, ale má jiné rozhraní.
3.  **Adaptér:** třída `AnalyticsAdapter`, která se tváří jako `ILogger`, ale uvnitř tiše přeposílá požadavky do `ModernAnalyticsLibrary` a "překládá" je do formátu, kterému knihovna rozumí.

### Ukázka použití:
Místo přímého užití knihovny použijeme adaptér:
```csharp
ILogger logger = new AnalyticsAdapter(new ModernAnalyticsLibrary());
logger.Log("Zprava pro analytiku"); // Aplikace je spokojená, volá starou známou metodu.
```

## Výhody
*   **Single Responsibility Principle (Princip jedné odpovědnosti):** kód pro konverzi rozhraní je oddělen od zbytku aplikace
*   **Open/Closed Principle (Princip otevřenosti/uzavřenosti):** můžeme přidávat nové adaptéry (třeba pro jinou knihovnu v budoucnu), aniž bychom rozbili stávající kód
