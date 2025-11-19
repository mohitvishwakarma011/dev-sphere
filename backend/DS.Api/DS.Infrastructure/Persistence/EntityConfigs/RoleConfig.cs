namespace DS.Infrastructure.Persistence.EntityConfigs
{
    public class RoleConfig:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder) 
        {
            builder.ToTable("Role");
            builder.Property(x=>x.Name).HasMaxLength(50).IsRequired();
        }

    }
}
