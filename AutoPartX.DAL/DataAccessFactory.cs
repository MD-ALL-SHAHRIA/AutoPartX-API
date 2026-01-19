using AutoPartX.DAL.EF;
using AutoPartX.DAL.Interfaces;
using AutoPartX.DAL.Repos;

namespace AutoPartX.DAL
{
    public class DataAccessFactory
    {
        static AppDbContext db = new AppDbContext();

        public static ICategoryRepo CategoryData()
        {
            return new CategoryRepo(db);
        }

        public static IPartRepo PartData()
        {
            return new PartRepo(db);
        }

        public static IOrderRepo OrderData()
        {
        return new OrderRepo(db);
        }
    }
}