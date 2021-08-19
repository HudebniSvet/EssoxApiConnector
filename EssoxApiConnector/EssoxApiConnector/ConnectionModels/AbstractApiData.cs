using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssoxApiConnector.ConnectionModels
{
    /// <summary>
    /// TODO: Předělat pro načítání hodnot z configu
    /// </summary>
    public abstract class AbstractApiData
    {
        public abstract string HostUrl { get; set; }
        public abstract string TokenUrl { get; set; }

        public abstract string CalculatorRequestUrl { get; set; }
        public abstract string ProposalRequestUrl { get; set; }
        public abstract string StatusRequestUrl { get; set; }

        public string AuthorizationString { get { return User + ":" + Password; } }


        /// <summary>
        /// Consumer Key
        /// https://testdevelopers.essox.cz/store/site/pages/applications.jag
        /// </summary>
        public virtual string User { get; set; }
        /// <summary>
        /// Consumer Secret
        /// </summary>
        public virtual string Password { get; set; }
    }
}
