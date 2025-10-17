using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NmqDay09LabCF.Models
{
    [Table("NmqLoai_San_Pham")]
    public class NmqLoai_San_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long nmqId { get; set; }

        [Display(Name = "Mã loại")]
        [StringLength(10)]

        public string nmqMaLoai { get; set; }
        [Display(Name = "Tên loại")]
        [StringLength(100)]
        public string nmqTenLoai { get; set; }

        [Display(Name = "Trạng thái")]
        public bool nmqTrangThai { get; set; }

        public ICollection<NmqSan_Pham> nmqSan_Phams { get; set; }
    }
}
