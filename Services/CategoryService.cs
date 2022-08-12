using api_base.Dto;
using api_base.Interface;
using api_base.Models;
using AutoMapper;
using Hellang.Middleware.ProblemDetails;

namespace api_base.Services
{
    public class CategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public List<CategoryDto> GetCategories ()
        {
            return _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
        }

        public List<CategoryDto> GetCategory (int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
            {
                throw new ProblemDetailsException(404);
            }
            return _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategory(categoryId));
        }

        public List<PokemonDto> GetPokemonById (int categoryId)
        {
            return _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonByCategory(categoryId));
        }

        public  Category CreateCategory (CategoryNonIdDto categoryCreate)
        {
            if (categoryCreate == null) 
            {
                throw new ProblemDetailsException(400);
            }

            var category = _categoryRepository.GetCategories()
                .Where(c => c.Name.Trim().ToUpper() == categoryCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if(category != null)
            {
                throw new ProblemDetailsException(422, "Category already exists");
            }
            var categoryMap = _mapper.Map<Category>(categoryCreate);
            return _categoryRepository.CreateCategory(categoryMap); 
        }

        public Category UpdateCategory (int categoryId, CategoryNonIdDto updateCategory)
        {
            if (updateCategory == null) 
            {
                throw new ProblemDetailsException(400);
            }

            if(!_categoryRepository.CategoryExists(categoryId))
            {
                throw new ProblemDetailsException(404);
            }

            var categoryMap = _mapper.Map<Category>(updateCategory);
            return _categoryRepository.UpdateCategory(categoryMap);
        }

        public Category DeleteCategory(int categoryId)
        {
            if(!_categoryRepository.CategoryExists(categoryId))
            {
                throw new ProblemDetailsException(404);
            }

            var categoryToDelete = _categoryRepository.GetCategory(categoryId);
            return _categoryRepository.DeleteCategory(categoryToDelete);
        }
    }
}