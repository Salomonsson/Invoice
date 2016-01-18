using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Maker
{
    public class InvoiceCart
    {

        public decimal VoucherTotal { get; set; }
        public decimal Total { get; set; }

        public InvoiceCart(){

        }

        public decimal Get_Total()
        {
            //Total = GetPrice_TotalPrice() + 3;
            return Total;
        }

    }
}
