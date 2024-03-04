using System.Text.Json;

namespace SampleAspNetProject.Models
{
    public class Order
    {

        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = null!;
        public override string ToString()
        {
            return JsonSerializer.Serialize<Order>(this);
        }
    }
}
