using Microsoft.EntityFrameworkCore;

namespace NmqDay09LabCF.Models
{
    public class NmqDay09LabCFContext: DbContext
    {
        public NmqDay09LabCFContext(DbContextOptions<NmqDay09LabCFContext> options)
                : base(options) { }
        public DbSet<NmqLoai_San_Pham> tvcLoai_San_Phams { get; set; }
        public DbSet<NmqSan_Pham> tvcSan_Phams { get; set; }
    }
}
