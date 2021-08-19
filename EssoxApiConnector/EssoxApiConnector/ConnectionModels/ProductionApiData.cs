using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssoxApiConnector.ConnectionModels
{
    /// <summary>
    /// Pro využití této třídy ji overridněte a nastavte User&Password
    /// </summary>
    public class ProductionApiData : AbstractApiData
    {
        public override string HostUrl { get; set; } = "api.essox.cz";
        public override string TokenUrl { get; set; } = "https://api.essox.cz/token";

        public override string CalculatorRequestUrl { get; set; } = "https://api.essox.cz/consumergoods/v1/api/consumergoods/calculator";
        public override string ProposalRequestUrl { get; set; } = "https://api.essox.cz/consumergoods/v1/api/consumergoods/proposal";
        public override string StatusRequestUrl { get; set; } = "https://api.essox.cz/consumergoods/v1/api/consumergoods/status";

    }
}
