# FinanceApp
Aplikace je navržena tak, abyste měli přehled o svých financích. Umožňuje sledovat oblíbená aktiva, plánovat půjčky, odhadovat očekávané výnosy a pravidelně si zaznamenávat, jak se vám po kvartálech finančně daří. Zároveň budete mít přehled o tom, jak máte diverzifikované portfolio napříč různými finančními nástroji.
 
Aplikace vám neumožní zobrazit ceny finančních instrumentů. Pokud je chcete zobrazit, tak jděte na stránku: https://www.finnhub.io/register 
Po registraci obdržíte API klíč, který vložíte do souboru Components/Services/MarketService.cs
Klidně si změňte finanční instrumenty, které vás zajímají. Stačí znát symbol těchto instrumentů a upravit ho v souboru Components\Pages\Market\MarketPage.razor
