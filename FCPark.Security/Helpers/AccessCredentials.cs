using System;
using System.Collections.Generic;
using System.Text;

namespace FCPark.Security
{
    public class AccessCredentials
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string GrantType { get; set; }
    }
}
