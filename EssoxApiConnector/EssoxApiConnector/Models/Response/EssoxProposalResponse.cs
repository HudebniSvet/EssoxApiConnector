using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssoxApiConnector.Models.Response
{
    public class EssoxProposalResponse
    {
        /// <summary> Identifikace smlouvy. Pro zjištění stavu</summary>
        public int contractId { get; set; }

        /// <summary> Adresa k přesměrování klienta. Platnost 5 minut </summary>
        public string redirectionUrl { get; set; }
    }
}
