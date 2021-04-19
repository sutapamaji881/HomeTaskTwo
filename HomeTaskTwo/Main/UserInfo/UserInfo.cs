using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTaskTwo.Main.UserInfo
{
   public class UserInfo
    {
        private String userEmail;
        private String password;

        public String GetUserEmail()
        {
            return userEmail;
        }

        internal void SetUserEmail(String userEmail)
        {
            this.userEmail = userEmail;
        }
        public String GetPassword()
        {
            return password;
        }

        public void SetPassword(String password)
        {
            this.password = password;
        }
   }
}
