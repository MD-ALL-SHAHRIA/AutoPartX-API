using System.Collections.Generic;
using AutoPartX.BLL.DTOs;
using AutoPartX.DAL;
using AutoPartX.DAL.EF.Models;

namespace AutoPartX.BLL.Services
{
    public class PartService
    {
        
        public List<PartDTO> Get()
        {
            return MapperConfig.GetMapper().Map<List<PartDTO>>(DataAccessFactory.PartData().GetAll());
        }

        public PartDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<PartDTO>(DataAccessFactory.PartData().GetById(id));
        }

        public void Add(PartDTO dto)
        {
            var part = MapperConfig.GetMapper().Map<Part>(dto);
            DataAccessFactory.PartData().Create(part);
        }

        public void Update(PartDTO dto)
        {
            var part = MapperConfig.GetMapper().Map<Part>(dto);
            DataAccessFactory.PartData().Update(part);
        }

        public bool Delete(int id)
        {
            return DataAccessFactory.PartData().Delete(id);
        }

        
        public List<PartDTO> Search(string query)
        {
            return MapperConfig.GetMapper().Map<List<PartDTO>>(DataAccessFactory.PartData().Search(query));
        }

        public List<PartDTO> GetByPriceRange(decimal min, decimal max)
        {
            return MapperConfig.GetMapper().Map<List<PartDTO>>(DataAccessFactory.PartData().GetByPriceRange(min, max));
        }

        public List<PartDTO> GetLowStock(int doorway)
        {
            return MapperConfig.GetMapper().Map<List<PartDTO>>(DataAccessFactory.PartData().GetLowStock(doorway));
        }

        public decimal GetTotalValue()
        {
            return DataAccessFactory.PartData().GetTotalValue();
        }

        public bool UpdateStock(int id, int qty)
        {
            return DataAccessFactory.PartData().UpdateStock(id, qty);
        }
    }
}