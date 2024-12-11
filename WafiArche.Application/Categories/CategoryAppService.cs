using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WafiArche.Application.Categories.Dtos;
using WafiArche.Domain.Categories;
using WafiArche.EntityFrameworkCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WafiArche.Application.Categories
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryAppService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CategoryDto CreateCategory(CategoryDto categoryDto)
        {

            var category = _mapper.Map<Category>(categoryDto); // Map DTO to entity
            _context.Categories.Add(category);
            _context.SaveChanges();
            return _mapper.Map<CategoryDto>(category); // Map entity back to DTO
        }

        public bool DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryID == id);
            if (category == null)
                throw new Exception($"Category with ID {id} not found.");

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _context.Categories.AsNoTracking().ToList();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories); // Map entities to DTOs
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category = _context.Categories.AsNoTracking().FirstOrDefault(c => c.CategoryID == id);
            if (category == null)
                throw new Exception($"Category with ID {id} not found.");

            return _mapper.Map<CategoryDto>(category); // Map entity to DTO
        }

        public CategoryDto UpdateCategory(int id, CategoryDto updatedCategoryDto)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryID == id);
            if (category == null)
                throw new Exception($"Category with ID {id} not found.");

            _mapper.Map(updatedCategoryDto, category); // Map updated DTO to entity

            _context.SaveChanges();
            return _mapper.Map<CategoryDto>(category); // Map entity back to DTO
        }
    }
}
