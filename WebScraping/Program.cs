using WebScraping;

Console.WriteLine("Validating in HtmlAgilityPack mode..." + Environment.NewLine);

WebScraper scraper = new();
LicenseModel validationResult = await scraper.ValidateLicense("Amanda", "Palafox", "658045");

if(validationResult != null)
{
    Console.WriteLine($"LicenseId: {validationResult.LicenseId}, Category: {validationResult.Category}, ExpirationDate: {validationResult.ExpirationDate}, Tradename: {validationResult.TradeName}, Street: {validationResult.Street}, CityCounty: {validationResult.CityCounty}, State: {validationResult.State}, Zipcode: {validationResult.ZipCode}");
}
else
{
    Console.WriteLine(scraper.errorMessage);
}
Console.ReadKey();