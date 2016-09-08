using System.Collections.Generic;
using WebApiDemo.Models;

namespace WebApiDemo.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetById(int id);
    }
}