using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using nmqlab1.Models;

namespace nmqlab1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student() { Id = 101, Name = "Hải Nam", Branch = Branch.IT,
                    Gender = Gender.Male, IsRegular=true,
                    Address = "A1-2018", Email = "nam@g.com",
                    Avatar = "/images/anh1.jfif"},
                new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
                    Gender = Gender.Female, IsRegular=true,
                    Address = "A1-2019", Email = "tu@g.com",
                    Avatar = null},
                new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
                    Gender = Gender.Male, IsRegular=false,
                    Address = "A1-2020", Email = "phong@g.com",
                    Avatar = null},
                new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
                    Gender = Gender.Female, IsRegular=false,
                    Address = "A1-2021", Email = "mai@g.com",
                    Avatar = null}
            };
        }
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //Lấy danh sách các giá trị Gender để hiển thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            //Lấy danh sách các giá trị Branch để hiển thị select-option trên form
            //Để hiển thị select-option trên View cần dùng List<SelectListItem>
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student s, IFormFile file)
        {
            // Kiểm tra xem có file được gửi lên và dung lượng lớn hơn 0
            if (file != null && file.Length > 0)
            {
                // 1. Định nghĩa thư mục lưu trữ: wwwroot/images
                // Đảm bảo thư mục "images" tồn tại trong wwwroot
                var imagePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "images");

                // 2. Tạo tên file duy nhất (để tránh trùng lặp)
                // Đây là ví dụ đơn giản, trong thực tế nên dùng GUID
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(imagePath, fileName);

                // 3. Lưu file vật lý vào Server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // 4. Lưu đường dẫn tương đối vào Model Student
                s.Avatar = $"/images/{fileName}";
            }

            s.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}
