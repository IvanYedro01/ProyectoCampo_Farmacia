using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;
using Services.Cache;


namespace Domain
{
    public class Usuario_BLL
    {

        static User_DATA mapper = new User_DATA();

        public void InsertUser(string loginName, string password, string firstName, string lastName, string position, string email)
        {
            mapper.Insert_User(loginName, password, firstName, lastName, position, email);
        }
        public bool LoginUser(string user, string pass)
        {
            return mapper.Login(user, pass);
        }

        public void AnyMethod()
        {
            if (UserLoginCache.position == Positions.Administrador)
            {

            }
            if (UserLoginCache.position == Positions.Vendedor)
            {

            }
            if (UserLoginCache.position==Positions.Cajero)
            {

            }
            if (UserLoginCache.position==Positions.Almacenista)
            {

            }
        }
    }

  
}