using System;
using Inventories.Infrastructure.Interfaces;
using Inventories.Data.EntityFramework.Context;
using Inventories.Data.EntityFramework.Models;
using System.Threading.Tasks;

namespace Inventories.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {   
        private FoodsMxDbContext _context;
        private GenericRepository<ConsessionCinema> _consessionCinemaRepository;
        private GenericRepository<Cinema> _cinemaRepository;
        private GenericRepository<Status> _statusRepository;
        private GenericRepository<PromotionPrice> _promotionPrice;

        public IGenericRepository<ConsessionCinema> ConsessionCinemaRepository
        {
            get
            {
                return _consessionCinemaRepository = _consessionCinemaRepository ?? new GenericRepository<ConsessionCinema>(_context);
            }
        }

        public IGenericRepository<Cinema> CinemaRepository
        {
            get
            {
                return _cinemaRepository = _cinemaRepository ?? new GenericRepository<Cinema>(_context);
            }
        }

        public IGenericRepository<Status> StatusRepository
        {
            get
            {
                return _statusRepository = _statusRepository ?? new GenericRepository<Status>(_context);
            }
        }

        public IGenericRepository<PromotionPrice> PromotionPriceRepostory {
            get
            {
                return _promotionPrice = _promotionPrice ?? new GenericRepository<PromotionPrice>(_context);
            }
        }

        public UnitOfWork(FoodsMxDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
