using AutoMapper;
using DomainModel.Dtos;
using DomainModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository.Abstraction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public BookController(IRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //List all books
        [HttpGet("list")]
        public IActionResult Get()
        {
            var books = _repository.GetAllAsync();

            return Ok(_mapper.Map<List<BookDto>>(books));
        }

        //Get book by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await _repository.GetAsync(id);
            if (book == null) return NotFound("no such user");
            return Ok(book);

        }

        //Create a book
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            bool result = await _repository.AddAsync(book);
            if (!result) return BadRequest("somethin went wrong");
            return StatusCode(StatusCodes.Status201Created);
        }

        //Update a single book

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BookDto bookDto)
        {
            Book existbook = await _repository.GetAsync(id);
            if (existbook == null) return NotFound("no such student");
            existbook.title = bookDto.title;
            existbook.genre = bookDto.genre;
            existbook.author = bookDto.author;
            bool result = await _repository.Update(existbook);
            if (!result) return BadRequest("somethin went wrong");
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
