using API.Entities;
using API.Infrastructure;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("Topics")]
    [Authorize]
    public class TopicsController : GenericController<Topic, TopicDto, TopicDto>
    {
        private readonly DatabaseContext _context;
        private readonly IGenericRepository<Topic, TopicDto, TopicDto> _genericRepository;
        private readonly DbSet<Topic> _entity;
        private static readonly HttpClient client = new HttpClient();


        public TopicsController(IGenericRepository<Topic, TopicDto, TopicDto> genericRepository, DatabaseContext context) : base(genericRepository, context)
        {
            _genericRepository = genericRepository;
            _context = context;
            _entity = _context.Set<Topic>();

        }

        [HttpGet]
        public Task<IActionResult> GetListAsync([FromQuery] int offset, [FromQuery] int limit, [FromQuery] string keyword, [FromQuery] SortOptions<TopicDto, Topic> sortOptions,
            [FromQuery] FilterOptions<TopicDto, Topic> filterOptions)
        {
            IQueryable<Topic> querySearch = _entity.Where(x => x.Title.Contains(keyword));
            return base.GetListAsync(offset, limit, keyword, sortOptions, filterOptions, querySearch);
        }
    }
}
