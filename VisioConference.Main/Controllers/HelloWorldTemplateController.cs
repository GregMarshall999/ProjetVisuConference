using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace VisioConference.Main.Controllers
{
    public class HelloWorldTemplateController : Controller
    {
        //GET: /HelloWorldTemplate
        public string Index()
        {
            return "This is my default action...";
        }

        //GET: /HelloWorldTemplate/Welcome/
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        //numTimes default is 1
        //GET: /HelloWorldTemplate/Welcome?name=name&numtimes=numtimes
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is {numTimes}");
        }

        /*//GET: /HelloWorldTemplate/Welcome/3?name=Rick
        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }*/
    }
}
