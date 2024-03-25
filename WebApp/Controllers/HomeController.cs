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

	[HttpGet]

	public IActionResult UnSubscribe()
	{
		var viewModel = new UnSubscribeViewModel();
		return View(viewModel);
	}

	[HttpPost]

	public async Task<IActionResult> Unsubscribe(UnSubscribeViewModel unSubscribe)
	{
		if (ModelState.IsValid)
		{
			if (unSubscribe != null)
			{
				var unSub = new UnSubscribeModel
				{
					Email = unSubscribe.UnSubscribeModel!.Email,
					ConfirmBox = unSubscribe.UnSubscribeModel.ConfirmBox,
				};

				string apiUrl = $"https://localhost:7160/api/Subscriber/email?email={unSub.Email}";
				var response = await _httpClient.DeleteAsync(apiUrl);


				if (response.IsSuccessStatusCode)
				{
					TempData["Status"] = "Successfully Unsubscribed";
					return View(unSubscribe);
				}
				else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					TempData["StatusFail"] = "Your Email address was not found ,please try again";
					return RedirectToAction("Unsubscribe", "Home");
				}
				else
				{
					TempData["StatusFail"] = "Something went wrong with email or checkbox";
					return RedirectToAction("Unsubscribe", "Home");
				}
			}
			TempData["StatusFail"] = "You must enter a Email address";
			return RedirectToAction("Unsubscribe", "Home");
		}
		TempData["StatusFail"] = "Checkbox must be checked";
		return RedirectToAction("Unsubscribe", "Home");

	}
}

  