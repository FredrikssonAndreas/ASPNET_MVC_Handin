using Infrastructure.Models;

namespace WebApp.ViewModels
{
    public class AccountSavedItemsViewModel
    {
        public string Title { get; set; } = "Saved Courses";

        public CourseModel? Course { get; set; }

        public IEnumerable<CourseModel> Courses { get; set; } = [];

        public AccountBasic AccountBasic { get; set; } = new AccountBasic();
    }
}