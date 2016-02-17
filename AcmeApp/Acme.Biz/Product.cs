using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manage products carried in repository
    /// </summary>
    public class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;
        public enum IncludeAddress
        {
            Yes,
            No
        };

        #region Constructors
        public Product()
        {
            this.MinimumPrice = .96m;
            this.Category = "Tools";
            Console.WriteLine("Product instance created.");
        }

        public Product(string productName,
                        int productId,
                        string description) : this()
        {
            this.Description = description;
            this.ProductName = productName;
            this.ProductId = productId;
            if (this.ProductName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.97m;
            }
            Console.WriteLine("Create product with name " + this.ProductName);
        }
        #endregion

        #region Properties
        private string productName;

        public string ProductName
        {
            get {
                var formattedProductName = productName?.Trim();
                return formattedProductName;
            }
            set { productName = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get { 
                if(null == productVendor) {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        public string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;

        public string ProductCode => this.Category + "-" + this.SequenceNumber;
        #endregion

        public string SayHello()
        {
            var vendor = new Vendor();
            vendor.SendWelcomeEmail("Message from Product");

            var emailService = new EmailService();
            emailService.SendMessage("New Product", this.ProductName, "sales@abs.com");

            var result = LogAction("Product SayHello");

            return "Hello " + ProductName + " (" + ProductId + "): " + Description
                + " Available on: " + AvailabilityDate?.ToShortDateString();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
