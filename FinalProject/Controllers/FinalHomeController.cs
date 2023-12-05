using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearningHub.Core.Data;
using LearningHub.Infra.Services;
using LearningHub.Core.Services;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalHomeController : ControllerBase
    {
        private readonly IFinalHomeService _finalHomeService;

        public FinalHomeController(IFinalHomeService finalHomeService)
        {
            _finalHomeService = finalHomeService;
        }

        [HttpGet]
        public List<Finalhome> GetAllHomes()
        {
            return _finalHomeService.GetAllHomes();
        }

        [HttpGet]
        [Route("{homeId}")]
        public Finalhome GetHomeById(decimal homeId)
        {
            return _finalHomeService.GetHomeById(homeId);
        }

        [HttpPost]
        public void InsertHome(string paragraph)
        {
            _finalHomeService.InsertHome(paragraph);
        }

        [HttpPut]
        [Route("{homeId}")]
        public void UpdateHome(decimal homeId, string paragraph)
        {
            _finalHomeService.UpdateHome(homeId, paragraph);
        }

        [HttpDelete]
        [Route("{homeId}")]
        public void DeleteHome(decimal homeId)
        {
            _finalHomeService.DeleteHome(homeId);
        }
    }
}
