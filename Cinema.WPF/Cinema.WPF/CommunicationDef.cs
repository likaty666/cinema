using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Cinema.WPF
{
    public class CommunicationDef
    {
        public string SourceViewModel { get; set; }
        public string SourceProperty { get; set; }
        public string TargetViewModel { get; set; }
        public string TargetProperty { get; set; }
    }

    
    }
