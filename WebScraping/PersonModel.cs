namespace WebScraping
{
    public class PersonModel
    {
        public string FullName { get; set; }
        public string TradeName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Category { get; set; }
        public string LicenseId { get; set; }

        public string AsString() => $"FullName: {this.FullName},{Environment.NewLine}TradeName: {this.TradeName},{Environment.NewLine}Address: {this.Address},{Environment.NewLine}City: {this.City},{Environment.NewLine}State: {this.State},{Environment.NewLine}Zip: {this.Zip},{Environment.NewLine}ExpirationDate: {this.ExpirationDate},{Environment.NewLine}Category: {this.Category},{Environment.NewLine}LicenseId: {this.LicenseId}";
    }
}
