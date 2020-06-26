using System;
using System.Threading.Tasks;
using AutofacDemo.Models;

namespace AutofacDemo.Services.Impl
{
public class UserInterceptorServiceImpl : IUserInterceptorService<User>
{
    public async Task<User> AddUser(User user)
    {
        Console.WriteLine($"Add the user: {user.Name}");
        await Task.Delay(10);
        return user;
    }
}
}