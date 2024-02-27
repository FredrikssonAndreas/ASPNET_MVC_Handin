using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class AccountAddress
{
	public string Title { get; set; } = "Address";

	[Display(Name = "Adress line 1", Prompt = "Enter your adress", Order = 0)]
	public string AdressLine1 { get; set; } = null!;
	
	[Display(Name = "Adress line 2", Prompt = "Enter your second adress", Order = 1)]
	public string? AdressLine2 { get; set; }

	[Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 2)]
	public string PostalCode { get; set; } = null!;

	[Display(Name = "City", Prompt = "Enter your city", Order = 3)]
	public string City { get; set; } = null!;

}
