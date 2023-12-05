using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LearningHub.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public interface IFinalGalleryService
    {
        List<Finalgallery> GetAllGalleryItems();
        void CreateGalleryItem(Finalgallery galleryItem);
        void UpdateGalleryItem(Finalgallery galleryItem);
        void DeleteGalleryItem(decimal galleryId);
        Finalgallery GetGalleryItemById(decimal galleryId);
    }
}
