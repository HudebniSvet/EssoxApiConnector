using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssoxApiConnector.Models.Response
{
    public class EssoxStatusResponse
    {
        //TODO: Dodělat
        public List<businessCases> businessCases { get; set; }
        public List<errorCollection> errorCollection { get; set; }
    }


    public class businessCases
    {
        public string contractNumber { get; set; }
        public string proposalNumber { get; set; }
        public string degree { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string street { get; set; }
        public string houseNumber { get; set; }
        public string landNumber { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public decimal downPaymentRounded { get; set; }
        public int instalmentNumber { get; set; }
        public decimal instalmentIncludedInsuranceAndFee { get; set; }
        public string email { get; set; }
        public int contractStatusId { get; set; }
        public string contractStatus { get; set; }
        public int authorizationResultId { get; set; }
        public string authorizationResult { get; set; }
    }

    public class errorCollection
    {
        public string code { get; set; }
        public string text { get; set; }
    }
}
