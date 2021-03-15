using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeYesek
{
    public class Tarif
    {
        public string tarifAdı;
        public string tarifTürü;
        public string tarifYapılışı;
        
        public List<String> Malzemeler { get; set; }
    }
    public class Tarifler
    {
        public List<Tarif> TariflerListesi { get; set; }
    }
}
