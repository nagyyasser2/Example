using Example.Api.Attributes;
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
    [Authorize]
    public class BooksController(IUnitOfWork unitOfWork): ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        [Authorize(Roles = "Admin,SuperUser")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("allAsync")]
        [CheckPermission(Permission.ReadBooks)]
        public  IActionResult GetAllAsync()
        {
            return Ok( _unitOfWork.Books.GetAllSpecialForBooksRepository());
        }
    }
}
