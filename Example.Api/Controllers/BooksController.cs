using AutoMapper;
using Example.Api.Attributes;
using Example.Core.DTOs;
using Example.Core.Enums;
using Example.Core.Interfaces;
using Example.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BooksController(IUnitOfWork unitOfWork, IMapper mapper): ControllerBase
    {
        public IMapper Mapper { get; } = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
       // [Authorize(Roles = "Admin,SuperUser")]
        public IActionResult GetAll()
        {
            var books = _unitOfWork.Books.GetAll();
            var data = Mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(data);
        }

        [HttpGet("allAsync")]
        [CheckPermission(Permission.ReadBooks)]
        public  IActionResult GetAllAsync()
        {
            return Ok( _unitOfWork.Books.GetAllSpecialForBooksRepository());
        }
    }
}
