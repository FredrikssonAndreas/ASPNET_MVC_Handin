using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class AccountDelete
{
	public string Title { get; set; } = "Delete Account";

	public string ConfirmDelete { get; set; } = "Yes, I want to delete my account.";

	public string Description { get; set; } = "When you delete your account, your public profile will be deactivated immediately. If you change your mind before the 14 days are up, sign in with your email and password, and we’ll send you a link to reactivate your account.";

	[Display(Name = "Yes, I want to delete my account", Order = 0)]
	[Required(ErrorMessage = "You must check the box to delete the account")]
	[Range(typeof(bool), "true", "true", ErrorMessage = "You must check the box to delete the account")]
	public bool DeleteAccount { get; set; } = false;
}
