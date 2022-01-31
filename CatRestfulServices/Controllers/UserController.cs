using CatRestfulServices.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatRestfulServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IDictionary<int,UserModel> userInfo = new Dictionary<int,UserModel>();
        private int noOfUsers = 0;

        // POST api/<UserController>
        [HttpPost("registeruser")]
        public IActionResult UserRegistration([FromBody] UserRegistrationModel userRegistrationModel)
        {
            UserModel userModel = new UserModel();
            userModel.EmailAddress = userRegistrationModel.EmailAddress;
            userModel.FirstName = userRegistrationModel.FirstName;
            userModel.LastName = userRegistrationModel.LastName;
            userModel.Password = userRegistrationModel.Password;
            noOfUsers += 1;
            userInfo.Add(noOfUsers, userModel);
            
             return new OkObjectResult(new ResponseObject { message = 
                 "User created with EmailId: " + userRegistrationModel.EmailAddress 
                 + " and registration Id: " + noOfUsers });
            
        }

        // GET: api/<UserController>
        [HttpGet("{registrationId}")]
        public string Get(int registrationId)
        {
            string userResult = "{\"FirstName\":\"\",\"LastName\":\"\",\"UserName\":\"\",\"EmailAddress\":\"\"}";
            foreach (var user in userInfo)
            {
                if (user.Key == registrationId)
                {
                    userResult = "{\"RegistrationId\":\"" + user.Key + "\"," +
                        "\"FirstName\":\"" + user.Value.FirstName + "\"," +
                        "\"LastName\":\"" + user.Value.LastName + "\"," +
                        "\"UserName\":\"" + user.Value.Username + "\"," +
                        "\"EmailAddress\":\"" + user.Value.EmailAddress + "\"}";
                }
            }

            return userResult;
        }

    }
    public class ResponseObject
    {
        public string message { get; set; }
    }
}
