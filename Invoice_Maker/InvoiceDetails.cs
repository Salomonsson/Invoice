using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Invoice_Maker
{
    public abstract class InvoiceDetails
    {
        //Filen med invoice information deklareras här
        public string[] invoiceTxt = System.IO.File.ReadAllLines(@"C:\Users\Psylon\documents\visual studio 2013\Projects\Invoice_Maker\Invoice_Maker\TextDocuments\InvoiceDemo1-1.txt");
        //public string[] invoiceTxt = System.IO.File.ReadAllLines(@"C:\Users\Psylon\Documents\Visual Studio 2013\Projects\Invoice_Maker\Invoice_Maker\bin\Debug\InvoiceDemo.txt");
        //public string[] invoiceTxt = System.IO.File.ReadAllLines("InvoiceDemo.txt");


        //public string[] invoiceTxt = File.Open("InvoiceDemo.txt");
        //public string[] invoiceTxt = File.ReadAllLines("TextDocuments/InvoiceDemo.txt");
        //public string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"TextDocuments/InvoiceDemo.txt");
        //public string[] invoiceTxt = File.ReadAllLines(path);
        //public InvoiceDetails(int idd)
        //static string path = "InvoiceDemo.txt";
        //public string[] invoiceTxt = System.IO.File.ReadAllLines(path);


        public InvoiceDetails()
        {
            // Read every line in the file.
            //using (StreamReader reader = new StreamReader("TextDocuments/InvoiceDemo.txt"))
            //{
            //    string line;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        // Do something with the line.
            //        string[] invoiceTxt = line.Split(',');
            //    }
            //}
           
            // string[] invoiceTxt = System.IO.File.ReadAllLines("InvoiceDemo.txt");
            ////invoiceNumber = lines[0].ToString();
            P1_InvoiceNumber = Convert.ToInt16(invoiceTxt[0]);
            P2_InvoiceDate = invoiceTxt[1].ToString();

            P3_Duedate = invoiceTxt[2].ToString();


            //Customer 
            //P4_CompanyDeliverer = invoiceTxt[3].ToString();
            //P5_DeliverToPerson = invoiceTxt[4].ToString();
            //P6_AdressPerson = invoiceTxt[5].ToString();
            //P7_Zipcode = Convert.ToDouble(invoiceTxt[6]);
            //P8_City = invoiceTxt[7].ToString();
            //P9_Country = invoiceTxt[8].ToString();


            P10_NumberOfItems = Convert.ToInt16(invoiceTxt[9]);

            //P11_DescriptionItem = invoiceTxt[10].ToString();
            //P12_QuantityItem = Convert.ToInt16(invoiceTxt[11]);
            ////P13_PriceItem = Convert.ToDouble(invoiceTxt[12]); ;//String?? Double??
            //P13_PriceItem = invoiceTxt[12].ToString(); //String?? Double??
            //P14_TaxItem = Convert.ToDouble(invoiceTxt[13]);



            //P15_DescriptionItem2 = invoiceTxt[14].ToString();
            //P16_QuantityItem2 = Convert.ToInt16(invoiceTxt[15]);
            ////P17_PriceItem2 = Convert.ToDecimal(invoiceTxt[16]);//Double?
            //P17_PriceItem2 = invoiceTxt[16].ToString();
            //P18_TaxItem2 = Convert.ToInt16(invoiceTxt[17]);





            P19_SenderCompany = invoiceTxt[18].ToString();
            P20_StreetSender = invoiceTxt[19].ToString();
            P21_ZipcodeSender = Convert.ToInt16(invoiceTxt[20]);
            P22_CitySender = invoiceTxt[21].ToString();
            //P23_PhoneNumberSender = Convert.ToInt16(invoiceTxt[22]);
            P23_PhoneNumberSender = invoiceTxt[22].ToString(); //Int phone number, space
            P24_HomePageURLSender = invoiceTxt[23].ToString();



        }

        //set unique id for list
        //INVOICE DETAILS
        public int ID { get; set; }
        public int P1_InvoiceNumber { get; set; }
        public string P2_InvoiceDate { get; set; }
        public string P3_Duedate { get; set; }

        //INVOICE COMPANY DELIVERER
        //public string P4_CompanyDeliverer { get; set; }
        //public string P5_DeliverToPerson { get; set; }
        //public string P6_AdressPerson { get; set; }
        //public double P7_Zipcode { get; set; }
        //public string P8_City { get; set; }
        //public string P9_Country { get; set; }


        //INVOICE ITEMS TOTAL
        public int P10_NumberOfItems { get; set; }
        ////INVOICE ITEMS #1
        //public string P11_DescriptionItem { get; set; }
        //public int P12_QuantityItem { get; set; }
        ////public double P13_PriceItem { get; set; } //Double?
        //public string P13_PriceItem { get; set; } //Double?
        //public double P14_TaxItem { get; set; }


        ////INVOICE ITEMS #2
        //public string P15_DescriptionItem2 { get; set; }
        //public int P16_QuantityItem2 { get; set; }
        //public string P17_PriceItem2 { get; set; }
        //public double P18_TaxItem2 { get; set; }



        //INVOICE SENDER COMPANY
        public string P19_SenderCompany { get; set; }
        public string P20_StreetSender { get; set; }
        public int P21_ZipcodeSender { get; set; }
        public string P22_CitySender { get; set; }
        public string P23_PhoneNumberSender { get; set; }
        public string P24_HomePageURLSender { get; set; }






        /// <summary>
        ///Format a string with values from this estate.
        ///Note that data for the address object is fetched from the
        ///address-object belonging to this estate.
        /// </summary>
        /// <returns>The formatted string.</returns>
        public override string ToString()
        {
            string strOut = String.Format("(InvoiceNumber:{0}), , InvoiceDate: {1}   ", P1_InvoiceNumber, P2_InvoiceDate);

            strOut = strOut.ToUpper();
            return strOut;
        }

    }
}


//public string invoiceNumber;
//public string invoiceDate;
//public string duedate;
//public string companyDeliverer;
//public string deliverToPerson;
//public string adressPerson;
//public string zipcode;
//public string city;
//public string country;





//public string numberOfItems;
//public string descriptionItem;
//public string quantityItem;
//public string priceItem;
//public string taxItem;




//public string descriptionItem2;
//public string quantityItem2;
//public string priceItem2;
//public string taxItem2;








//public string senderCompany;
//public string streetSender;
//public string zipcodeSender;
//public string citySender;
//public string phoneNumberSender;
//public string homePageURLSender;