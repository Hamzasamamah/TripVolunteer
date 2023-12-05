using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;

namespace LearningHub.Core.Services
{
    public interface IFinalCategoryService
    {
        public List<Finalcategory> GetAllCategory();
        public void CreateCategory(Finalcategory finalCategory);
        public void UpdateCategory(Finalcategory finalCategory);
        public void DeleteCategory(int id);
        public Finalcategory GetCategoryById(int id);
    }
}
