using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Sis.Mvc.Controllers
{
    public class FileController : Controller
    {
		[AllowAnonymous]
		public ActionResult Index()
		{
			var dir = new System.IO.DirectoryInfo("C://Files//"/*Server.MapPath("~/App_Data/Images/")*/);
			System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
			List<string> items = new List<string>();

			
			foreach (var file in fileNames)
			{
				items.Add(file.Name);
			}
			
			return View(items);
		}

		[AllowAnonymous]
		public FileResult Download(string FileName)
		{
			return File("C://Files//" + FileName, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
		}

		[HttpPost]
		public ActionResult Upload(HttpPostedFileBase file, string location)
		{
			try
			{
				if (file.ContentLength > 0)
				{
					var fileName = Path.GetFileName(file.FileName);
					var path = Path.Combine("C://Files//", fileName);
					file.SaveAs(path);
				}
				ViewBag.Message = "Upload successful";
				return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
			}
			catch
			{
				ViewBag.Message = "Upload failed";
				return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
			}
		}

		public ActionResult Remove(string FileName)
		{
			System.IO.File.Delete("C://Files//" + FileName);
			return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
		}
    }
}
