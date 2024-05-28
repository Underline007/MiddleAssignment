using AutoMapper;
using BookManagement.Application.Dtos;
using BookManagement.Application.DTOs;
using BookManagement.Application.Interfaces;
using BookManagement.Entities.Models;
using BookManagement.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagement.Application.Services
{
    public class AuthorService
    {
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public AuthorService(IGenericRepository<Author> authorRepository, IPhotoService photoService, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _photoService = photoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync(int pageNumber, int pageSize)
        {
            var authors = await _authorRepository.GetAll(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(Guid id)
        {
            var author = await _authorRepository.GetById(id);
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> AddAuthorAsync(CreateEditAuthorDto createEditAuthorDto)
        {
            var author = _mapper.Map<Author>(createEditAuthorDto);

            if (createEditAuthorDto.Image != null)
            {
                var uploadResult = await _photoService.AddPhotoAsync(createEditAuthorDto.Image);
                author.Image = uploadResult.Url.ToString();
            }

            await _authorRepository.Add(author);
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task DeleteAuthorAsync(Guid id)
        {
            var author = await _authorRepository.GetById(id);
            if (author == null)
            {
                throw new KeyNotFoundException("Author not found");
            }

            if (!string.IsNullOrEmpty(author.Image))
            {
                await _photoService.DeletePhotoAsync(author.Image);
            }

            await _authorRepository.Delete(id);
        }

        public async Task UpdateAuthorAsync(Guid id, CreateEditAuthorDto createEditAuthorDto)
        {
            var author = await _authorRepository.GetById(id);
            if (author == null)
            {
                throw new KeyNotFoundException("Author not found");
            }

            _mapper.Map(createEditAuthorDto, author);

            if (createEditAuthorDto.Image != null)
            {
                var uploadResult = await _photoService.AddPhotoAsync(createEditAuthorDto.Image);
                author.Image = uploadResult.Url.ToString();
            }

            await _authorRepository.Update(author);
        }
    }
}
