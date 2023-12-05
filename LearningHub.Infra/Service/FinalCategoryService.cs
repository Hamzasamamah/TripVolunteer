using LearningHub.Core.Data;
using LearningHub.Core.Services;
using LearningHub.Core.Repository;

namespace LearningHub.Infra.Services
{
    public class FinalCategoryService : IFinalCategoryService
    {
        private readonly IFinalCategoryRepository CategoryRepository;  // <-- Change type to IFinalCategoryRepository

        public FinalCategoryService(IFinalCategoryRepository categoryRepository)  // <-- Change parameter type to IFinalCategoryRepository
        {
            this.CategoryRepository = categoryRepository;
        }

        public List<Finalcategory> GetAllCategory()
        {
            return CategoryRepository.GetAllCategory();  // Adjusted method name if needed
        }

        public void CreateCategory(Finalcategory finalCategory)
        {
            CategoryRepository.CreateCategory(finalCategory);
        }

        public void UpdateCategory(Finalcategory finalCategory)
        {
            CategoryRepository.UpdateCategory(finalCategory);
        }

        public void DeleteCategory(int id)
        {
            CategoryRepository.DeleteCategory(id);
        }

        public Finalcategory GetCategoryById(int id)
        {
            return CategoryRepository.GetCategoryById(id);
        }
    }
}
