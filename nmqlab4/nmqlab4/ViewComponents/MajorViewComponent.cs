using Microsoft.AspNetCore.Mvc;
using nmqlab4.Data;
using nmqlab4.Models;

namespace nmqlab4.ViewComponents
{
    public class MajorViewComponent:ViewComponent
    {
        SchoolContext db;
        List<Major> majors;
        public MajorViewComponent(SchoolContext context)
        {
            db = context;
            majors = db.Majors.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderMajor",majors);
        }
    }
}
