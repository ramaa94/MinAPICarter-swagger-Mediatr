using Bogus;
using System;
using System.Collections.Generic;
namespace MyCarterApp

{
    public class UserRepository : IUserRepository
    {
        private  List<User> _users;

        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //_users = new List<User>();
            //GenerateSeedData();
            _users = new List<User>();
            _users.Add(new User { UserId = 1, UserName = "User1" });
            _users.Add(new User { UserId = 2, UserName = "User2" });

        }

        public bool CreateUser(User user)
        {
            if (user == null)
            {
                _logger.LogError("User object is null");
                return false;
            }

            // Simulate user ID generation (replace with actual logic)
            user.UserId = _users.Count + 1;

            _users.Add(user);
            return true;
        }

        public async Task<User?> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var user = _users.FirstOrDefault(u => u.UserId == id);
                return user;

            });

        }

        public bool UpdateUser(int id, User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.UserId == id);
            if (existingUser == null)
            {
                _logger.LogError($"User with ID {id} not found");
                return false;
            }

            existingUser.UserName = user.UserName;
            // Update other properties as needed

            return true;
        }

        public bool DeleteUser(int id)
        {
            var userToRemove = _users.FirstOrDefault(u => u.UserId == id);
            if (userToRemove == null)
            {
                _logger.LogError($"User with ID {id} not found");
                return false;
            }

            _users.Remove(userToRemove);
            return true;
        }



        //private void GenerateSeedData()
        //{
        //    _users = new Faker<User>()
        //        .RuleFor(p => p.UserId, p => p.IndexFaker)
        //        .RuleFor(p => p.UserName, p => p.Random.Words(2))
                
        //        .Generate(50);
        //}


    }
}

