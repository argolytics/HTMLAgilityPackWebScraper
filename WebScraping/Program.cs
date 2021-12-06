using WebScraping;

Console.WriteLine("Validating in HtmlAgilityPack mode..." + Environment.NewLine);

WebScraper scraper = new();
PersonModel personResult = await scraper.ValidateLicense("Amanda", "Palafox", "658045");

if(personResult != null)
{
    Console.WriteLine("Results:{0}---------{0}{1}", Environment.NewLine, personResult?.AsString());
}
else
{
    Console.WriteLine(scraper.errorMessage);
}
Console.ReadKey();