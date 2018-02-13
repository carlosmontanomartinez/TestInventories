using System.Threading.Tasks;
using Inventories.Data.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Inventories.Data.Interfaces;

namespace Inventories.Infrastructure.Services
{
    public class StatusService
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public StatusService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Status> GetAsync(string code)
        {
            return await UnitOfWork.StatusRepository.GetAll().FirstOrDefaultAsync(x => x.Code == code);
        }
    }
}
