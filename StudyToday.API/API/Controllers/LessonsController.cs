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
    [Route("Lessons")]
    [Authorize]
    public class LessonsController : GenericController<Lesson, LessonDto, LessonForCreationDto>
    {
        private readonly DatabaseContext _context;
        private readonly IGenericRepository<Lesson, LessonDto, LessonForCreationDto> _genericRepository;
        private readonly DbSet<Lesson> _entity;
        private static readonly HttpClient client = new HttpClient();


        public LessonsController(IGenericRepository<Lesson, LessonDto, LessonForCreationDto> genericRepository, DatabaseContext context) : base(genericRepository, context)
        {
            _genericRepository = genericRepository;
            _context = context;
            _entity = _context.Set<Lesson>();

        }

        [HttpGet]
        public Task<IActionResult> GetListAsync([FromQuery] int offset, [FromQuery] int limit, [FromQuery] string keyword, [FromQuery] SortOptions<LessonDto, Lesson> sortOptions, [FromQuery] FilterOptions<LessonDto, Lesson> filterOptions)
        {
            IQueryable<Lesson> querySearch = _entity.Where(x => x.Title.Contains(keyword)
           || x.Introduction.Contains(keyword));
            return base.GetListAsync(offset, limit, keyword, sortOptions, filterOptions, querySearch);
        }
    }
}
