using Example.Core.Interfaces;
using Example.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public  ActionResult GetAll()
        {
            return Ok(this._unitOfWork.Authors.GetAll());
        }

        [HttpPost]
        public ActionResult Add(Author author)
        {
            _unitOfWork.Authors.Add(author);
            _unitOfWork.Complete();
            return Ok(author);
        }
    }
}
