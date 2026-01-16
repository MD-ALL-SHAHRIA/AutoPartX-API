using System.Collections.Generic;
using AutoPartX.BLL.DTOs;
using AutoPartX.DAL;
using AutoPartX.DAL.EF.Models;

namespace AutoPartX.BLL.Services
{
    public class CategoryService
    {
        public List<CategoryDTO> Get()
        {
            return MapperConfig.GetMapper().Map<List<CategoryDTO>>(DataAccessFactory.CategoryData().GetAll());
        }

        public CategoryDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<CategoryDTO>(DataAccessFactory.CategoryData().GetById(id));
        }

        
        public CategoryDTO GetWithParts(int id)
        {
            return MapperConfig.GetMapper().Map<CategoryDTO>(DataAccessFactory.CategoryData().GetWithParts(id));
        }

        public void Add(CategoryDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<Category>(dto);
            DataAccessFactory.CategoryData().Create(data);
        }

        public void Update(CategoryDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<Category>(dto);
            DataAccessFactory.CategoryData().Update(data);
        }

        public bool Delete(int id)
        {
            return DataAccessFactory.CategoryData().Delete(id);
        }
    }
}