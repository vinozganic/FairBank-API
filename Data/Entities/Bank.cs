using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FairBankApi.Data.Entities
{
	public class Bank
	{
		public int Id { get; set; } 
        public string Name { get; set; }
        public string Swift { get; set; }
        public string Address { get; set; }
        public int UserAdminId { get; set; }

        public virtual User AdminUser { get; set; } //property koji sigurno nece bit u .jsonu requesta
    }

    public class BankConfigurationBuilder : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable(nameof(Bank));
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Swift).IsRequired();
            builder.Property(b => b.Address).IsRequired();
            builder.Property(b => b.UserAdminId).IsRequired();
            builder.HasOne(b => b.AdminUser).WithMany(u => u.Banks).HasForeignKey(b => b.UserAdminId);

            // Seed data
            builder.HasData(new Bank
            {
                Id = 1,
                Name = "Fair Bank",
                Address = "Unska 3, 10000 Zagreb",
                Swift = "SQB129I",
                UserAdminId = 1
            });
        }
    }
}

