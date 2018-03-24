using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CondoManagementMVCcoreApplication.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CondoManagementMVCapplication.Controllers
{
    public class LoginController : Controller
    {
        // Ruouting info:
        // Attribute routing
        // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing


        // DEFAULT PAGE FOR WEB APP, IN CONFIG SETTINGS.
        // GET: http://localhost:port/login
        // Coming in from browser world
        [HttpGet]
        public IActionResult Login()
        {

            // ***TO IMPLEMENT
            // Check if already logged in, send to Home. If not, then send to Login view.

            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {

                //System.Diagnostics.Debug.WriteLine("Session: Login is True");

                return RedirectToAction("Index", "Employee");


            }

            else
            {
                return View();
            }

            //Not logged in: Send to Login view
            //By default: LoginController.Login() maps to the Login.cshtml view

            // return View();

        }

        // POST: 
        // Coming in from the HTML Form
        [HttpPost]
        public IActionResult LoginPerformed(LoginModel model)
        {
            //IF EMPLOYEE

            if (model.Username == "employee")
            {
                // ConnectToDB and Check if Model.Username and Model.Password exist as Employee
                // If YES
                // Then set state and allow login as Employee
                // Send to Employee controller

                TempData["EmployeeLogin"] = "True";
                return RedirectToAction("Index", "Employee");
            }

            //IF TENANT

            if (model.Username == "tenant")
            {
                // ConnectToDB and Check if Model.Username and Model.Password exist as Tenant
                // If YES
                // Then set state and allow login as Tenant
                // Send to Tenant controller
                // Send to Action -> Index() in Controller -> Tenant

                TempData["TenantLogin"] = "True";
                return RedirectToAction("Index", "Tenant");
            }

            else
            {
                return RedirectToAction("Login", "Login");
            }





        }

        // GET: 
        // Coming in from <a> link in navbar
        [HttpGet]
        public IActionResult LogoutPerformed()
        {
            // Sign out of web app.
            // Remove state
            TempData.Remove("EmployeeLogin");


            // Send to login.
            return RedirectToAction("Login", "Login");


            // ********************** NEXT ******************
            // Check if Emloyee or Tenant

            //if (TempData.ContainsKey("EmployeeLogin"))
            //{
            //    TempData.Remove("EmployeeLogin");
            //    return RedirectToAction("Login", "Login");
            //}

            //if (TempData.ContainsKey("TenantLogin"))
            //{
            //    TempData.Remove("TenantLogin");
            //    return RedirectToAction("Login", "Login");
            //}
        }



    }
}

