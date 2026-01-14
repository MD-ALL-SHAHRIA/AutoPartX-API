using AutoPartX.BLL.DTOs;
using AutoPartX.DAL.Repos;
using AutoPartX.DAL.EF.Models; 
using System.Collections.Generic;

namespace AutoPartX.BLL.Services
{
    public class CategoryService
    {
        private readonly CategoryRepo _repo;

        public CategoryService(CategoryRepo repo)
        {
            _repo = repo;
        }

        
        public void Add(CategoryDTO dto)
        {
            var mapper = MapperConfig.GetMapper();
            var category = mapper.Map<Category>(dto); 
            _repo.Add(category); 
        }

        
        public List<CategoryDTO>Get()
        {
            var data = _repo.GetAll();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<CategoryDTO>>(data);
        }

        
       public CategoryDTO Get(int id)
        {
            
            return MapperConfig.GetMapper().Map<CategoryDTO>(_repo.GetById(id));
            
        }
    }
}