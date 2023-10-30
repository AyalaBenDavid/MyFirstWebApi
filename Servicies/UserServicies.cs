using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    public class UserServicies
    {
        UserRepository userRepository =new UserRepository();
        public Users GetUserByPasswordAndUserName(string password, string userName)
        {
            return userRepository.GetUserByPasswordAndUserName(password, userName);

        }
        public Users addUser(Users user)
        {
            if (check(user.Code) < 2)
                return null;

            return userRepository.addUser(user);
        }
        public Users updateUser(int id, Users user)
        {
            if (checked(user.Code) < 2)
                return null;
            return userRepository.updateUser(id, user);
        }

        public int check(string Code)
        {
            var result = Zxcvbn.Core.EvaluatePassword(Code);
            return result.Score;
        }
    }
