using System;
using System.Collections.Generic;
using AutoPartX.BLL.DTOs;
using AutoPartX.DAL;
using AutoPartX.DAL.EF.Models;

namespace AutoPartX.BLL.Services
{
    public class OrderService
    {
        public List<OrderDTO> Get()
        {
            var data = DataAccessFactory.OrderData().GetAll();
            return MapperConfig.GetMapper().Map<List<OrderDTO>>(data);
        }

        public OrderDTO Get(int id)
        {
            var data = DataAccessFactory.OrderData().GetById(id);
            return MapperConfig.GetMapper().Map<OrderDTO>(data);
        }

        
        public bool PlaceOrder(OrderDTO orderDto)
        {
            var order = new Order();
            order.Status = "Pending";
            order.OrderDate = DateTime.Now;
            order.TotalAmount = 0;

            
            foreach (var item in orderDto.OrderDetails)
            {
                var part = DataAccessFactory.PartData().GetById(item.PartId);
                
                
                if (part == null || part.StockQuantity < item.Quantity)
                {
                    return false; 
                }

              
                part.StockQuantity -= item.Quantity;
                DataAccessFactory.PartData().Update(part);

                
                var od = new OrderDetail
                {
                    PartId = item.PartId,
                    Quantity = item.Quantity,
                    UnitPrice = part.Price 
                };
                
                order.TotalAmount += (part.Price * item.Quantity);
                order.OrderDetails.Add(od);
            }

            
            DataAccessFactory.OrderData().Create(order);
            return true;
        }

        public bool CancelOrder(int id)
        {
             
             return DataAccessFactory.OrderData().Delete(id);
        }
    }
}