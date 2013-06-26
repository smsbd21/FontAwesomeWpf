using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FontAwesome.WPF {
    public class IconExtension : MarkupExtension {

        public string ToolTip {
            get { return _control.ToolTip as string; }
            set { _control.ToolTip = value; }
        }

        IconBlock _control;

        public IconExtension(IconChar symbol) {
            _control = new IconBlock() { Icon = symbol };
        }
        
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return _control;            
        }
    }
}
