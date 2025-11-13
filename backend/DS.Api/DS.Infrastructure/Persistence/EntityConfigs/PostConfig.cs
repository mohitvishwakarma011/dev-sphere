namespace DS.Infrastructure.Persistence.EntityConfigs
{
    internal class PostConfig:IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Title).HasMaxLength(500).IsRequired();
            builder.Property(p=>p.Content).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p=>p.CreatedAt).HasColumnType("datetime2").IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p=>p.Category)
                .WithMany()
                .HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}    