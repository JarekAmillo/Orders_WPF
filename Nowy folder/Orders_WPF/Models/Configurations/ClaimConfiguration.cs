using Orders_WPF.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders_WPF.Models.Configurations
{
    public class ClaimConfiguration : EntityTypeConfiguration<Claim>
    {
        public ClaimConfiguration()
        {
            ToTable("dbo.Claims");

            HasKey(x => x.Id);

            Property(x => x.ClaimNumber)
                .HasMaxLength(12)
                .IsRequired();

            Property(x => x.TaskNumber)
            .HasMaxLength(12)
            .IsRequired();
        }
    }
}
