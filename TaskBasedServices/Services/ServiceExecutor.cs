using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;

namespace TaskBasedServices.Services
{
    public class ServiceExecutor
    {
        const string BaseAddress = "http://localhost:8080/Services/";

        public async Task GetAsync<TDto, TModel>(Action<TModel> expression)
        {
            var client = new WebClient();
            var serviceName = typeof(TDto).Name + ".ashx";
            var response = await client.DownloadStringTaskAsync(new Uri(BaseAddress + serviceName, UriKind.Absolute));
            var dto = JsonConvert.DeserializeObject<TDto>(response);
            expression.Invoke(Mapper.Map<TDto, TModel>(dto));
        }
    }
}