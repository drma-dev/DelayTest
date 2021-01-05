using SharedDll;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DelayTest.Core
{
    public static class GamificationApi
    {
        public static string BaseApi(this HttpClient http) => http.BaseAddress.ToString().Contains("localhost") ? "http://localhost:7071/api/" : http.BaseAddress.ToString() + "api/";

        public async static Task<T> ReturnResponse<T>(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else
            {
                throw new Exception("");
            }
        }

        public async static Task<List<T>> GetList<T>(this HttpClient http, string requestUri) where T : class
        {
            var response = await http.GetAsync(http.BaseApi() + requestUri);

            return await response.ReturnResponse<List<T>>();
        }

        public async static Task<List<ProfileSearch>> Gamification_ListDestaques(this HttpClient http)
        {
            return await http.GetList<ProfileSearch>($"Gamification/ListDestaques");
        }
    }
}