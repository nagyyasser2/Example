using Example.Api.Attributes;
using Example.Core.Enums;
using Example.Core.Interfaces;
using Example.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IUnitOfWork unitOfWork): ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        [CheckPermission(Permission.ReadBooks)]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("allAsync")]
        public  IActionResult GetAllAsync()
        {
            return Ok( _unitOfWork.Books.GetAllSpecialForBooksRepository());
        }
    }
}
