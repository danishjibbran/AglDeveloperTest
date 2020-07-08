using AglDeveloperTest.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AglDeveloperTest.Repositories
{
    public interface IPeopleRepository
    {
        List<People> GetPeople();
    }

    public class PeopleRepository: IPeopleRepository
    {
        IConfiguration _configuration;
        public PeopleRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public List<People> GetPeople()
        {
            var client = new RestClient(this._configuration.GetSection("AppSettings:PeopleServiceUrl").Value)
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            IRestResponse<List<People>> response = client.Execute<List<People>>(request);
            return response.Data;
        }
    }
}
