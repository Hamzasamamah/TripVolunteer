using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LearningHub.Core.Data;
using LearningHub.Infra.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalGalleryController : ControllerBase
    {
        private readonly IFinalGalleryService _finalGalleryService;

        public FinalGalleryController(IFinalGalleryService finalGalleryService)
        {
            _finalGalleryService = finalGalleryService;
        }

        [HttpGet]
        public List<Finalgallery> GetAllGalleryItems()
        {
            return _finalGalleryService.GetAllGalleryItems();
        }

        [HttpGet]
        [Route("{galleryId}")]
        public Finalgallery GetGalleryItemById(decimal galleryId)
        {
            return _finalGalleryService.GetGalleryItemById(galleryId);
        }

        [HttpPost]
        public void CreateGalleryItem(Finalgallery galleryItem)
        {
            _finalGalleryService.CreateGalleryItem(galleryItem);
        }

        [HttpPut]
        public void UpdateGalleryItem(Finalgallery galleryItem)
        {
            _finalGalleryService.UpdateGalleryItem(galleryItem);
        }

        [HttpDelete]
        [Route("{galleryId}")]
        public void DeleteGalleryItem(decimal galleryId)
        {
            _finalGalleryService.DeleteGalleryItem(galleryId);
        }

        // Additional routes and methods can be added as per requirements
    }
}
