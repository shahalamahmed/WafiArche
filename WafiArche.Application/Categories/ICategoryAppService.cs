using WafiArche.Application.Categories.Dtos;

namespace WafiArche.Application.Categories
{
    public interface ICategoryAppService
    {
        CategoryDto CreateCategory(CategoryDto categoryDto);
        bool DeleteCategory(int id);
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(int id);
        CategoryDto UpdateCategory(int id, CategoryDto updatedCategoryDto);
    }
}
