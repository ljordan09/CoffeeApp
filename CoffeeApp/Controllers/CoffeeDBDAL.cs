using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeeApp.Models;

namespace CoffeeApp.Controllers
{
    public class CoffeeDBDAL
    {
        private CoffeeDBEntities3 ORM = new CoffeeDBEntities3();

        public List<Item> GetAllItems()
        {
            List<Item> ItemList = ORM.Items.ToList();

            return ItemList;
        }

        

    }
}