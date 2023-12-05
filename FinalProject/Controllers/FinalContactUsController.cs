using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearningHub.Core.Data;
using LearningHub.Infra.Services;
using LearningHub.Core.Services;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalContactUsController : ControllerBase
    {
        private readonly IFinalContactUsService _finalContactUsService;

        public FinalContactUsController(IFinalContactUsService finalContactUsService)
        {
            _finalContactUsService = finalContactUsService;
        }

        [HttpGet]
        public List<Finalcontactu> RetrieveAllContacts()
        {
            return _finalContactUsService.RetrieveAllContacts();
        }

        [HttpGet]
        [Route("{contactUsId}")]
        public Finalcontactu FetchContactById(decimal contactUsId)
        {
            return _finalContactUsService.FetchContactById(contactUsId);
        }

        [HttpPost]
        public void AddContact(Finalcontactu contact)
        {
            _finalContactUsService.AddContact(contact);
        }

        [HttpPut]
        public void ModifyContact(Finalcontactu contact)
        {
            _finalContactUsService.ModifyContact(contact);
        }

        [HttpDelete]
        [Route("{contactUsId}")]
        public void RemoveContact(decimal contactUsId)
        {
            _finalContactUsService.RemoveContact(contactUsId);
        }
    }
}
