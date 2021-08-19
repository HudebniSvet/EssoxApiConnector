using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssoxApiConnector.Models.Request
{
    /// <summary>
    /// Parametry požadavku Calculator
    /// </summary>
    public class EssoxCalculator
    {
        /// <summary>
        /// Pořizovací cena financovaného předmětu (celé číslo)
        /// </summary>
        public int price { get; set; }

        /// <summary>
        /// Nastavení výchozí produktu při zobrazení v GUI (ID produktu Essox, dodává Essox)
        /// </summary>
        public int productId { get; set; }
    }
}
