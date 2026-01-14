using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoPartX.BLL.DTOs;
using AutoPartX.DAL.EF.Models;

namespace AutoPartX.BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(c =>
        {
            c.CreateMap<Category, CategoryDTO>().ReverseMap();
            c.CreateMap<Part, PartDTO>().ReverseMap();
        });

        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }

    }
}