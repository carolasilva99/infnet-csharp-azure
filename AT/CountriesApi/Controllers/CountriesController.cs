using AT.Domain;
using AutoMapper;
using CountriesApi.DTOs;
using CountriesApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CountriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesService _countriesService;

        public CountriesController(IMapper mapper, ICountriesService countriesService)
        {
            _mapper = mapper;
            _countriesService = countriesService;
        }

        // GET: api/<CountriesController>
        [HttpGet]
        public IEnumerable<string> List()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountriesController>
        [HttpPost]
        public ActionResult<Country> Post([FromBody] CreateCountryDto country)
        {
            var mappedCountry = _mapper.Map<Country>(country);
            var createdCountry = _countriesService.Create(mappedCountry);
            return CreatedAtAction(nameof(Get), new { id = createdCountry.Id}, createdCountry);
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
