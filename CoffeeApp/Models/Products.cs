using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CoffeeApp.Models
{
    public class Products
    {
        private string bLht;
        private string bMed;
        private string bDrk;
        private string hLht;
        private string hMed;
        private string hDrk;
        private string cLht;
        private string cMed;
        private string cDrk;

        public Products() : this("", "", "", "", "", "", "", "", "")
        {



        }

        public Products(string bLht, string bMed, string bDrk, string hLht, string hMed, string hDrk, string cLht, string cMed, string cDrk)
        {
            this.bLht = bLht;
            this.bMed = bMed;
            this.bDrk = bDrk;
            this.hLht = hLht;
            this.hMed = hMed;
            this.hDrk = hDrk;
            this.cLht = cLht;
            this.cMed = cMed;
            this.cDrk = cDrk;
        }



        [Required(ErrorMessage = "Name required")]//data annotation
        [RegularExpression("^[A-Za-z]$", ErrorMessage = "Must be letters")]
        public string BLight
        {
            set { bLht = value; }
            get { return bLht; }
        }


        [Required(ErrorMessage = "Name required")]//data annotation
        public string BMedium
        {
            set { bMed = value; }
            get { return bMed; }
        }

        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Must be a valid email. ")]
        public string BDark
        {
            set { bDrk = value; }
            get { return bDrk; }

        }
        public string HLight
        {
            set { hLht = value; }
            get { return hLht; }
        }
        public string HMedium
        {
            set { hMed = value; }
            get { return hMed; }
        }

        public string HDark
        {
            set { hDrk = value; }
            get { return hDrk; }
        }

        public string CLight
        {
            set { cLht = value; }
            get { return cLht; }
        }

        public string CMedium
        {
            set { cMed = value; }
            get { return cMed; }
        }

        public string CDark
        {
            set { cDrk = value; }
            get { return cDrk; }
        }


    }
}