using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        public IMapper Mapper;
        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this._regionRepository = regionRepository;
            Mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAll();
            //var regionDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(region =>
            //{
            //    var regionsDTO = new Models.DTO.Region()
            //    {
            //        Area = region.Area,
            //        Code = region.Code,
            //        id = region.id,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Name = region.Name,
            //        Population = region.Population,
            //    };
            //    regionDTO.Add(regionsDTO);
            //});

            var regionDTO = Mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionDTO);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegions(Guid id)
        {
            var region = await _regionRepository.GetAsync(id);  

            var regions = Mapper.Map<List<Models.DTO.Region>>(region);
            return Ok(regions);

        }

        [HttpPost]
        [ActionName("AddRegions")]
        public async Task<IActionResult> AddRegions(AddRegionRequest addRegionRequest)
        {
            var region = new Models.Domain.Region()
            {
                Area = addRegionRequest.Area,
                Code = addRegionRequest.Code,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population,
            };

            region = await _regionRepository.AddAsync(region);

            var regionDTO = new Models.DTO.Region()
            {
                Area= region.Area,
                Code    = region.Code,
                Lat= region.Lat,
                Long= region.Long,
                Name= region.Name,
                Population= region.Population,
            };
            return CreatedAtAction(nameof(AddRegions), new { id = regionDTO.id }, regionDTO);

        }
    }
}
