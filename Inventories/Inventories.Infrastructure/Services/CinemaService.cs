using System.Threading.Tasks;
using Inventories.Data.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Inventories.Data.Interfaces;

namespace Inventories.Infrastructure.Services
{
    public class CinemaService
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public CinemaService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Cinema> GetAsync(string vistaId)
        {
            return await UnitOfWork.CinemaRepository.GetAll().FirstOrDefaultAsync(x => x.VistaId == vistaId);
        }
    }
}
