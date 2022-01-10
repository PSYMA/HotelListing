using AutoMapper;
using Hotel_Listing.Models;
using Hotel_Listing.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Listing.Controllers {
    [Route("api")]
    [ApiController]
    public class CountryController : ControllerBase {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]/GetCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries() {
            try {
                var countries = await _unitOfWork.Countries.GetAll();
                var results = _mapper.Map<IList<CountryModel>>(countries);
                return Ok(results);

            }
            catch (Exception e) {
                _logger.LogError(e, $"Something went wrong in the {nameof(GetCountries)}");
                return StatusCode(500, "Internal Server Error, Please try again later.");
            }
        }

        [HttpGet]
        [Route("[controller]/GetCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountry([Required] int id) {
            try {
                var country = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels" });
                var result = _mapper.Map<CountryModel>(country);
                return Ok(result);

            }
            catch (Exception e) {
                _logger.LogError(e, $"Something went wrong in the {nameof(GetCountry)}");
                return StatusCode(500, "Internal Server Error, Please try again later.");
            }
        }
    }
}
