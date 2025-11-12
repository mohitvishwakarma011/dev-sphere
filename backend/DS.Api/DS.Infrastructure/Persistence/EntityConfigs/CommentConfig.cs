namespace DS.Infrastructure.Persistence.EntityConfigs
{
    internal class CommentConfig:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(e => e.Content).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.CreatedAt).HasColumnType("datetime2").IsRequired();

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Post)
                 .WithMany(p=>p.Comments)
                 .HasForeignKey(e => e.PostId);
        }
    }
}
