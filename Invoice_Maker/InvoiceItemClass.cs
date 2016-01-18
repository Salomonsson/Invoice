using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Maker
{
    public class InvoiceItemClass : InvoiceCustomerClass
    {
        public string statusProperty ="hej";
        public double convertedPriceItem1;

        public InvoiceItemClass()
        {

            //Convert item 1
            P11_DescriptionItem = invoiceTxt[10].ToString();
            P12_QuantityItem = Convert.ToInt16(invoiceTxt[11]);
            //P13_PriceItem = invoiceTxt[12].ToString(); //Convert to double in main program
            //convertedPriceItem1 = double.Parse(invoiceTxt[12].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            P13_PriceItem = decimal.Parse(invoiceTxt[12].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //P14_TaxItem = Convert.decimal(invoiceTxt[13]);
            P14_TaxItem = decimal.Parse(invoiceTxt[13].ToString(), System.Globalization.CultureInfo.InvariantCulture);

            //Convert item 2
            P15_DescriptionItem2 = invoiceTxt[14].ToString();
            P16_QuantityItem2 = Convert.ToInt16(invoiceTxt[15]);
            //P17_PriceItem2 = invoiceTxt[16].ToString(); //Convert to double in main program
            P17_PriceItem2 = decimal.Parse(invoiceTxt[16].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //P18_TaxItem2 = Convert.ToInt16(invoiceTxt[17]);
            P18_TaxItem2 = decimal.Parse(invoiceTxt[17].ToString(), System.Globalization.CultureInfo.InvariantCulture);

        }

        //INVOICE ITEMS #1
        public string P11_DescriptionItem { get; set; }
        public int P12_QuantityItem { get; set; }
        //public double P13_PriceItem { get; set; } //Double?
        public decimal P13_PriceItem { get; set; } //Double?
        public decimal P14_TaxItem { get; set; }


        //INVOICE ITEMS #2
        public string P15_DescriptionItem2 { get; set; }
        public int P16_QuantityItem2 { get; set; }
        public decimal P17_PriceItem2 { get; set; }
        public decimal P18_TaxItem2 { get; set; }


        //Override the base toString, plus add extra info
        public override string ToString()
        {
            //return base.ToString() + " Ljud:" + Sound;
            return base.ToString() + "Current Status: " + statusProperty;
        }


    }
}






//P17_PriceItem2 = double.Parse(invoiceTxt[16], NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture);
//P17_PriceItem2 = invoiceTxt[16].ToString();


//P17_PriceItem2 = Convert.ToDouble(invoiceTxt[16]);//Double?
//P17_PriceItem2 = double.Parse(invoiceTxt[16]);