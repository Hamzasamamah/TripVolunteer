using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IFinalCategoryRepository
    {

        public List<Finalcategory> GetAllCategory();
        public void CreateCategory(Finalcategory finalCategory);
        public void UpdateCategory(Finalcategory finalCategory);
        public void DeleteCategory(int id);
        public Finalcategory GetCategoryById(int id);
    }
}
