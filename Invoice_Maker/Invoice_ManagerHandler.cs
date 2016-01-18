using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Maker
{
    public class Invoice_ManagerHandler : Manager<ItemClass>
    {

         private int setID = 0;

        //Konstruktor - skapa objekten som ingår som variabler 
        /// <summary>
        /// Default constructor - create the Animal list
        /// </summary>
         public Invoice_ManagerHandler()
        {
           
        }

        /// <summary>
        /// Add the animal object to listmanagaer. And use listmanagars full potential
        /// </summary>
        /// <param name="an">type of object</param>
         public void AddNewInvoice(ItemClass an)
        {
            an.ID_Item = setID++;
            this.Add(an);
        }



         //public List<T> thisIsAtest<T>()
         //{
         //    return query;
         //}


    }
}
