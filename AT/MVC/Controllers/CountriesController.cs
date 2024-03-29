﻿using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Countries;
using MVC.Models.States;

namespace MVC.Controllers
{
    public class CountriesController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly string _url;
        // GET: CountriesController
        public CountriesController(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = configuration.GetSection("CountriesApiUrl").Value;
        }

        public async Task<ActionResult> Index()
        {
            var countries = await $"{_url}/countries"
                .GetJsonAsync<IEnumerable<CountryDto>>();

            return View(countries);
        }

        // GET: CountriesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var country = await $"{_url}/countries/{id}"
                .GetJsonAsync<CountryDto>();

            return View(country);
        }

        // GET: CountriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCountryDto createCountryDto)
        {
            try
            {
                var response = await $"{_url}/countries"
                    .PostJsonAsync(createCountryDto);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountriesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var country = await $"{_url}/countries/{id}"
                .GetJsonAsync<CreateCountryDto>();

            return View(country);
        }

        // POST: CountriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateCountryDto updateCountryDto)
        {
            try
            {
                var response = await $"{_url}/countries"
                    .PutJsonAsync(updateCountryDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountriesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var country = await $"{_url}/countries/{id}"
                .GetJsonAsync<CountryDto>();

            return View(country);
        }

        // POST: CountriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, CountryDto countryDto)
        {
            try
            {
                var country = await $"{_url}/countries/{id}"
                    .DeleteAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
