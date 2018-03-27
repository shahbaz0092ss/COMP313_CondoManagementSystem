using System;

using System.Collections.Generic;


namespace ShahbazWebsite_MVCPlatform.Models

{

    public partial class User

    {

        public User()

        {

            Booking = new HashSet<Booking>();

            Maintenance = new HashSet<Maintenance>();

            Payment = new HashSet<Payment>();


        }



        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public string UserType { get; set; }

        public string Password { get; set; }




        public ICollection<Booking> Booking { get; set; }

        public ICollection<Maintenance> Maintenance { get; set; }

        public ICollection<Payment> Payment { get; set; }

    }

}