using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows;
using Microsoft.Win32;



namespace Invoice_Maker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        protected string descriptionItem;
        protected int quantityItem;
        protected decimal priceItem;
        protected decimal taxItem;

        InvoiceItemClass InvoiceInstance = null;
        Invoice_ManagerHandler managerItem = null;

        //This list handle the current invoice
        public List<ItemClass> Invoice_Item_List = new List<ItemClass>();
        public int indexList; //Public index from the datagrid
        
        public MainWindow()
        {
            InvoiceInstance = new InvoiceItemClass();//Invoice instans
            //The manager keeps track of the two items. 
            //I use the object id from the list to GetAt my genreric list.
            managerItem = new Invoice_ManagerHandler();//Invoice manager


            InitializeComponent();
            //Initialize start    //set false txxtboxes
            InitializeGUI();


            //Set variables for item 1
            string descriptionItem = InvoiceInstance.P11_DescriptionItem;
            int quantityItem = InvoiceInstance.P12_QuantityItem;
            decimal priceItem = InvoiceInstance.P13_PriceItem;
            decimal taxItem = InvoiceInstance.P14_TaxItem;

            //Item 1
            //Instantiate by constructor, set item values
            ItemClass itemObject = new ItemClass(descriptionItem, quantityItem, priceItem, taxItem);
            managerItem.AddNewInvoice(itemObject);

            //add item 1 as objet to the item_list
            AddToItemCollectionOBJECT(itemObject);


            //Item 2 set properties by constructor
            ItemClass itemObject2 = new ItemClass(
                InvoiceInstance.P15_DescriptionItem2,
                InvoiceInstance.P16_QuantityItem2,
                InvoiceInstance.P17_PriceItem2,
                InvoiceInstance.P18_TaxItem2
                );

            ////add item 2 to manager
            managerItem.AddNewInvoice(itemObject2);

            //Add object to List of items
            AddToItemCollectionOBJECT(itemObject2);

            //DataGrid_Items.ItemsSource = LoadCollectionData();
            DataGrid_Items.ItemsSource = LoadCollectionData();

            //Update the cart 
            updateCart();
        }


        int counterListItem = 0; //Counter to list item
        private void AddToItemCollectionOBJECT(ItemClass obj)
        {
            Invoice_Item_List.Add(new ItemClass()
            {
                ID_Item = counterListItem++,
                ItemC_DecriptionItem = obj.ItemC_DecriptionItem,
                ItemC_QuantityItem = obj.ItemC_QuantityItem,
                ItemC_UnitPriceItem = obj.ItemC_UnitPriceItem,
                ItemC_TaxItem = obj.ItemC_TaxItem,
                ItemC_TotalPrice = obj.GetPrice_TotalPrice(),
                Item_C_Tax_As_Decimal = obj.GET_Tax_As_Decimal(),//Math logic
                Item_C_Tax_Of_Price = obj.GET_Tax_Of_Price(),
                Item_C_Total_Price_Tax_Included = obj.GET_Total_Price_Tax_Included()

            });
        }


        //Set connection to data grid
        private List<ItemClass> LoadCollectionData()
        {
            return Invoice_Item_List;
        }

        //Initialize GUI
        private void InitializeGUI()
        {
            labelEditStatus.Content = "Press Edit to change values";

            //Clear output controls
            txtBoxEditDescription.IsEnabled = false;
            txtBoxEditQuanity.IsReadOnly = true;
            txtBoxEditUnitPrice.IsReadOnly = true;
            txtBoxEditTaxRate.IsReadOnly = true;

            //Button Controls
            buttonSaveItems.IsEnabled = false;
            buttonEditItems.IsEnabled = false;


            //Total amount of items
            labelTotalItems.Content = InvoiceInstance.P10_NumberOfItems;

            ////TAB PANEL - Invoice
            txtBoxInvoiceNr.Text = Convert.ToString(InvoiceInstance.P1_InvoiceNumber);
            txtboxInvoiceDate.Text = Convert.ToString(InvoiceInstance.P2_InvoiceDate);
            txtboxInvoiceDueDate.Text = Convert.ToString(InvoiceInstance.P3_Duedate);
            //set false
            txtBoxInvoiceNr.IsEnabled = false;
            txtboxInvoiceDate.IsEnabled = false;
            txtboxInvoiceDueDate.IsEnabled = false;

            ////TAB PANEL - SENDER
            SenderCompany.Text = InvoiceInstance.P19_SenderCompany;
            SenderStreet.Text = InvoiceInstance.P20_StreetSender;
            SenderZip.Text = Convert.ToString(InvoiceInstance.P21_ZipcodeSender);
            SenderCountry.Text = InvoiceInstance.P22_CitySender;
            SenderCity.Text = InvoiceInstance.P22_CitySender;
            SenderPhone.Text = InvoiceInstance.P23_PhoneNumberSender;
            SenderWebPage.Text = InvoiceInstance.P24_HomePageURLSender;
            //set false
            SenderCompany.IsEnabled = false;
            SenderStreet.IsEnabled = false;
            SenderZip.IsEnabled = false;
            SenderCountry.IsEnabled = false;
            SenderCity.IsEnabled = false;
            SenderPhone.IsEnabled = false;
            SenderWebPage.IsEnabled = false;
            //set button disable
            btnSaveGeneralInfo.IsEnabled = false;


            ////TAB PANEL - CUSTOMER
            txtboxCustomerOrderCustomer.Text = InvoiceInstance.P4_CustomerCompanyDeliverer;
            txtboxCustomerName.Text = InvoiceInstance.P5_CustomerDeliverToPerson;
            txtboxCustomerStreetAdress.Text = InvoiceInstance.P6_CustomerAdressPerson;
            txtboxCustomerZipCode.Text = Convert.ToString(InvoiceInstance.P7_CustomerZipcode);
            txtboxCustomerCountry.Text = InvoiceInstance.P9_CustomerCountry;
            //Set false
            txtboxCustomerOrderCustomer.IsEnabled = false;
            txtboxCustomerName.IsEnabled = false;
            txtboxCustomerStreetAdress.IsEnabled = false;
            txtboxCustomerZipCode.IsEnabled = false;
            txtboxCustomerCountry.IsEnabled = false;
            //btn
            ButtonSaveCustomer.IsEnabled = false;




            //IMG SECTION
            //string ImgPath = "ImagesLogo.png";
            //string ImgPath = @"C:\Users\Psylon\Desktop\airBus380.jpg";
            //IMGInvoice.Source = new BitmapImage(new Uri(ImgPath, UriKind.Relative));

        }


        //For each object in the item list add value to the cart object.
        private void updateCart()
        {
            InvoiceCart cart = new InvoiceCart();

            ListBoxCart.Items.Clear();
            ListBoxCart.Items.Add("Följande kostnader för produkterna:");
            foreach (ItemClass obj in Invoice_Item_List)
            {
                    //DataGrid_Items.Items.Refresh();
                    //break;
                    cart.Total += obj.GET_Total_Price_Tax_Included();
                    cart.VoucherTotal += obj.GET_Tax_Of_Price();
            }
            ListBoxCart.Items.Add("Cart object");
            ListBoxCart.Items.Add("Total Sum: " + cart.Total.ToString());
            ListBoxCart.Items.Add("Total Tax: " + cart.VoucherTotal.ToString());
        }

        //Update loops,
        #region Update Grid and Listbox
        //update the current Invoice list based on the incoming object from generic list.
        public void updateGrid(ItemClass inObj)
        {
            foreach (ItemClass obj in Invoice_Item_List)
            {
                if (obj.ID_Item == inObj.ID_Item)
                {
                    obj.ItemC_DecriptionItem = inObj.ItemC_DecriptionItem;
                    obj.ItemC_QuantityItem = inObj.ItemC_QuantityItem;
                    obj.ItemC_UnitPriceItem = inObj.ItemC_UnitPriceItem;
                    obj.ItemC_TaxItem = inObj.ItemC_TaxItem;
                    obj.ItemC_TotalPrice = inObj.GetPrice_TotalPrice();
                    //Update match logic
                    obj.Item_C_Tax_As_Decimal = inObj.GET_Tax_As_Decimal();
                    obj.Item_C_Tax_Of_Price = inObj.GET_Tax_Of_Price();
                    obj.Item_C_Total_Price_Tax_Included = inObj.GET_Total_Price_Tax_Included();

                    //refresh data grid
                    DataGrid_Items.Items.Refresh();
                    //obj.otherProp = newValue;
                    break;
                }
            }
        }

        #endregion

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Du vill avsluta.");
        }


        
        private void DataGrid_Items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DataGrid_Items.SelectedIndex >= 0)
                {
                    //set edit button true
                    buttonEditItems.IsEnabled = true;
                    //Get index of the selected data grid item
                    indexList = DataGrid_Items.SelectedIndex;
                    //MessageBox.Show(indexList.ToString());
                    labelCurrentIndex.Content = "Current Index: " + indexList.ToString();

                    //Get current index of the choosen object in data grid list
                    ItemClass currentInvoiceObject = managerItem.GetAt(indexList);

                    //Set value to textboxes based on index objekt from manager list handler
                    txtBoxEditDescription.Text = currentInvoiceObject.ItemC_DecriptionItem;
                    txtBoxEditQuanity.Text = currentInvoiceObject.ItemC_QuantityItem.ToString();
                    txtBoxEditUnitPrice.Text = currentInvoiceObject.ItemC_UnitPriceItem.ToString();
                    txtBoxEditTaxRate.Text = currentInvoiceObject.ItemC_TaxItem.ToString();

                    //Test section
                    ////Total price
                    //MessageBox.Show(currentInvoiceObject.ItemC_TotalPrice.ToString() + " TotalPrice prop");
                    ////decimal testDecPROP = Convert.ToDecimal(currentInvoiceObject.GET_Tax_As_Decimal().ToString());//Double?
                    ////Tax as decimal
                    //MessageBox.Show(currentInvoiceObject.GET_Tax_As_Decimal().ToString() + " Tax as decimal Prop");                  
                    ////Total price tax included
                    //MessageBox.Show(currentInvoiceObject.GET_Tax_Of_Price().ToString() + " Tax of price");
                    ////Full price
                    //MessageBox.Show(currentInvoiceObject.GET_Total_Price_Tax_Included().ToString());
                   
                }
            }
            catch (Exception ex)
            {
                buttonEditItems.IsEnabled = false;
                MessageBox.Show("Dont go out of bound in the data grid. Not enough data."
                    +Environment.NewLine + "Läs nedan för detaljerat fel.. " 
                    + Environment.NewLine + ex.ToString());
                //throw;
            }
        }





        //Edit button for the choosen item
        private void buttonEditItems_Click(object sender, RoutedEventArgs e)
        {
            labelEditStatus.Content = "Select item to change value";

            buttonEditItems.IsEnabled = false;
            buttonSaveItems.IsEnabled = true;

            txtBoxEditDescription.IsEnabled = true;
            txtBoxEditQuanity.IsReadOnly = false;
            txtBoxEditUnitPrice.IsReadOnly = false;
            txtBoxEditTaxRate.IsReadOnly = false;

            //Disable data grid
            DataGrid_Items.IsEnabled = false;
        }

        //Save the made changes of the choosen item
        private void buttonSaveItems_Click(object sender, RoutedEventArgs e)
        {
            labelEditStatus.Content = "Changes has been saved";

            buttonEditItems.IsEnabled = true;
            buttonSaveItems.IsEnabled = false;

            txtBoxEditDescription.IsEnabled = false;
            txtBoxEditQuanity.IsReadOnly = true;
            txtBoxEditUnitPrice.IsReadOnly = true;
            txtBoxEditTaxRate.IsReadOnly = true;

            //Disable data grid
            DataGrid_Items.IsEnabled = true;


            //set new value form textboxes, the "edit field" and add value to the current object from
            //invoice list manager
            ItemClass CurrentInvoiceObject = managerItem.GetAt(indexList);

            CurrentInvoiceObject.ItemC_DecriptionItem = txtBoxEditDescription.Text;
            

            bool validUserInputDecimal = false;
            bool validUserInputInteger = false;

            //check valid decimal inout by user, comma allowed, dots are not.
            CheckQuantityInt(out validUserInputInteger);
            CheckUnitPrice(out validUserInputDecimal);
            

            if (validUserInputDecimal && validUserInputInteger)
            {
                CurrentInvoiceObject.ItemC_QuantityItem = Convert.ToInt16(txtBoxEditQuanity.Text);
                CurrentInvoiceObject.ItemC_UnitPriceItem = decimal.Parse(txtBoxEditUnitPrice.Text, new NumberFormatInfo() { NumberDecimalSeparator = "," });
            
            }
            CurrentInvoiceObject.ItemC_TaxItem = Convert.ToInt16(txtBoxEditTaxRate.Text);


            //update grid, argument is the current object in use from generic class.
            updateGrid(CurrentInvoiceObject);
            //Update the cart
            updateCart();
        }

        //Validation Region, Integers and decimals edit section of application
        #region ValidationRegion
                private decimal CheckUnitPrice(out bool success)
                {
                    decimal itemPrice = 0;
                    success = decimal.TryParse(txtBoxEditUnitPrice.Text, out itemPrice);

                    if (itemPrice < 0 || !success)
                    {
                        MessageBox.Show("The entered Unit Price is not valid! Use comma, not dots. OK?");
                        success = false;
                    }

                    return itemPrice;
                }

                private int CheckQuantityInt(out bool success)
                {
                    int itemQuantity = 0;
                    success = int.TryParse(txtBoxEditQuanity.Text, out itemQuantity);

                    if (itemQuantity < 0 || !success)
                    {
                        MessageBox.Show("The entered Quantity is not valid! Integers only");
                        success = false;
                    }

                    return itemQuantity;
                }
        #endregion

       

        #region ButtonSenderAndCustomerInfo

                //Not in use
                //private void ButtonEditCustomer_Click(object sender, RoutedEventArgs e)
                //{
                //    txtboxCustomerOrderCustomer.IsEnabled = true;
                //    txtboxCustomerName.IsEnabled = true;
                //    txtboxCustomerStreetAdress.IsEnabled = true;
                //    txtboxCustomerZipCode.IsEnabled = true;
                //    txtboxCustomerCountry.IsEnabled = true;
                //}

                private void ButtonSenderEdit_Click(object sender, RoutedEventArgs e)
                {

                    SenderCompany.IsEnabled = true;
                    SenderStreet.IsEnabled = true;
                    SenderZip.IsEnabled = true;
                    SenderCountry.IsEnabled = true;
                    SenderCity.IsEnabled = true;
                    SenderPhone.IsEnabled = true;
                    SenderWebPage.IsEnabled = true;

                    //btn
                    ButtonSenderSave.IsEnabled = true;
                    ButtonSenderEdit.IsEnabled = false;
                }

                private void ButtonEditCustomer_Click_1(object sender, RoutedEventArgs e)
                {
                    txtboxCustomerOrderCustomer.IsEnabled = true;
                    txtboxCustomerName.IsEnabled = true;
                    txtboxCustomerStreetAdress.IsEnabled = true;
                    txtboxCustomerZipCode.IsEnabled = true;
                    txtboxCustomerCountry.IsEnabled = true;

                    ButtonSaveCustomer.IsEnabled = true;
                    ButtonEditCustomer.IsEnabled = false;
                }

                #endregion

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                InvoiceImg.Source = new BitmapImage(new Uri(op.FileName));
            }


        }


        //Exit application
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEditGeneralInfo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Set save btn enabled
            btnSaveGeneralInfo.IsEnabled = true;
            //Set edit btn disable
            btnEditGeneralInfo.IsEnabled = false;
            ////TAB PANEL - Invoice
            txtBoxInvoiceNr.Text = Convert.ToString(InvoiceInstance.P1_InvoiceNumber);
            txtboxInvoiceDate.Text = Convert.ToString(InvoiceInstance.P2_InvoiceDate);
            txtboxInvoiceDueDate.Text = Convert.ToString(InvoiceInstance.P3_Duedate);
            //set false
            txtBoxInvoiceNr.IsEnabled = true;
            txtboxInvoiceDate.IsEnabled = true;
            txtboxInvoiceDueDate.IsEnabled = true;
        }

        private void btnSaveGeneralInfo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //set button enabled
            btnSaveGeneralInfo.IsEnabled = false;
            //set edit enabled
            btnEditGeneralInfo.IsEnabled = true;
            //set txtboxes false
            txtBoxInvoiceNr.IsEnabled = false;
            txtboxInvoiceDate.IsEnabled = false;
            txtboxInvoiceDueDate.IsEnabled = false;
            
            ////TAB PANEL - Invoice
            InvoiceInstance.P2_InvoiceDate = txtboxInvoiceDate.Text;
            InvoiceInstance.P3_Duedate = txtboxInvoiceDueDate.Text;

            //Message sign, telling changes were made
            MessageBox.Show("Följande ändringar gjordes: "
              + Environment.NewLine + InvoiceInstance.P2_InvoiceDate + " - Datum ändrat"
              + Environment.NewLine + InvoiceInstance.P3_Duedate + " - DueDate ändrat. ");
        }


    
    }

}



//listBoxInfo.Items.Add("Början class instance");
////listBoxInfo.Items.Add(t.ToString());
//listBoxInfo.Items.Add("InvoiceNumber: " + test.P1_InvoiceNumber);
//listBoxInfo.Items.Add(InstanceInvoice.P2_InvoiceDate);
//listBoxInfo.Items.Add(InstanceInvoice.P3_Duedate);
//listBoxInfo.Items.Add(InstanceInvoice.P4_CompanyDeliverer);
//listBoxInfo.Items.Add(InstanceInvoice.P5_DeliverToPerson);
//listBoxInfo.Items.Add(InstanceInvoice.P6_AdressPerson);
//listBoxInfo.Items.Add(InstanceInvoice.P7_Zipcode);
//listBoxInfo.Items.Add(InstanceInvoice.P8_City);
//listBoxInfo.Items.Add(InstanceInvoice.P9_Country);
//listBoxInfo.Items.Add(InstanceInvoice.P10_NumberOfItems);
//listBoxInfo.Items.Add(InstanceInvoice.P11_DescriptionItem);
//listBoxInfo.Items.Add(InstanceInvoice.P12_QuantityItem);
//listBoxInfo.Items.Add("Error, price item, double? - " + InstanceInvoice.P13_PriceItem);
//listBoxInfo.Items.Add(InstanceInvoice.P14_TaxItem);
//listBoxInfo.Items.Add(InstanceInvoice.P15_DescriptionItem2);
//listBoxInfo.Items.Add(InstanceInvoice.P16_QuantityItem2);
//listBoxInfo.Items.Add("Double? - " + InstanceInvoice.P17_PriceItem2);
//listBoxInfo.Items.Add(InstanceInvoice.P18_TaxItem2);
//listBoxInfo.Items.Add(InstanceInvoice.P19_SenderCompany);
//listBoxInfo.Items.Add(InstanceInvoice.P20_StreetSender);
//listBoxInfo.Items.Add(InstanceInvoice.P21_ZipcodeSender);
//listBoxInfo.Items.Add(InstanceInvoice.P22_CitySender);
//listBoxInfo.Items.Add(InstanceInvoice.P23_PhoneNumberSender);
//listBoxInfo.Items.Add(InstanceInvoice.P24_HomePageURLSender);
//listBoxInfo.Items.Add("Slut");





            //foreach (ItemClass obj in Invoice_Item_List)
            //{

            //    //MessageBox.Show(Invoice_Item_List[index].ToString());
            //    MessageBox.Show(obj.ID_Item.ToString() + "obj.id");
            //    //MessageBox.Show(airplaneObject.ID_Item + "airplaneObject ");
            //    if (obj.ID_Item == airplaneObject.ID_Item)
            //    {
            //        //MessageBox.Show(obj.ID_Item.ToString() + "obj.id");
            //        //MessageBox.Show(airplaneObject.ID_Item + "airplaneObject ");
            //        ////obj.otherProp = newValue;
            //        //obj.ItemC_DecriptionItem = txtBoxEditDescription.Text;
            //        //DataGrid_Items.ItemsSource = LoadCollectionData();
            //        //MessageBox.Show(obj.ItemC_DecriptionItem);
            //        break;
            //    }
            //}










//convertedPriceItem1 = double.Parse(InvoiceInstance.P13_PriceItem, System.Globalization.CultureInfo.InvariantCulture);

//ItemClass itemObject = new ItemClass();


////itemObject.ID_Item = 0;
//itemObject.ItemC_DecriptionItem = InvoiceInstance.P11_DescriptionItem;
//itemObject.ItemC_QuantityItem = InvoiceInstance.P12_QuantityItem;
//itemObject.ItemC_TaxItem = InvoiceInstance.P14_TaxItem;
//itemObject.ItemC_UnitPriceItem = InvoiceInstance.P13_PriceItem;
////itemObject.ItemC_UnitPriceItem = convertedPriceItem1;
////itemObject.ItemC_TotalPrice = convertedPriceItem1;

////Add item 1 to manager item list
//managerItem.AddNewInvoice(itemObject);
//MessageBox.Show(itemObject.GetPrice_TotalPrice().ToString());



//public string invoiceNumber;
//public string invoiceDate;
//public string duedate;
//public string CompanyDeliverer;
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



//public string senderCompany;
//public string streetSender;
//public string zipcodeSender;
//public string citySender;
//public string phoneNumberSender;
//public string homePageURLSender;
