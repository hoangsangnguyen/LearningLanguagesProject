using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Infrastructure;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("storages")]
    [Authorize]
    public class StorageController : GenericController<Storage, StorageDto, StorageDto>
    {
        private readonly DatabaseContext _context;
        private readonly IGenericRepository<Storage, StorageDto, StorageDto> _genericRepository;

        public StorageController(IGenericRepository<Storage, StorageDto, StorageDto> genericRepository, DatabaseContext context) : base(genericRepository, context)
        {
            _genericRepository = genericRepository;
            _context = context;

        }

        public async Task<IActionResult> GetStoragesAsync(
             [FromQuery] int offset,
             [FromQuery] int limit,
             [FromQuery] string keyword,
             [FromQuery] SortOptions<StorageDto, Storage> sortOptions,
             [FromQuery] FilterOptions<StorageDto, Storage> filterOptions)
        {
            IQueryable<Storage> querySearch = _context.Storages.Where(x => x.Name.Contains(keyword));

            var handledData = await _genericRepository.GetListAsync(offset, limit, keyword, sortOptions, filterOptions, querySearch);

            var items = handledData.Items.ToArray();
            int totalSize = handledData.TotalSize;

            return Ok(new { data = items, totalSize });
        }

        [Route("GetNameStorage")]
        public async Task<IActionResult> GetNameStorageAsync(Guid id)
        {
            try
            {
                var handledData = await _genericRepository.GetSingleAsync(id);
                return Ok(handledData.Name);
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex.Message));
            }
        }
    }
}
