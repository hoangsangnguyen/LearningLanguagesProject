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
    [Route("Cards")]
    [Authorize]
    public class CardsController : GenericController<Card, CardDto, CardForCreationDto>
    {
        private readonly DatabaseContext _context;
        private readonly IGenericRepository<Card, CardDto, CardForCreationDto> _genericRepository;
        private readonly DbSet<Card> _entity;
        private static readonly HttpClient client = new HttpClient();


        public CardsController(IGenericRepository<Card, CardDto, CardForCreationDto> genericRepository, DatabaseContext context) : base(genericRepository, context)
        {
            _genericRepository = genericRepository;
            _context = context;
            _entity = _context.Set<Card>();

        }

        [HttpGet]
        public Task<IActionResult> GetListAsync([FromQuery] int offset, [FromQuery] int limit, [FromQuery] string keyword, [FromQuery] SortOptions<CardDto, Card> sortOptions,
            [FromQuery] FilterOptions<CardDto, Card> filterOptions)
        {
            IQueryable<Card> querySearch = _entity.Where(x => x.Title.Contains(keyword)
           || x.Content.Contains(keyword));
            return base.GetListAsync(offset, limit, keyword, sortOptions, filterOptions, querySearch);
        }

    }
}
