using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using CoffeeApp.Models;//don't forget to add




namespace CoffeeApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Please fill in the form:";

            return View();
        }
        public ActionResult SaveUser(User NewUserRecord)
        {
          
            if (ModelState.IsValid)
            {
                //2.add the new record to the ORM, save changes to DB
                CoffeeDBEntities1 ORM = new CoffeeDBEntities1();
                ORM.Users.Add(NewUserRecord);
                ORM.SaveChanges();

                //3. showing the list of all the customers

                return RedirectToAction("DisplayName");

            }
            else
            {
                //If validation fails
                //go back to the form and show the list of errors
                return View("Register");
            }
        }

        public ActionResult DisplayName(SignUps NewSignUp)
        {

            ViewBag.Name = NewSignUp.FirstName;
            return View();
        }

        public ActionResult AdminList()
        {
            CoffeeDBEntities3 ORM = new CoffeeDBEntities3();

            List<Item> OutputList = ORM.Items.ToList();

            ViewBag.OutputList = OutputList;

            return View();
        }

        public ActionResult UpdateInventory(string ProductID)
        {
            CoffeeDBEntities3 ORM = new CoffeeDBEntities3();

            Item RecordToBeUpdated = ORM.Items.Find(ProductID);

            if (RecordToBeUpdated != null)
            {
                ViewBag.RecordToBeUpdated = RecordToBeUpdated;
                return View("UpdateInventory");
            }
            else
            {
                return RedirectToAction("AdminList");
            }

            

        }

        public ActionResult SaveUpdatedItem(Item RecordToBeUpdated)
        {
            //Todo: validation and exception Handling
            //1.Find the original record
            CoffeeDBEntities3 ORM = new CoffeeDBEntities3();
            Item temp = ORM.Items.Find(RecordToBeUpdated.ProductID);

            //2.Do the update on that record, then save to the database
            temp.Name = RecordToBeUpdated.Name;
            temp.Type = RecordToBeUpdated.Type;
            temp.Quantity = RecordToBeUpdated.Quantity;
            temp.Price = RecordToBeUpdated.Price;


            ORM.Entry(temp).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();//saves to DB

            //3.Load all customer records
            return RedirectToAction("AdminList");
        }
        public ActionResult DeleteItem(string ProductID)
        {
            CoffeeDBEntities3 ORM = new CoffeeDBEntities3();

            Item deleteItem = ORM.Items.Find(ProductID);

            if (deleteItem != null)
            {
                ORM.Items.Remove(deleteItem);
                ORM.SaveChanges();
            }

            return RedirectToAction("AdminList");
        }
         
        public ActionResult Inventory()
        {
            return View("AddInventory");
        }
        public ActionResult AddInventory(Item newItem)
        {
            if (ModelState.IsValid)
            {
                CoffeeDBEntities3 ORM = new CoffeeDBEntities3();
                    
                List<Item> items = new List<Item>();
                items = (from i in ORM.Items
                         where i.ProductID == newItem.ProductID
                         select i).ToList();    

                if (items.Count == 0)
                {
                    ORM.Items.Add(newItem);
                    ORM.SaveChanges();

                    return RedirectToAction("AdminList");
                }
                else
                {
                    ViewBag.ProductName = newItem.ProductID;
                    return View();
                }
            }
            else
            {
                return View("AddInventory");
            }
        }

        //public ActionResult ItemAddForm()
        //{
        //    return View();
        //}



        //action to add inventory quantities
        //action to decrement inventory quantities
        //validate email addresses
        //Admin method

    }
}