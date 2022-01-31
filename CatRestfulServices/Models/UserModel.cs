using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatRestfulServices.Models
{
    public class UserModel
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username => FirstName+"."+LastName;
        public string Password { get; set; }
    }
}
