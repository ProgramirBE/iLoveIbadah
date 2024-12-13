using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Contracts.Persistence
{
    public interface IBlobFileRepository : IGenericRepository<BlobFile>
    {
        Task<BlobFile> GetBlobFileWithDetails(int id);
        Task<List<BlobFile>> GetBlobFilesWithDetails();
    }
}
