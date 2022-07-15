using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSProject
{
    public class UserLogin
    {
        public bool Login(int inputID, int realID)
        {
            if (inputID == realID)
            {
                return true;
            }
            else return false;
        }
    }
}
