using App.Repositories;
using App.Repositories.Categories;
using AutoMapper;

namespace App.Services.Categories;

public class CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
   : ICategoryService
{

}
