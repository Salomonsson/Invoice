using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Maker
{
    public class ItemListClass : Manager<InvoiceItemClass>
    {
        private int setID = 0;

        //Empty constructor
        public ItemListClass()
        {

        }


        public void AddNewInvoice(InvoiceItemClass an)
        {
            //an.ID = setID++;
            an.ID = setID++;
            
            //an.Name = "varÄrJag";
            this.Add(an);
        }

    }
}
