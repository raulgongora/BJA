using Bja.Entidades;
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
        BjaContext context = new BjaContext();

        public Boolean authenticate(String userName, String password)
        {
            Boolean result = false;
            String hashedPassword = password.GetHashCode().ToString("x");
            //validar password

            context = new BjaContext();

            var user = (from u in context.Users
                        where u.UserName == userName
                        && u.Password == hashedPassword
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

        public void insertUser(String userName, String completeName , String password, long userID )
        {
            var newUser = new User();

            newUser.Id = IdentifierGenerator.NewId();
            newUser.IdInstance = newUser.Id;
            newUser.UserName = userName;
            newUser.CompleteName = completeName;
            newUser.Password = password.GetHashCode().ToString("x");
            newUser.IdUserRelation = userID;

            context.Users.Add(newUser);

            context.SaveChanges();
        }


    }
}
