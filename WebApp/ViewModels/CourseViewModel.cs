using Infrastructure.Models;

namespace WebApp.ViewModels;

public class CourseViewModel
{
	public string Title { get; set; } = "Courses";
	public CourseModel? Course { get; set; }
	public IEnumerable<CourseModel> Courses { get; set; } = [];


}
