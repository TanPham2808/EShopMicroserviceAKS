
using EShop.Core.DTO;
using EShop.Core.Entities;
using EShop.Core.RepositoryContracts;

namespace EShop.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();

            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            return new ApplicationUser()
            {
                UserID = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName = "Person name",
                Gender = GenderOptions.Male.ToString()
            };
        }
    }
}
