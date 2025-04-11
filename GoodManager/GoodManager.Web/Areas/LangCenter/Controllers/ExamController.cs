using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Areas.LangCenter.Controllers;

public class ExamController : LangCenterBaseController
{
	#region Index

	public IActionResult Index()
	{
		return View();
	}

	#endregion
}