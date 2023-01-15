using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarApp.Models
{
    public class Bar
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string OpeningTime { get; set; }

        public string ClosingTime { get; set; }
    }
}
