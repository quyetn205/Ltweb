using System.ComponentModel.DataAnnotations;

namespace nmqlab1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100, MinimumLength = 4,
       ErrorMessage = "Tên phải từ 4 đến 100 ký tự")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string? Email { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&.,;]).{8,}$",
            ErrorMessage = "Mật khẩu phải gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
        public string? Password { get; set; }
        [Display(Name = "Ngành học")]
        [Required(ErrorMessage = "Vui lòng chọn ngành học")]
        public Branch? Branch { get; set; }
        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }
        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1963", "12/31/2005")]
        public DateTime DateOfBorth { get; set; }
        [Display(Name = "Điểm số")]
        [Required(ErrorMessage = "Điểm không được để trống")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải từ 0.0 đến 10.0")]
        public double Score { get; set; }
        public string Avatar { get; set; }
    }
}
