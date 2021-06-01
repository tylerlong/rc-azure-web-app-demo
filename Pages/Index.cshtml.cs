using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RingCentral;

namespace MyFirstAzureWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet()
        {
            var clientId = this.HttpContext.Request.Query["clientId"];
            var clientSecret = this.HttpContext.Request.Query["clientSecret"];
            var username = this.HttpContext.Request.Query["username"];
            var extension = this.HttpContext.Request.Query["extension"];
            var password = this.HttpContext.Request.Query["password"];
            var from = this.HttpContext.Request.Query["from"];
            var to = this.HttpContext.Request.Query["to"];
            Console.WriteLine(clientId + "" + clientSecret + "" + username + "" + extension + "" + password + "" + from + "" + to);

            var rc = new RestClient(clientId, clientSecret, true);
            try{
            await rc.Authorize(username, extension, password);
            Console.WriteLine(rc.token.access_token);

            await rc.Restapi().Account().Extension().Sms().Post(new CreateSMSMessage{
                text="Hello world from RingCentral hosted by Azure",
                from=new MessageStoreCallerInfoRequest{phoneNumber=from},
                to=new MessageStoreCallerInfoRequest[]{new MessageStoreCallerInfoRequest{phoneNumber=to}},
            });
            }catch(RestException re) {
                Console.WriteLine(Utils.FormatHttpMessage(re.httpResponseMessage, re.httpRequestMessage));
            }
        }
    }
}
