using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LearningHub.Core.Data;
using LearningHub.Infra.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalVolunteerController : ControllerBase
    {
        private readonly IFinalVolunteerService _finalVolunteerService;

        public FinalVolunteerController(IFinalVolunteerService finalVolunteerService)
        {
            _finalVolunteerService = finalVolunteerService;
        }

        [HttpGet]
        public List<Finalvolunteer> GetAllVolunteers()
        {
            return _finalVolunteerService.GetAllVolunteers();
        }

        [HttpGet]
        [Route("{volunteerId}")]
        public Finalvolunteer GetVolunteerById(decimal volunteerId)
        {
            return _finalVolunteerService.GetVolunteerById(volunteerId);
        }

        [HttpPost]
        public void CreateVolunteer(Finalvolunteer volunteer)
        {
            _finalVolunteerService.CreateVolunteer(volunteer);
        }

        [HttpPut]
        public void UpdateVolunteer(Finalvolunteer volunteer)
        {
            _finalVolunteerService.UpdateVolunteer(volunteer);
        }

        [HttpDelete]
        [Route("{volunteerId}")]
        public void DeleteVolunteer(decimal volunteerId)
        {
            _finalVolunteerService.DeleteVolunteer(volunteerId);
        }

        // You can add more routes as needed, for instance for image upload or other functionalities.
    }
}
