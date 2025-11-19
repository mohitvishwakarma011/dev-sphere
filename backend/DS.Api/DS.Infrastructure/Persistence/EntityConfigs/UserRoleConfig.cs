namespace DS.Infrastructure.Persistence.EntityConfigs
{
    public class UserRoleConfig:IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(x=>new {x.UserId, x.RoleId});

            builder.HasOne(ur=>ur.User)
                .WithMany(u=>u.UserRoles)
                .HasForeignKey(u=>u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
