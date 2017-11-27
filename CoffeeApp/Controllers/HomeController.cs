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

        public ActionResult UpdateInventory(string id)
        {
            CoffeeDBEntities3 ORM = new CoffeeDBEntities3();

            Item ItemChoice = ORM.Items.Find(id);

            if (ItemChoice != null)
            {
                ViewBag.ItemChoice = ItemChoice;
                return View();
            }

            return RedirectToAction("AdminList");

        }
        public ActionResult DeleteItem(string id)
        {
            CoffeeDBEntities3 ORM = new CoffeeDBEntities3();

            Item deleteItem = ORM.Items.Find(id);

            if (deleteItem != null)
            {
                ORM.Items.Remove(deleteItem);
                ORM.SaveChanges();
            }

            return RedirectToAction("AdminList");
        }
       





        
        //action to add inventory quantities
        //action to decrement inventory quantities
        //validate email addresses
        //Admin method

    }
}