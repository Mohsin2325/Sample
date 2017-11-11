using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    [DataContract (Name ="Employee")]
    public class Employee : INotifyPropertyChanged
    {
        [DataMember(Name ="Id")]
       public int ID { get; set; }
        [DataMember (Name ="Name")]
       public string EmpName { get; set; }

        private ExpanderVM _evm;

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string info)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public ExpanderVM evm {
            get
            {
                return _evm;
            }

            set
            {
                _evm = value;
                Notify("evm");
            }
                
                }
    }
}
