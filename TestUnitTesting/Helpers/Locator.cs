using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class Locator
    {
        public static By GetTheBySelector(Enum controlName)
        {
            ReturnBySelector().TryGetValue(controlName, out By by);
            return by;
        }
        internal static Dictionary<Enum, By> ReturnBySelector()
        {
            return new Dictionary<Enum, By>()
            {
                {TextBox.Producto_Title,By.CssSelector("input[class='gLFyf gsfi']") },
                {Home.Contact_Header,By.Id("naviContact")},
                {Home.Management_Header,By.XPath("//*[@id='naviManagement']")},
                {Home.Products_Action,By.XPath("//*[@id='action-products']")},
                {Home.Providers_Action,By.Id("action-providers")},
                {Home.Users_Action,By.Id("action-users")},
                {Home.EntryNotes_Action,By.Id("action-entryNotes") },
                {Home.ExitNotes_Action,By.Id("action-exitNotes") },
                {Home.Contact_Action,By.Id("action-contacts") },
                {Contact.Message_Action,By.ClassName("fa-envelope") },
                {Contact.Name_Title,By.Id("name") },
                {Contact.Email_Title,By.Id("email") },
                {Contact.Message_Title,By.Id("message")},
                {Contact.Submit_Action,By.XPath("//*[@id='send-message']") },
                {Contact.Verify_Message, By.XPath("//td[contains(text(),'Jorge@gmail.com')]")},
                {Product.Search_TextBox, By.XPath("//input[@type='search']")},
                {Product.Product_Details,By.XPath("//td//a[contains(text(),'Detalles')]")},
                {Product.Product_Edit,By.XPath("//td//a[contains(text(),'Editar')]")},
                {Product.Product_Create,By.Id("create-product") },
                {Product.Product_Code, By.Id("Code") },
                {Product.Product_Name, By.Id("Name") },
                {Product.Product_Description, By.Id("Description") },
                {Product.Product_Stock, By.Id("Stock") },
                {Product.Product_PurchasePrice, By.Id("PurchasePrice") },
                {Product.Product_SalePrice, By.Id("SalePrice") },
                {Product.Product_MainImage, By.Id("MainImage") },
                {Product.Product_ExpirationTime, By.Id("ExpirationTime") },
                {Product.Product_Save, By.Id("save-product") },
                {Product.Product_Delete,By.Id("delete-product")},
                {Product.Product_Category,By.Id("action-category") },
                {Generic.Redirect_Back,By.XPath("//a[contains(text(),'Cancelar')]") },
                {Category.Category_Create,By.Id("create-category") },
                {Category.Category_Save,By.Id("save-category") },
                {Category.Category_Delete,By.Id("delete-category") },
                {Category.Category_Name, By.Id("Name") },//.card+a
                {Generic.Back_To_Home,By.XPath("//a[text()='Cancelar']") },
            };
        }
        public enum TextBox
        {
            Producto_Title,
        }
        public enum Generic
        {
            Redirect_Back,
            Back_To_Home
        }
        public enum Product
        {
            Product_Save,
            Product_Delete,
            Product_Details,
            Product_Edit,
            Product_Create,
            Product_Category,
            //TextBox
            Search_TextBox,
            //Data
            Product_Code,
            Product_Name,
            Product_Description,
            Product_Stock,
            Product_PurchasePrice,
            Product_SalePrice,
            Product_MainImage,
            Product_ExpirationTime,
            Product_UnitID,
            Product_CategoryID,
            Product_ProviderID,



        }
        public enum Category
        {
            Category_Create,
            Category_Save,
            Category_Delete,
            //Data
            Category_Name
        }
        public enum Home
        {
            //HEADER
            Contact_Header,
            Management_Header,
            //Management
            Users_Action,
            Products_Action,
            Providers_Action,
            EntryNotes_Action,
            ExitNotes_Action,
            Contact_Action,
        }
        public enum Contact
        {
            Message_Action,
            Name_Title,
            Email_Title,
            Message_Title,
            Submit_Action,
            Verify_Message
        }
        public enum Maps
        {

        }
        public enum Users
        {

        }
    }
}
