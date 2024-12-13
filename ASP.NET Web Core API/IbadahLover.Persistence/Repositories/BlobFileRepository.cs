using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Persistence.Repositories
{
    public class BlobFileRepository : GenericRepository<BlobFile>, IBlobFileRepository
    {
        private readonly IbadahLoverDbContext _dbContext;
        public BlobFileRepository(IbadahLoverDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BlobFile>> GetBlobFilesWithDetails()
        {
            var blobFiles = await _dbContext.BlobFiles
                .ToListAsync();
            return blobFiles;
        }

        public async Task<BlobFile> GetBlobFileWithDetails(int id)
        {
            var blobFile = await _dbContext.BlobFiles
                .FirstOrDefaultAsync(Queryable => Queryable.Id == id);
            return blobFile;
        }
    }
}
