using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldSkills.Models;

namespace WorldSkills.Classes.Helpers
{
    internal class UserFind
    {
        public static Users FindUser(string phone, string password)
        {
            if(phone == null || password == null) return null;

            return DataBase.ConnectContext.Users.FirstOrDefault(x => x.Phone == phone && x.Password == password);
        }
    }
}
