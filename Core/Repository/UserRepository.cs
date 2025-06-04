using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Repository
{
    public class UserRepository : IRepository<User>
    {
        public Task<IEnumerable<User>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }



        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
