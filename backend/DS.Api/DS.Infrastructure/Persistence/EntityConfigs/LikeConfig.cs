namespace DS.Infrastructure.Persistence.EntityConfigs
{
    internal class LikeConfig:IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Like");
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.HasOne<Post>()
                .WithMany(p=> p.Likes)
                .HasForeignKey(l=>l.PostId);

            builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(l => l.UserId);
        }
    }
}
