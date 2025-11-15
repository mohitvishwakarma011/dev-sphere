namespace DS.Infrastructure.Persistence.EntityConfigs
{
    internal class SubCategoryConfig:IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.ToTable("Subcategory");
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.HasOne(x=>x.Category)
                .WithMany(c=>c.Subcategories)
                .HasForeignKey(x=>x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
