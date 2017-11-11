using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [DataContract (Name ="Employee")]
    public class Employee 
    {
        [DataMember(Name ="Id")]
       public int ID { get; set; }
        [DataMember (Name ="Name")]
       public string EmpName { get; set; }

        
    }
}
