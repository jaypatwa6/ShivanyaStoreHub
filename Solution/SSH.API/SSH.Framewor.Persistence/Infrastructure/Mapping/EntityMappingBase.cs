using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSH.Framework.Model.EntityBase;
using System.Data.Entity.ModelConfiguration;

namespace SSH.Framework.Persistence.Infrastructure.Mapping
{
    public abstract class EntityMappingBase<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //// Common configuration for all entities (if any)
        }
    }

    public abstract class EntityMappingWithIdentity<TEntity, TIdentity> : EntityMappingBase<TEntity> where TEntity : Entity<TIdentity> where TIdentity : struct
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(o => o.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();
        }
    }


    public abstract class EntityMappingWithGuidIdentity<TEntity> : EntityMappingWithIdentity<TEntity, Guid> where TEntity : Entity<Guid>
    {
    }


    public abstract class EntityMappingWithLongIdentity<TEntity> : EntityMappingWithIdentity<TEntity, long> where TEntity : Entity<long>
    {
    }
}
