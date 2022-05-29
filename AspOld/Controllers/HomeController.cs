using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using GrpcGreeterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspOld.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5050", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });

            var client = new Greeter.GreeterClient(channel);
            var response = await client.SayHelloAsync(new HelloRequest { Name = "OLD .NET" });

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}