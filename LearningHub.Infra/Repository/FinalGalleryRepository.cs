using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalGalleryRepository : IFinalGalleryRepository
    {
        private readonly IDbContext _dbContext;

        public FinalGalleryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Finalgallery> GetAllGalleryItems()
        {
            IEnumerable<Finalgallery> result = _dbContext.Connection.Query<Finalgallery>(
                "FinalGallery_Package.GetAllGalleryItems",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public Finalgallery GetGalleryItemById(decimal galleryId)
        {
            var p = new DynamicParameters();
            p.Add("g_id", galleryId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Finalgallery> result = _dbContext.Connection.Query<Finalgallery>(
                "FinalGallery_Package.GetGalleryItemById",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public void CreateGalleryItem(Finalgallery galleryItem)
        {
            var p = new DynamicParameters();
            p.Add("t_id", galleryItem.Tripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("test_id", galleryItem.Testimonialid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("img_path", galleryItem.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalGallery_Package.Create_GalleryItem", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateGalleryItem(Finalgallery galleryItem)
        {
            var p = new DynamicParameters();
            p.Add("g_id", galleryItem.Galleryid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("t_id", galleryItem.Tripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("test_id", galleryItem.Testimonialid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("img_path", galleryItem.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalGallery_Package.Update_GalleryItem", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteGalleryItem(decimal galleryId)
        {
            var p = new DynamicParameters();
            p.Add("g_id", galleryId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalGallery_Package.DeleteGalleryItem", p, commandType: CommandType.StoredProcedure);
        }
    }
}
