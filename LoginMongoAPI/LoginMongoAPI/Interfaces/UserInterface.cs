using ErrorOr;
using LoginMongoAPI.Models;

namespace LoginMongoAPI.Interfaces
{
    public interface UserInterface
    {
        public Task<ErrorOr<User>> CreateUser(string name,
                                              string email,
                                              string username,
                                              string password);
        public Task<ErrorOr<User>> UpdateUser(string id,
                                              string name,
                                              string email,
                                              string username,
                                              string password);

        public Task<ErrorOr<string>> DeleteUser(string id);

        public Task<ErrorOr<User>> GetUser(string id);

        public Task<List<User>> GetAll();
    }
}
