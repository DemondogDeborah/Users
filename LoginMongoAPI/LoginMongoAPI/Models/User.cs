using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;

namespace LoginMongoAPI.Models
{
    [CollectionName("users")]
    public class User //: MongoIdentityUser<Guid>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
       
        [BsonElement("Name")]
        public string? Name { get; set; }

        [BsonElement("Email")]
        public string? Email { get; set; }

        [BsonElement("Username")]
        public string? Username { get; set; }

        [BsonElement("Password")]
        public string? Password { get; set; }
    }
   
}
