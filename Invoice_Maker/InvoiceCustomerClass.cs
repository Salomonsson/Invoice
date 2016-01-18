using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Maker
{
    public class InvoiceCustomerClass : InvoiceDetails
    {

        public string P4_CustomerCompanyDeliverer { get; set; }
        public string P5_CustomerDeliverToPerson { get; set; }
        public string P6_CustomerAdressPerson { get; set; }
        public double P7_CustomerZipcode { get; set; }
        public string P8_CustomerCity { get; set; }
        public string P9_CustomerCountry { get; set; }


        public InvoiceCustomerClass()
        {
            P4_CustomerCompanyDeliverer = invoiceTxt[3].ToString();
            P5_CustomerDeliverToPerson = invoiceTxt[4].ToString();
            P6_CustomerAdressPerson = invoiceTxt[5].ToString();
            P7_CustomerZipcode = Convert.ToDouble(invoiceTxt[6]);
            P8_CustomerCity = invoiceTxt[7].ToString();
            P9_CustomerCountry = invoiceTxt[8].ToString();

        }



        public override string ToString()
        {
            string strOut = String.Format("(InvoiceNumber:{0}), , CompanyDeliverer: {1}   ", P1_InvoiceNumber, P2_InvoiceDate);

            strOut = strOut.ToUpper();
            return strOut;
        }
    }
}
