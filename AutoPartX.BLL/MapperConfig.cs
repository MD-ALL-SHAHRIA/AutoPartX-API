using AutoMapper;
using AutoPartX.BLL.DTOs;
using AutoPartX.DAL.EF.Models;

namespace AutoPartX.BLL
{
    public class MapperConfig
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                cfg.CreateMap<Part, PartDTO>().ReverseMap();
                cfg.CreateMap<Order, OrderDTO>().ReverseMap();
                cfg.CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
    }
}