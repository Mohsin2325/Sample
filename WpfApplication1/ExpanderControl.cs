using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApplication1
{
    public class ExpanderControl : Expander
    {
        public static readonly DependencyProperty CommandProp = DependencyProperty.Register("Command", typeof(ICommand), typeof(ExpanderControl),null);
        public ExpanderControl() { }
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProp); }
            set { SetValue(CommandProp, value); }

        }
        
    }
}
