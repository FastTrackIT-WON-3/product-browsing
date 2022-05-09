namespace ProductBrowsing.Infrastructure.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryEntity Category { get; set; }
    }
}
