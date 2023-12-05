using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IFinalGalleryRepository
    {
        List<Finalgallery> GetAllGalleryItems();
        Finalgallery GetGalleryItemById(decimal galleryId);
        void CreateGalleryItem(Finalgallery galleryItem);
        void UpdateGalleryItem(Finalgallery galleryItem);
        void DeleteGalleryItem(decimal galleryId);
    }
}
