using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class AccountDelete
{
	public string Title { get; set; } = "Delete Account";

	[Display(Name = "Yes, I want to delete my account", Order = 0)]
	[Required(ErrorMessage = "You must check the box to delete the account")]
	[Range(typeof(bool), "true", "true", ErrorMessage = "You must check the box to delete the account")]
	public bool DeleteAccount { get; set; } = false;
}
