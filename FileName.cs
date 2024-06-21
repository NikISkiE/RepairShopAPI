using System;
using System.Net.Http;
using System.Threading.Tasks;

public class MyWebServiceClient

{
    private readonly HttpClient _httpClient;
    public MyWebServiceClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("URL");
    }

    public async Task<string> GetResourceAsync(string resourcePath)
    {
        string result = null;
        HttpResponseMessage response = await _httpClient.GetAsync(resourcePath);
        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadAsStringAsync();
        }
        return result;
    }
}