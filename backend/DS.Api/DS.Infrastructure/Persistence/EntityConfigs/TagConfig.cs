namespace DS.Infrastructure.Persistence.EntityConfigs
{
    internal class TagConfig:IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.Property(t => t.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(t=>t.Name).IsRequired().HasMaxLength(256);

        }
    }
}
