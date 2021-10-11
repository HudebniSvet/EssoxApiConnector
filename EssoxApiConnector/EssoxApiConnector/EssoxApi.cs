using EssoxApiConnector.ConnectionModels;
using EssoxApiConnector.Logic;
using EssoxApiConnector.Models.Request;
using EssoxApiConnector.Models.Response;
using System;
using System.Threading.Tasks;

namespace EssoxApiConnector
{
    /// <summary> Hlavní třída pro volání API metod </summary>
    public class EssoxApi : IDisposable
    {
        private EssoxLogic essoxLogic;

        public string LastResultString { get { return essoxLogic.LastResultString; } }

        /// <param name="apiData">Informace </param>
        public EssoxApi(AbstractApiData apiData)
        {
            this.essoxLogic = new EssoxLogic(apiData);
        }

        public async Task<EssoxToken> GetToken()
        {
            var output = await essoxLogic.GetToken();

            return output;
        }

        public async Task<EssoxCalculatorResponse> GetCalculator(EssoxCalculator model)
        {
            var output = await essoxLogic.GetCalculator(model);

            return output;
        }

        public async Task<EssoxProposalResponse> GetProposal(EssoxProposal model)
        {
            var output = await essoxLogic.GetProposal(model);

            return output;
        }

        public async Task<EssoxStatusResponse> GetStatus(int contractId)
        {
            var output = await essoxLogic.GetStatus(contractId);

            return output;
        }

        public async Task<EssoxStatusResponse> GetStatus(int contractId, string token)
        {
            var output = await essoxLogic.GetStatus(contractId, token);

            return output;
        }


        public void Dispose()
        {
            essoxLogic.Dispose();
        }
    }
}
