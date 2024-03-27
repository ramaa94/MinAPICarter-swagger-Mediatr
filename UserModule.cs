using Carter;
using System.Threading;

namespace MyCarterApp
{
    public class UserModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           
            app.MapPost("/User/create", CreateUser);
            app.MapGet("/User/{id}", GetUserById);
            app.MapPut("/User/update/{id}", UpdateUser);
            app.MapDelete("/User/delete/{id}", DeleteUser);
        }

        private IResult CreateUser(User User, IUserRepository UsersRepo)
        {
            UsersRepo.CreateUser(User);
            return Results.StatusCode(201);
        }
        private async Task<IResult> GetUserById(int id, IUserRepository repo)
        {
            if (id <= 0) return Results.BadRequest();
            var user = await repo.GetUserAsync(id, CancellationToken.None);
            return Results.Ok(user);
        }
        private IResult UpdateUser(int id, User User, IUserRepository UserRepo)
        {
            UserRepo.UpdateUser(id, User);
            return Results.Ok();
        }
        private bool DeleteUser(int id, IUserRepository repo)
        {
            return repo.DeleteUser(id);
        }

    }   
}
   
    

