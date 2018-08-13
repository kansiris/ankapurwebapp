using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ankapur.repository;

namespace Ankapur.service
{
    public class LoginService
    {
        AnkapurRepository ankapurRepository = new AnkapurRepository();
        public static SqlDataReader GetUserProfile(int id)
        {
            return AnkapurRepository.getuserprofile(id);
        }

    }
}
