using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.ViewModels;
using Infrastructure.Models;

namespace WebApp.Controllers;

public class HomeController(HttpClient httpClient) : Controller
{

    private readonly HttpClient _httpClient = httpClient;
    public IActionResult Index()
    {
        ViewData["Title"] = "Ultimate Task Management Assistent";

        return View();
    }

	[Route("/error")]
	[HttpGet]
	public IActionResult NotFound404()
	{
		var viewModel = new NotFoundViewModel();
		return View(viewModel);
	}

	[HttpPost]
	public IActionResult NotFound404(NotFoundViewModel viewmodel)
	{
		if (ModelState.IsValid)
		{
			return RedirectToAction("Index", "Home");
		}

		return View(viewmodel);
	}

    [HttpGet]
    public IActionResult Contact()
    {
        var viewModel = new ContactViewModel();
        return View(viewModel);
    }

	
    [HttpPost]
    public IActionResult Contact(ContactViewModel viewmodel)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Contact", "Home");
        }

        return View(viewmodel);
    }


	[HttpGet]
	public IActionResult Subscribe()
	{
		var viewModel = new SubscribeViewModel();
		return View(viewModel);
	}


	
	[HttpPost]
	public async Task<IActionResult> Subscribe(SubscribeViewModel viewModel)
	{
		
		if (ModelState.IsValid)
		{
			try
			{
				var newSub = new SubscribeEmail
				{
					Email = viewModel.SubscribeEmail!.Email,
					DailyNewsletter = viewModel.SubscribeEmail.DailyNewsletter,
					AdvertisingUpdates = viewModel.SubscribeEmail.AdvertisingUpdates,
					WeekinReview = viewModel.SubscribeEmail.WeekinReview,
					StartupsWeekly = viewModel.SubscribeEmail.StartupsWeekly,
					Podcasts = viewModel.SubscribeEmail.Podcasts,
					EventUpdates = viewModel.SubscribeEmail.EventUpdates,
				};
				if (newSub != null)
				{
					var json = JsonConvert.SerializeObject(newSub);

					if (json != null)
					{
						var content = new StringContent(json, Encoding.UTF8, "application/json");
						var response = await _httpClient.PostAsync("https://localhost:7160/api/subscriber?key=ZDg3YjM5ZDctZTE3NS00ZjE0LTliYWItNDlmYzc0NWE3NDhi", content);

						if (response.IsSuccessStatusCode)
						{
							ViewData["Status"] = "Success";
							
						}
						else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
						{
							ViewData["Status"] = "AlreadyExists.";
							
						}
					}					
				}
			}
			catch
			{
				ViewData["Status"] = "ConnectionFailed";
				
			}
		}
		else
		{
			ViewData["Status"] = "Failed";
			
		}
		return RedirectToAction("Index", "Home");
	}	
}

  