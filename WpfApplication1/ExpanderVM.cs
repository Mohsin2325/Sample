using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class ExpanderVM
    {
        public CommandProperty<ExpanderVM> command;
        public string commandtext = "In ViewModel";
        public ExpanderVM()
        {
            command = new CommandProperty<ExpanderVM>(this);
        }
        public void Add()
        {

        }
    }
}
