using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NmqDay09LabCF.Models
{
    [Table("NmqSan_Pham")]
    public class NmqSan_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long nmqId { get; set; }
        public string nmqMaSanPham { get; set; }
        public string nmqTenSanPham { get; set; }
        public string nmqHinhAnh { get; set; }
        public int nmqSoLuong { get; set; }
        public decimal nmqDonGia { get; set; }
        public long nmqMaLoai { get; set; }

        public bool nmqTrangThai { get; set; }

        public NmqLoai_San_Pham NmqLoai_San_Pham { get; set; }
    }
}
