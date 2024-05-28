using BookManagement.Application.Dtos;
using BookManagement.Application.DTOs;
using BookManagement.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAuthors(int pageNumber = 1, int pageSize = 10)
        {
            var authors = await _authorService.GetAllAuthorsAsync(pageNumber, pageSize);
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(Guid id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> AddAuthor([FromForm] CreateEditAuthorDto createEditAuthorDto)
        {
            var author = await _authorService.AddAuthorAsync(createEditAuthorDto);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.AuthorID }, author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            try
            {
                await _authorService.DeleteAuthorAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromForm] CreateEditAuthorDto createEditAuthorDto)
        {
            try
            {
                await _authorService.UpdateAuthorAsync(id, createEditAuthorDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
