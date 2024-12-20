using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace NakayamaPJ.Model
{
    public interface IUserRepository
    {
        bool AutheticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Update(UserModel userModel);
        void Delete(UserModel userModel);
        void Remove(int Id);
        UserModel GetById(int Id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetByAll();
    }
}
