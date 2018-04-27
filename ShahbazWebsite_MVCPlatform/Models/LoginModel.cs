// THIS MODEL USED FOR: Passing data from View:Login to Controller: Login

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShahbazWebsite_MVCPlatform.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="This field cannot be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage="This field cannot be empty")]
        public string Password { get; set; }

    }
}
