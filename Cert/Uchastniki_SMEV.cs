using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cert
{
    public class Uchastniki_SMEV
    {
        public int Id { get; set; }
        public string Polnoe_naimenovanie_Uchastnika {get;set;}
        public string Kratkoe_naimenovanie_Uchastnika { get; set; }
        public string OGRN { get; set; }
        public int Tip_Uchastnika { get; set; }
        public string Mnemonika_Uchastnika_v_SMEV3 { get; set; }
        public string Polnoe_naimenovanie_IS { get; set; }
        public string Kratkoe_naimenovanie_IS { get; set; }
        public string Mnemonika_IS_v_SMEV3 { get; set; }
    }
}
