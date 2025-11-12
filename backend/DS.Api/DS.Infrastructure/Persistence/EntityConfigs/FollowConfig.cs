namespace DS.Infrastructure.Persistence.EntityConfigs
{
    internal class FollowConfig:IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.ToTable("Follow");
            builder.HasKey(f => new { f.FollowerId, f.FollowingId });
        }
    }
}
