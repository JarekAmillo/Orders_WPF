using Orders_WPF.Models.Domains;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Orders_WPF.Models.Configurations
{
    public class TypeOfTaskConfiguration : EntityTypeConfiguration<TypeOfTask>
    {

        public TypeOfTaskConfiguration()
        {
            ToTable("dbo.TypeOfTasks");

            //HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
