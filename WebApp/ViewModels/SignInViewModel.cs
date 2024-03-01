using Infrastructure.Models;

namespace WebApp.ViewModels;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign in";

    public SignInForm Form { get; set; } = new SignInForm();

}
