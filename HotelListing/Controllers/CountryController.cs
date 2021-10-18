using AutoMapper;
using HotelListing.Data;
using HotelListing.DTOs;
using HotelListing.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries([FromQuery] RequestParams requestParams)
        {
            var countries = await _unitOfWork.CountriesRepository.GetPagedList(null, requestParams);
            var results = _mapper.Map<IList<CountryDTO>>(countries);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name ="GetCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountry(int id)
        {
            var country = await _unitOfWork.CountriesRepository.Get(q => q.Id == id, new List<string> { "Hotels" });
            var result = _mapper.Map<CountryDTO>(country);
            return Ok(result);
         
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDTO countryDTO)
        {
            _logger.LogInformation($"Country Creation Attempt");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var country = _mapper.Map<Country>(countryDTO);
            await _unitOfWork.CountriesRepository.Insert(country);
            await _unitOfWork.Save();
            return CreatedAtRoute("GetCountry", new { id = country.Id }, country);
           
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCountry(int id, UpdateCountryDTO updateCountryDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateCountry)}");
                return BadRequest(ModelState);
            }
            var country = await _unitOfWork.CountriesRepository.Get(q => q.Id == id);
            if (country == null)
            {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateCountry)}");
                    return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(updateCountryDTO, country);
            _unitOfWork.CountriesRepository.Update(country);
            await _unitOfWork.Save();
            return NoContent();

            
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Delete Attempt in {nameof(DeleteCountry)}");
                return BadRequest(ModelState);
            }
   
                var country = await _unitOfWork.CountriesRepository.Get(q => q.Id == id);
            if (country == null)
            {
                _logger.LogError($"Invalid Delete Attempt in {nameof(DeleteCountry)}");
                return BadRequest("Submitted ID is invalid");
            }
            await _unitOfWork.CountriesRepository.Delete(country.Id);
            await _unitOfWork.Save();
            return NoContent();

        }

    }
}