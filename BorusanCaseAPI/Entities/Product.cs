using System.Text.Json.Serialization;

namespace Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        [JsonIgnore] public DateTime? CreatedDate { get; set; }
    }
}
