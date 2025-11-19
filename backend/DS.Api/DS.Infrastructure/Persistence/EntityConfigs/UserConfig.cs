namespace DS.Infrastructure.Persistence.EntityConfigs
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(256).IsRequired();
            builder.Property(x=>x.UserEmail).HasMaxLength(256).IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnType("nvarchar(max)").IsRequired(); 
            //builder.Property(x => x.Role).HasMaxLength(256).IsRequired(false);
        }
    }
}
