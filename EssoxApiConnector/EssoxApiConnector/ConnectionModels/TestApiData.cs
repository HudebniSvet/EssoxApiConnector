using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssoxApiConnector.ConnectionModels
{

    public class TestApiData : AbstractApiData
    {
        public TestApiData(string user, string pw)
        {
            base.User = user;
            base.Password = pw;
        }

        public override string HostUrl { get; set; } = "testapi.essox.cz";
        public override string TokenUrl { get; set; } = "https://testapi.essox.cz/token";

        public override string CalculatorRequestUrl { get; set; } = "https://testapi.essox.cz/consumergoods/v1/api/consumergoods/calculator";
        public override string ProposalRequestUrl { get; set; } = "https://testapi.essox.cz/consumergoods/v1/api/consumergoods/proposal";
        public override string StatusRequestUrl { get; set; } = "https://testapi.essox.cz/consumergoods/v1/api/consumergoods/status";

    }
}
