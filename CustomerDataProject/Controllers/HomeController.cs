using CustomerDataProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

using System.Web;
using System.Configuration;
using Microsoft.SqlServer.Server;
using CustomerDataProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerDataProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcDbContext mvcDbContext;
    
        public HomeController( MvcDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CustomerInfo customerInfo)
        {


            var customer = new CustomerInfo()
            {
                Name = customerInfo.Name,
                Email = customerInfo.Email,
                Phone = customerInfo.Phone,
                ImageData = customerInfo.ImageData //ConvertDataUrlToByteArray(Convert.ToString(customerInfo.ImageData))

            };
             await mvcDbContext.CustomerDetails.AddAsync(customer);
             await mvcDbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Form submitted successfully!";
            return View();
        }


       //private byte[] ConvertDataUrlToByteArray(string dataUrl)
       // {
  
       //   //  if (dataUrl != "" && dataUrl != null)
       //   //  {
       //         // Extract the base64-encoded data from the data URL
       //         var base64Data = dataUrl.Split(',')[1];

       //         // Convert the base64 data to a byte array
       //         return Convert.FromBase64String(base64Data);
       //   //  }
         
       // }
        public IActionResult Privacy()
        {
            return View();
        } public async Task<IActionResult>Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Access");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}