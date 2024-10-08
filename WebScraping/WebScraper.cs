﻿using System.Text;
using HtmlAgilityPack;

namespace WebScraping
{
    public class WebScraper
    {
        public string errorMessage = string.Empty;
        public async Task<LicenseModel?> ValidateLicense(string firstName, string lastName, string licenseId)
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
                            if (dataPoints[0].InnerText.Trim().ToLowerInvariant().Contains(firstName.Trim().ToLowerInvariant()) && dataPoints[0].InnerText.Trim().ToLowerInvariant().Contains(lastName.Trim().ToLowerInvariant()))
                            {
                                LicenseModel licenseModel = new()
                                {
                                    TradeName = dataPoints[1].InnerText?.Trim(),
                                    Street = dataPoints[2].InnerText?.Trim(),
                                    CityCounty = dataPoints[3].InnerText?.Trim(),
                                    State = dataPoints[4].InnerText?.Trim(),
                                    ZipCode = dataPoints[5].InnerText?.Trim(),
                                    ExpirationDate = DateTime.Parse(dataPoints[6].InnerText?.Trim()),
                                    Category = dataPoints[7].InnerText?.Trim(),
                                    LicenseId = dataPoints[8].InnerText?.Trim()
                                };
                                return licenseModel;
                            }
                            else { errorMessage = "Invalid name. Please verify the name registered is the same as the name as it appears on your license."; }
                        }
                    }
                }
                catch (Exception e) { errorMessage = e.Message; }
            }
            return null;
        }
    }
}
