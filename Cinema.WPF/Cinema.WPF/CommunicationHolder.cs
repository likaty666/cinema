using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Cinema.WPF
{
    [ContentProperty("CommunicationDefs")]
    public class CommunicationHolder
    {
        private List<CommunicationDef> _communicationsDef = new List<CommunicationDef>();
        public List<CommunicationDef> CommunicationDefs
        {
            get { return _communicationsDef; }
            set
            {
                _communicationsDef.AddRange(value);
            }
        }
    }
}
