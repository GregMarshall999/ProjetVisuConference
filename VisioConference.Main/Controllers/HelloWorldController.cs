using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace VisioConference.Main.Controllers
{
    public class HelloWorldController : Controller
    {
        //GET: /HelloWorld
        public string Index()
        {
            return "This is my default action...";
        }

        //numTimes default is 1
        //GET: /HelloWorld/Welcome/
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is {numTimes}");
        }
    }
}
