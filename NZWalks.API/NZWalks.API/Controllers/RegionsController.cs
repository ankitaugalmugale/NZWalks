using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
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
    }
}
