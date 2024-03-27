namespace MyCarterApp
{
    public interface IUserRepository
    {
        bool CreateUser(User User);
        Task<User> GetUserAsync(int id, CancellationToken cancellationToken);
        bool UpdateUser(int id, User User);
        bool DeleteUser(int id);
    }
}
