﻿using Star_Wars_API_Lab_28.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Star_Wars_API_Lab_28
{
    public class StarWarsClient
    {
        private readonly HttpClient _client;

        public StarWarsClient(HttpClient client)

        {

            _client = client;
        }


        public async Task<PeopleResponseModel> GetPersonID(string id)

        {

            return await GetAsync<PeopleResponseModel>($"/api/people/1/{id}");
        }

        public async Task<PlanetResponseModel> GetPlanetID(string id)

        {

            return await GetAsync<PlanetResponseModel>($"/api/planets/1/{id}");
        }


        private async Task<T> GetAsync<T>(string endPoint)
        {
            
            var response = await _client.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                var model = await JsonSerializer.DeserializeAsync<T>(content);

                return model;
            }
            else
            {
                throw new HttpRequestException("Star Wars API returned bad response");
            }
        }
    }
}
