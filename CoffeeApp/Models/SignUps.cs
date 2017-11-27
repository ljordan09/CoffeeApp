using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeApp.Models
{
    public class SignUps
    {
        private string companyname;
        private string firstname;
        private string lastname;
        private string email;
        private string password;
        private string phone;
        private string zip;



        public SignUps() : this("", "", "", "", "", "", "")
        {

        }

        public SignUps(string companyname, string firstname, string lastname, string email, string password, string phone, string zip)
        {
            this.companyname = companyname;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.zip = zip;


        }

        [Required(ErrorMessage = "Name required")]//data annotation
        [RegularExpression("^[A-Za-z]$", ErrorMessage = "Must be letters")]
        public string CompanyName
        {
            set { companyname = value; }
            get { return companyname; }
        }

        [Required(ErrorMessage = "Name required")]//data annotation
        [RegularExpression("^[A-Za-z]$", ErrorMessage = "Must be letters")]
        public string FirstName
        {
            set { firstname = value; }
            get { return firstname; }
        }


        [Required(ErrorMessage = "Name required")]//data annotation
        public string LastName
        {
            set { lastname = value; }
            get { return lastname; }
        }

        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Must be a valid email. ")]
        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        public string Password
        {
            set { password = value; }
            get { return password; }
        }
        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }

        public string Zip
        {
            set { zip = value; }
            get { return zip; }
        }
    }
}