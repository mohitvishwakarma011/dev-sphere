namespace DS.Infrastructure.Persistence.EntityConfigs
{
    internal class ProfileConfig:IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");
            builder.HasKey(p=>p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.FullName).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Bio).HasMaxLength(256).IsRequired(false);
            builder.Property(p => p.ProfilePicUrl).IsRequired(false);

            builder.Property(p => p.JoinedDate).HasColumnType("datetime2").IsRequired();

            builder.HasOne<User>()
                .WithOne(u=>u.Profile)
                .HasForeignKey<Profile>(p=>p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
