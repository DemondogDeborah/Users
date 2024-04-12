using LoginMongoAPI.Models;
using MongoDB.Driver;

namespace TodoApiMongo.StaticClasses
{
    public class DBCollections
    {
        private static MongoClient client = new MongoClient("mongodb://localhost:27017");
        private static IMongoDatabase database = client.GetDatabase("Users");

        public static IMongoCollection<User> userCollection = database.GetCollection<User>("Users");
    }
}
