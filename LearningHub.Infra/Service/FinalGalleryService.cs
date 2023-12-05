using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LearningHub.Infra.Services
{
    public class FinalGalleryService : IFinalGalleryService
    {
        private readonly IFinalGalleryRepository _finalGalleryRepository;

        public FinalGalleryService(IFinalGalleryRepository finalGalleryRepository)
        {
            _finalGalleryRepository = finalGalleryRepository;
        }

        public List<Finalgallery> GetAllGalleryItems()
        {
            return _finalGalleryRepository.GetAllGalleryItems();
        }

        public void CreateGalleryItem(Finalgallery galleryItem)
        {
            // Any additional business logic before creating a gallery item
            _finalGalleryRepository.CreateGalleryItem(galleryItem);
        }

        public void UpdateGalleryItem(Finalgallery galleryItem)
        {
            // Any additional business logic before updating a gallery item
            _finalGalleryRepository.UpdateGalleryItem(galleryItem);
        }

        public void DeleteGalleryItem(decimal galleryId)
        {
            // Any additional business logic before deleting a gallery item
            _finalGalleryRepository.DeleteGalleryItem(galleryId);
        }

        public Finalgallery GetGalleryItemById(decimal galleryId)
        {
            return _finalGalleryRepository.GetGalleryItemById(galleryId);
        }
    }
}
