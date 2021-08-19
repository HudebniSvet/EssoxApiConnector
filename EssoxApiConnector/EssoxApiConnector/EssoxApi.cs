﻿using EssoxApiConnector.ConnectionModels;
using EssoxApiConnector.Models.Request;
using EssoxApiConnector.Models.Response;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace EssoxApiConnector
{
    public class EssoxApi : IDisposable
    {
        private HttpClient client;
        private AbstractApiData apiData;

        public EssoxApi(AbstractApiData apiData)
        {
            this.client = new HttpClient();
            this.apiData = apiData;
        }

        public async Task<EssoxToken> GetToken()
        {
            var data = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            string Authorization = Tools.Base64Encode(apiData.AuthorizationString);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Authorization);
            client.DefaultRequestHeaders.Host = apiData.HostUrl;

            var requestMessage = client.DefaultRequestHeaders.ToString();

            var response = await client.PostAsync(apiData.TokenUrl, data);

            string result = await response.Content.ReadAsStringAsync();

            var values = JsonSerializer.Deserialize<EssoxToken>(result);
            //var val = values.GetValueOrDefault("access_token");
            return values;
        }

        public async Task<string> GetCalculator(object model)
        {
            string token = (await this.GetToken()).access_token;
            var json = JsonSerializer.Serialize(model);// new { price = 10_000, productId = 0 };
            var data = new StringContent(json, Encoding.UTF8, "application/json-patch+json");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync(apiData.CalculatorRequestUrl, data);

            string result = await response.Content.ReadAsStringAsync();

            var values = JsonSerializer.Deserialize<EssoxCalculatorResponse>(result);

            return values.redirectionUrl;
        }

        public async Task<EssoxProposalResponse> GetProposal(EssoxProposal model)
        {
            string token = (await this.GetToken()).access_token;

            string json = JsonSerializer.Serialize(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json-patch+json");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync(apiData.ProposalRequestUrl, data);

            string result = await response.Content.ReadAsStringAsync();

            var values = JsonSerializer.Deserialize<EssoxProposalResponse>(result);

            //Thread.Sleep(10000);
            var status = await GetStatus(values.contractId, token);

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

            string result = await response.Content.ReadAsStringAsync();

            var values = JsonSerializer.Deserialize<EssoxStatusResponse>(result);

            return values;
        }


        public void Dispose()
        {
            client.Dispose();
        }
    }
}