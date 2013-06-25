using Bja.Registro.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Registro.Modelo
{
    public class Rbac
    {
        public Boolean authenticate(String userName, String password)
        {
            Boolean result = false;
            //validar password

            var context = new BjaContext();

            var user = (from u in context.Users
                        where u.UserName == userName
                        select u).FirstOrDefault();

            if(user == null){
                result = false;
            }else {
                result = true;
            }

            return result;
        }

        //public Boolean isAuthorized(String userName, String permissionName)
        //{

        //}


    }
}
