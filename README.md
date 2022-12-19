# AppTimeHomework
Jako nedostatky mého řešení vidím následující:
1. Řešení obsahuje jen nástřel několika testů, které lze provést. Testů, které lze provést, je ale mnohem mnohem více.
2. Nevěnoval jsem dostatečnou pozornost možným výjimkám a přepokládám, že může nastat několik neočekávaných výjimek.
3. Bylo by vhodné zjistit, jak nabízet podporované formáty v combo boxu ve formátu textu, na místo číslené hodnoty enumu. Atribut [Description("xml")] nezabral a stále se mi nabízí číselná hodnota.
4. Nepodařilo se mi splnit tu část zadání, která požadovala odesílání souboru na mail.  


V řešení, které bylo součástí zadání, vidím několik problémů. 
1. celá logika je součástí jedné metody, i když by mi přišlo správnější tuto logiku rozdělit do více metod.
2. Návrh používá fixní název souboru zdrojového i cílového. To znamená, že zdrojový soubor musíme vždy pojmenovat stejně a nahrát ho do složky Source files. Kdybychom chtěli konvertovat více souborů najednou, tato implementace nám to neumožní.
3. Kód v zadání nezavírá soubor, do kterého se text zapisuje. To znamená, že se souborem nelze pracovat, dokud se program neukončí.
