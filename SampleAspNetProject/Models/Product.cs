using System.Text.Json;

namespace SampleAspNetProject.Models
{
    public class Product
    {
        //Id defaults to the primary key, otherwise use the [Key] property
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float Price { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize<Product>(this);
        }
    }
}
