using Microsoft.AspNetCore.Mvc;
using LearningHub.Core.Data;
using LearningHub.Core.Services;
using System.Collections.Generic;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalCategoryController : ControllerBase
    {
        private readonly IFinalCategoryService _finalCategoryService;

        public FinalCategoryController(IFinalCategoryService finalCategoryService)
        {
            _finalCategoryService = finalCategoryService;
        }

        // GET: api/FinalCategory
        [HttpGet]
        public ActionResult<IEnumerable<Finalcategory>> GetAllCategories()
        {
            return Ok(_finalCategoryService.GetAllCategory());
        }

        // GET: api/FinalCategory/5
        [HttpGet("{id}")]
        public ActionResult<Finalcategory> GetCategoryById(int id)
        {
            var category = _finalCategoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/FinalCategory
        [HttpPost]
        public ActionResult CreateCategory([FromBody] Finalcategory finalCategory)
        {
            _finalCategoryService.CreateCategory(finalCategory);
            return CreatedAtAction(nameof(GetCategoryById), new { id = finalCategory.Categoryid }, finalCategory);
        }

        // PUT: api/FinalCategory/5
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] Finalcategory finalCategory)
        {
            if (id != finalCategory.Categoryid)
            {
                return BadRequest();
            }

            _finalCategoryService.UpdateCategory(finalCategory);
            return NoContent();
        }

        // DELETE: api/FinalCategory/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = _finalCategoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            _finalCategoryService.DeleteCategory(id);
            return NoContent();
        }

        [Route("uploadImage")]
        [HttpPost]
        public Finaluser UploadIMage()
        {

            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\user\\Desktop\\FinalProject\\src\\assets\\Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Finaluser item = new Finaluser();
            item.Imagepath = fileName;
            return item;
        }
    }
}
