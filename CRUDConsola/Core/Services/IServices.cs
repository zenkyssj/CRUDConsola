using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDConsola.Core.Services
{
    internal interface IServices
    {
        void CreateUser();
        void ReadUser(int id);
        void UpdateUser(int id);
        void DeleteUser(int id);
      
    }
}
