using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        private int userId;

        public int _userId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string loginName;

        public string _loginame
        {
            get { return loginName; }
            set { loginName = value; }
        }
        private string password;

        public string _password
        {
            get { return password; }
            set { password = value; }
        }

        private string firstName; 

        public string _fistName
        {
            get { return firstName; }
            set { firstName = value; }  
        }

        private string lastName;
        public string _lastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string position;

        public string _position
        {
            get { return position; }
            set { position = value; }
        }

        private string email;

        public string _email
        {
            get { return email; }
            set { email = value; }
        }


    }
}
