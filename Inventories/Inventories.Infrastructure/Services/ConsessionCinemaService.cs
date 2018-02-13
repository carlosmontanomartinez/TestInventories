using System.Threading.Tasks;
using Inventories.Data.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Inventories.Data.Interfaces;
using Inventories.Data.EntityFramework.Core;

namespace Inventories.Infrastructure.Services
{
    public class ConsessionCinemaService //: GenericRepository<ConsessionCinema>
    {
        //public IUnitOfWork UnitOfWork { get; private set; }

        //public ConsessionCinemaService(IUnitOfWork unitOfWork)
        //{
        //    UnitOfWork = unitOfWork;
        //}

        //public async Task<ConsessionCinema> GetAsync(int cinemaId, int hopk)
        //{
        //    return await UnitOfWork.ConsessionCinemaRepository.GetAll().Include(x => x.Cinema).Include(x => x.Status).FirstOrDefaultAsync(x => x.CinemaId == cinemaId && x.Hopk == hopk);
        //}
    }
}
