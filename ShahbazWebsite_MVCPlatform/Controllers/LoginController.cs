
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShahbazWebsite_MVCPlatform.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShahbazWebsite_MVCPlatform.Controllers
{
    public class LoginController : Controller
    {
        
        
         private readonly comp313MVCDatabaseContext _context;

         public LoginController(comp313MVCDatabaseContext context)
        {
            _context = context;
        }


        
        // Ruouting info:
        // Attribute routing
        // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing


        // DEFAULT PAGE FOR WEB APP, route set in Startup.cs

        // GET: http://localhost:port/
        // Coming in from browser world
        [HttpGet]
        public IActionResult Login()
        {

         
            // Check if already logged in, send to Home. If not, then send to Login view.

            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {

                //System.Diagnostics.Debug.WriteLine("Session: Login is True");

                return RedirectToAction("Index", "Employee");


            }

              if (TempData.ContainsKey(key: "TenantLogin"))
            {

                //System.Diagnostics.Debug.WriteLine("Session: Login is True");

                return RedirectToAction("Index", "Tenant");


            }

            else
            {
                //Not logged in: Send to Login view again
                return View();
            }

           

        }

        // POST: 
        // Coming in from the HTML Form
        [HttpPost]
        public IActionResult LoginPerformed(LoginModel model)
        {
            
            // DB Lookup

            var entered_Username = model.Username;
            var entered_Password = model.Password;

            var user =  _context.User.SingleOrDefault(u => u.Email == (entered_Username));
            //var user = _context.User.Where(u => u.User.UserId == 1);


             // If user Email is not in DB, back to login
             if (user == null)
                {
                    ViewData["Message"] = "Not found in DB";
                    
                    return RedirectToAction("Login", "Login");
                }

             // If pass is good, proceed
             if (user.Password == entered_Password)
                {

                        // Employee user goes to controller dealing with Employee
                        if (user.UserType == "Employee" || user.UserType == "employee")
                        {


                
                            // TempData used by other controllers for checking logged in state.
                            // NEXT: Switch to Session.
                            TempData["EmployeeLogin"] = "True";
                            TempData["EmployeeEmail"] = user.Email;
                            TempData["EmployeeID"] = user.UserId;


                            // SESSION ***
                            // Session set: Username + ID. So we can display it later in views.

                            var sessionUserName = user.Email;
                            const string SessionUsernameKey = "_Username";
                            HttpContext.Session.SetString(SessionUsernameKey, sessionUserName);

                            var sessionUserID = user.UserId;
                            const string SessionUserIDKey = "_UserID";
                            HttpContext.Session.SetInt32(SessionUserIDKey, sessionUserID);


                            return RedirectToAction("Index", "Employee");

                        }

                        // Tenant 
                        if (user.UserType == "Tenant" || user.UserType == "tenant")
                        {


                
                            // TempData used by other controllers for checking logged in state.
                            // NEXT: Switch to Session.
                            TempData["TenantLogin"] = "True";
                            TempData["TenantEmail"] = user.Email;
                            TempData["TenantID"] = user.UserId;


                            // SESSION ***
                            // Session set: Username + ID. So we can display it later in views.

                            var sessionUserName = user.Email;
                            const string SessionUsernameKey = "_Username";
                            HttpContext.Session.SetString(SessionUsernameKey, sessionUserName);

                            var sessionUserID = user.UserId;
                            const string SessionUserIDKey = "_UserID";
                            HttpContext.Session.SetInt32(SessionUserIDKey, sessionUserID);

                            return RedirectToAction("Index", "Tenant");

                        }

                }
            else
            {
                return RedirectToAction("Login", "Login");
            }

             return RedirectToAction("Login", "Login");

        }

        // GET: 
        // Coming in from <a> link in navbar
        [HttpGet]
        public IActionResult LogoutPerformed()
        {
            // Sign out of web app.
            // Remove state

            if (TempData.ContainsKey("EmployeeLogin"))
                {
                 TempData.Remove("EmployeeLogin");
                }

            if (TempData.ContainsKey("TenantLogin"))
            {
                 TempData.Remove("TenantLogin");
            }
           

            // Send to login.
            return RedirectToAction("Login", "Login");


       
        }



    }
}

