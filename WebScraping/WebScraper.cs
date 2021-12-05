using System.Text;
using HtmlAgilityPack;

namespace WebScraping
{
    public class WebScraper
    {
        public string errorMessage = string.Empty;
        public async Task<PersonModel?> ValidateLicense(string licenseId)
        {
            if(licenseId is not null)
            {
                const string POSTBACK_URL = "https://www.dllr.state.md.us/cgi-bin/ElectronicLicensing/OP_Search/OP_search.cgi";
                try
                {
                    string response = await
                    (await new HttpClient().PostAsync
                    (POSTBACK_URL, new StringContent
                    ($"calling_app=RE%3A%3ARE_registration_num&search_page=RE%3A%3ARE_registration_num&from_self=true&unit=11&html_title=Real+Estate+Commission&error_contact=Division+of+Occupational+and+Professional+Licensing&reg={licenseId}&Submit=Search", Encoding.UTF8, "application/x-www-form-urlencoded"))).Content.ReadAsStringAsync();

                    HtmlDocument doc = new();
                    doc.LoadHtml(response);
                    HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html/body/div/form/table/tbody/tr");

                    if (nodes.Count >= 2)
                    {
                        var dataPoints = nodes[1].SelectNodes("td");

                        if (dataPoints.Count == 9)
                        {
                            PersonModel personModel = new()
                            {
                                FullName = dataPoints[0].InnerText?.Trim(),
                                TradeName = dataPoints[1].InnerText?.Trim(),
                                Address = dataPoints[2].InnerText?.Trim(),
                                City = dataPoints[3].InnerText?.Trim(),
                                State = dataPoints[4].InnerText?.Trim(),
                                Zip = dataPoints[5].InnerText?.Trim(),
                                ExpirationDate = DateTime.Parse(dataPoints[6].InnerText?.Trim()),
                                Category = dataPoints[7].InnerText?.Trim(),
                                LicenseId = dataPoints[8].InnerText?.Trim()
                            };
                            return personModel;
                        }
                    }
                }
                catch (Exception e) { errorMessage = e.Message; }
            }
            else { errorMessage = "Input is empty"; }
            return null;
        }
    }
}
