using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Models
{
    public class User
    {
        [BsonId]
        public string? UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
