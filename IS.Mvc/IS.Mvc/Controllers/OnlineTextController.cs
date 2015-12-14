using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS.Controllers
{
    public class OnlineTextController : Controller
    {
	    public static string Text { get; set; }

	    public ActionResult Index(string text)
        {
		    if (!string.IsNullOrEmpty(text))
		    {
			    Text = text;
		    }

			return View((object)Text);
        }

    }
}
