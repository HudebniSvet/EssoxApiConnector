using EssoxApiConnector.ConnectionModels;
using EssoxApiConnector.Models.Request;
using EssoxApiConnector.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EssoxApiConnector.Logic
{
    internal class EssoxLogic : IDisposable
    {
        private AbstractApiData apiData;
        private HttpClient client;
        internal string LastResultString { get; set; }


        public EssoxLogic(AbstractApiData apiData)
        {
            this.apiData = apiData;
            this.client = new HttpClient();
        }



        public async Task<EssoxToken> GetToken()
        {
            var data = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            string Authorization = Tools.Base64Encode(apiData.AuthorizationString);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Authorization);
            client.DefaultRequestHeaders.Host = apiData.HostUrl;

            var requestMessage = client.DefaultRequestHeaders.ToString();

            var response = await client.PostAsync(apiData.TokenUrl, data);

            LastResultString = await response.Content.ReadAsStringAsync();

            var values = JsonSerializer.Deserialize<EssoxToken>(LastResultString);
            //var val = values.GetValueOrDefault("access_token");
            return values;
        }

        public async Task<EssoxCalculatorResponse> GetCalculator(EssoxCalculator model)
        {
            string token = (await this.GetToken()).access_token;
            var json = JsonSerializer.Serialize(model);// new { price = 10_000, productId = 0 };
            var data = new StringContent(json, Encoding.UTF8, "application/json-patch+json");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync(apiData.CalculatorRequestUrl, data);

            LastResultString = await response.Content.ReadAsStringAsync();

            var values = JsonSerializer.Deserialize<EssoxCalculatorResponse>(LastResultString);

            return values;
        }

        public async Task<EssoxProposalResponse> GetProposal(EssoxProposal model)
        {
            string token = (await this.GetToken()).access_token;

            string json = JsonSerializer.Serialize(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json-patch+json");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync(apiData.ProposalRequestUrl, data);

            LastResultString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                //var errorResponse = JsonSerializer.Deserialize<EssoxErrorResponse>(LastResultString);
            }
            else
            {

            }
            var values = JsonSerializer.Deserialize<EssoxProposalResponse>(LastResultString);

            //Thread.Sleep(10000);
            //Nelze volat status ihned
            //var status = await GetStatus(values.contractId, token);

            return values;
        }

        public async Task<EssoxStatusResponse> GetStatus(int contractId)
        {
            string token = (await this.GetToken()).access_token;
            return await GetStatus(contractId, token);
        }

        public async Task<EssoxStatusResponse> GetStatus(int contractId, string token)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync(apiData.StatusRequestUrl + "?ContractId=" + contractId);

            LastResultString = await response.Content.ReadAsStringAsync();

            var values = JsonSerializer.Deserialize<EssoxStatusResponse>(LastResultString);

            return values;
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
