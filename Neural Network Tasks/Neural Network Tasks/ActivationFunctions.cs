using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_Tasks
{
    class ActivationFunctions
    {
        public int sign(double Y,int C1,int C2)
        {
            if (Y >= 0)
                return C1;
            return C2;
        }
    }
}
