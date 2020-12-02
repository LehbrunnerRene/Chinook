using CsvMapper.Logic.Attributes;

namespace Chinook.Logic.Models.Persistence
{
    [CsvMapper.Logic.Attributes.DataClass(HasHeader = true, FileName = "CsvData/Invoice.csv")]
    internal class Invoice : IdentityObject,Contracts.Persistence.IInvoice
    {
        [DataPropertyInfo(OrderPosition = 1)]
        public int CustomerId { get; set; }
        [DataPropertyInfo(OrderPosition = 2)]
        public string InvoiceDate { get; set; }
        [DataPropertyInfo(OrderPosition = 3)]
        public string BillingAddress { get; set; }
        [DataPropertyInfo(OrderPosition = 4)]
        public string BillingCity { get; set; }
        [DataPropertyInfo(OrderPosition = 5)]
        public string BillingState { get; set; }
        [DataPropertyInfo(OrderPosition = 6)]
        public string BillingCountry { get; set; }
        [DataPropertyInfo(OrderPosition = 7)]
        public string BillingPostalCode { get; set; }
        [DataPropertyInfo(OrderPosition = 8)]
        public double Total { get; set; }

    }
}
