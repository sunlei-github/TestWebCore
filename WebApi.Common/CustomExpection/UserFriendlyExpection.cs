using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Common.CustomExpection
{
    public class UserFriendlyExpection : Exception
    {

        public UserFriendlyExpection(string title, string message)
            :base(message)
        {
            
        }
    }
}
