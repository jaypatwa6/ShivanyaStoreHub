using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSH.Framework.Persistence.Infrastructure.Mapping;
using SSH.Module.Common.Domain.Entities.Master;

namespace SSH.Module.Common.Domain.Mapping.Master
{
    public class AccountMap : EntityMappingBase<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.ToTable("Account");
            builder.Property(x => x.AccountTypeID).HasColumnName("Account_TypeID");

            builder.HasOne(o => o.AccountType).WithMany()
                .HasForeignKey(a => a.AccountTypeID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
