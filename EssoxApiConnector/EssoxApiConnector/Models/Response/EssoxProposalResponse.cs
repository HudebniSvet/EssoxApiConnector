using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssoxApiConnector.Models.Response
{
    public class EssoxProposalResponse
    {
        /// <summary> Identifikace smlouvy</summary>
        public int contractId { get; set; }

        /// <summary> Adresa k přesměrování klienta </summary>
        public string redirectionUrl { get; set; }
    }
}
