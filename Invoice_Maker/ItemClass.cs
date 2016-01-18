using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Maker
{
    public class ItemClass
    {

        public int ID_Item { get; set; }

        //Total Ska nog inte vara här
        //public string ItemC_NumberOfItem { get; set; }

        //Items
        public string ItemC_DecriptionItem { get; set; }
        public int ItemC_QuantityItem { get; set; }
        public decimal ItemC_UnitPriceItem { get; set; }
        public decimal ItemC_TaxItem { get; set; }
       


        public decimal ItemC_TotalPrice { get; set; }


        //Math section
        public decimal Item_C_Tax_As_Decimal { get; set; }

        public decimal Item_C_Tax_Of_Price { get; set; }

        public decimal Item_C_Total_Price_Tax_Included { get; set; }

        
        public ItemClass()
        {
            
        }

        public ItemClass(string _description, int _quantity, decimal _unitPrice, decimal _tax)
        {
            ItemC_DecriptionItem = _description;
            ItemC_QuantityItem = _quantity;
            ItemC_UnitPriceItem = _unitPrice;
            ItemC_TaxItem = _tax;
            //ItemC_TaxItem = Convert.ToInt32(_tax);
        }


        //Math functions
        //Get the full price of the item and quantity
        public decimal GetPrice_TotalPrice()
        {
           //ItemC_TotalPrice = ItemC_QuantityItem * ItemC_UnitPriceItem;

           return this.ItemC_TotalPrice = ItemC_QuantityItem * ItemC_UnitPriceItem;
        }

        //Get the tax and convert it into decimal
        public decimal GET_Tax_As_Decimal()
        {
            int discount = Convert.ToInt32(this.ItemC_TaxItem);
            double voucher = discount / 100.0;
            //decimal testDec = Convert.ToDecimal(currentInvoiceObject.GetPrice_TotalPriceTAX_DOUBLE().ToString());//Double?
            decimal convertedTax = Convert.ToDecimal(voucher.ToString());

            return Item_C_Tax_As_Decimal = convertedTax;
        }


        //Calculate the tax of the price. Based on the tax that is set
        public decimal GET_Tax_Of_Price()
        {
            decimal tax_of_price = GetPrice_TotalPrice() * Item_C_Tax_As_Decimal;
            return Item_C_Tax_Of_Price = tax_of_price;
        }

        //Get the total amount of cost, with the tax included of the item
        public decimal GET_Total_Price_Tax_Included()
        {
            //decimal resilt = currentInvoiceObject.ItemC_TotalPriceTaxNTotal * testDec;
            decimal result_Tax_Included = ItemC_TotalPrice + GET_Tax_Of_Price();
            return Item_C_Total_Price_Tax_Included = result_Tax_Included;
        }

       


        public override string ToString()
        {
            //return base.ToString() + " Ljud:" + Sound;
            string strOut = String.Format("(id:{0})- (Description:{1}), , Unitpriiceitem: {2}, get_TotalPrice(): {3}   ", ID_Item, ItemC_DecriptionItem, ItemC_UnitPriceItem, GetPrice_TotalPrice());

            strOut = strOut.ToUpper();
            return strOut;
        }



    }
}
