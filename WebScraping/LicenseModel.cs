namespace WebScraping
{
    public class LicenseModel
    {
        public int Id { get; set; }
        public string LicenseId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Category { get; set; }
        public string TradeName { get; set; }
        public string Street { get; set; }
        public string CityCounty { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        //public string AsString() => $"FullName: {this.FullName},{Environment.NewLine}TradeName: {this.TradeName},{Environment.NewLine}Address: {this.Address},{Environment.NewLine}City: {this.City},{Environment.NewLine}State: {this.State},{Environment.NewLine}Zip: {this.Zip},{Environment.NewLine}ExpirationDate: {this.ExpirationDate},{Environment.NewLine}Category: {this.Category},{Environment.NewLine}LicenseId: {this.LicenseId}";
    }
}
