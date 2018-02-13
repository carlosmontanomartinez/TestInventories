using System;
using System.Threading.Tasks;
using Inventories.Data.EntityFramework.Models;
namespace Inventories.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {

        IGenericRepository<ConsessionCinema> ConsessionCinemaRepository { get; }
        IGenericRepository<Cinema> CinemaRepository { get; }
        IGenericRepository<Status> StatusRepository { get; }
        IGenericRepository<PromotionPrice> PromotionPriceRepostory { get; }
        void Save();
        Task SaveAsync();
    }
}
