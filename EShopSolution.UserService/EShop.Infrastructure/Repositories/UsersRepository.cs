﻿
using Dapper;
using EShop.Core.DTO;
using EShop.Core.Entities;
using EShop.Core.RepositoryContracts;
using EShop.Infrastructure.DbContext;

namespace EShop.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;

        public UsersRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();

            string query = @"
                INSERT INTO public.""Users"" 
                (""UserID"", ""Email"", ""PersonName"", ""Gender"", ""Password"") 
                VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";

            var parameters = new
            {
                user.UserID,
                user.Email,
                user.PersonName,
                user.Gender,
                user.Password
            };

            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

            return rowCountAffected > 0 ? user : null;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
            var parameters = new { Email = email, Password = password };

            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

            return user;
        }
    }
}
