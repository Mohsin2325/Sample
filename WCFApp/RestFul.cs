using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFApp
{
    class RestFul : IRestFul
    {
        public string GetDetails()
        {
            return "Successful";
        }
    }
}
