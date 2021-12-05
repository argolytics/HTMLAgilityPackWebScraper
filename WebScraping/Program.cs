using WebScraping;

Console.WriteLine("Validating in HtmlAgilityPack mode..." + Environment.NewLine);

WebScraper scraper = new();
PersonModel personResult = await scraper.ValidateLicense("658045");

Console.WriteLine("Results:{0}---------{0}{1}", Environment.NewLine, personResult?.AsString() ?? "Error occurred");
Console.ReadKey();