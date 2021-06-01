using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MyFirstAzureWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var clientId = this.HttpContext.Request.Query["clientId"];
            var clientSecret = this.HttpContext.Request.Query["clientSecret"];
            var username = this.HttpContext.Request.Query["username"];
            var extension = this.HttpContext.Request.Query["extension"];
            var password = this.HttpContext.Request.Query["password"];
            var to = this.HttpContext.Request.Query["to"];
            Console.WriteLine(clientId + "" + clientSecret + "" + username + "" + extension + "" + password + "" + to);
        }
    }
}
