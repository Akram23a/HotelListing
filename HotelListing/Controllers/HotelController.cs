using AutoMapper;
using HotelListing.IRepository;
using HotelListing.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using HotelListing.Data;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels([FromQuery] RequestParams requestParams)
        {
            var hotels = await _unitOfWork.HotelsRepository.GetPagedList(null, requestParams);
            var results = _mapper.Map<IList<HotelDTO>>(hotels);
            return Ok(results);
           
        }

        [HttpGet("{id:int}", Name="GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            var hotel = await _unitOfWork.HotelsRepository.Get(q => q.Id == id, new List<string> { "Country" });
            var result = _mapper.Map<HotelDTO>(hotel);
            return Ok(result);
        }


        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDTO hotelDTO)
        {
            _logger.LogInformation($"Hotel Creation Attempt");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var hotel = _mapper.Map<Hotel>(hotelDTO);
            await _unitOfWork.HotelsRepository.Insert(hotel);

            await _unitOfWork.Save();
            return CreatedAtRoute("GetHotel", new { id = hotel.Id }, hotel);
        
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateHotel(int id, UpdateHotelDTO updateHotelDTO) {
            if (!ModelState.IsValid || id<1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateHotel)}");
                return BadRequest(ModelState);
            }
            var hotel = await _unitOfWork.HotelsRepository.Get(q => q.Id == id);
            if(hotel == null)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateHotel)}");
                return BadRequest("Submitteed data is invalid");
            }
            _mapper.Map(updateHotelDTO, hotel);
            _unitOfWork.HotelsRepository.Update(hotel);
            await _unitOfWork.Save();
            return NoContent();

        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Delete Attempt in {nameof(DeleteHotel)}");
                return BadRequest(ModelState);
            }

            var hotel = await _unitOfWork.HotelsRepository.Get(q => q.Id == id);
            if (hotel == null)
            {
                _logger.LogError($"Invalid Delete Attempt in {nameof(DeleteHotel)}");
                return BadRequest("Submitted ID is invalid");
            }
            await _unitOfWork.HotelsRepository.Delete(hotel.Id);
            await _unitOfWork.Save();
            return NoContent();

        }
    }
}