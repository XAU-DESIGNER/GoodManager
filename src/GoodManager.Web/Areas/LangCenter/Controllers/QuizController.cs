using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Areas.LangCenter.Controllers;

public class QuizController : LangCenterBaseController
{
	#region Index

	public IActionResult Index()
	{
		return View();
	}

	#endregion

	#region Create

	public IActionResult Create()
	{
		return View();
	}

	#endregion
}