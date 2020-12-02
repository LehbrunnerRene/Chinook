using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Report.Marketing.Models
{
    internal class CustomerSaleStatistic : Contracts.Report.Marketing.ICustomerSaleStatistic
    {
        public string maxName { get; set; }

        public string maxNumber { get; set; }

        public string minName { get; set; }

        public string minNumber { get; set; }

        public string avgNumber { get; set; }
    }
}
