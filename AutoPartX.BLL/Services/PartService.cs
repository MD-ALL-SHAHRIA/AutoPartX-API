using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoPartX.BLL.DTOs;
using AutoPartX.DAL.EF.Models;
using AutoPartX.DAL.Repos;

namespace AutoPartX.BLL.Services
{
    public class PartService
    {
        public readonly PartRepo _repo;

        public PartService(PartRepo repo)
        {
            _repo = repo;
        }

        public void Add(PartDTO dto)
        {
            var mapper = MapperConfig.GetMapper();
            var part = mapper.Map<Part>(dto);
            _repo.Create(part);
        }

        public List<PartDTO> Get() //get all
        {
            var data = _repo.GetAll();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<PartDTO>>(data);
        }

        
        public PartDTO Get(int id)
        {
            var data = _repo.GetById(id);
            if (data == null) return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<PartDTO>(data);
        }

        
        public void Update(PartDTO dto)
        {
            var mapper = MapperConfig.GetMapper();
            var part = mapper.Map<Part>(dto);
            _repo.Update(part);
        }

       
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        
        public List<PartDTO> Search(string query)
        {
            var data = _repo.SearchParts(query);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<PartDTO>>(data);
        }

        
        public List<PartDTO> GetByPriceRange(decimal min, decimal max)
        {
            var data = _repo.GetPartsByPriceRange(min, max);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<PartDTO>>(data);
        }

        
        public List<PartDTO> GetLowStock(int doorway)
        {
            var data = _repo.GetLowStockAlert(doorway);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<PartDTO>>(data);
        }


        public decimal GetTotalValue()
        {
            return _repo.GetTotalInventoryValue();
        }
        
        public bool UpdateStock(int id, int qty)
        {
            return _repo.UpdateStockLevel(id, qty);
        }

    }
}