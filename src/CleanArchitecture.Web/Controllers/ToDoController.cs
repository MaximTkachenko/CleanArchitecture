using CleanArchitecture.Core;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IRepository _repository;

        public ToDoController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var items = _repository.List(ToDoItemSpecs.All())
                            .Select(ToDoItemDTO.FromToDoItem);
            return View(items);
        }

        public async Task<IActionResult> Populate()
        {
            int recordsAdded = await DatabasePopulator.PopulateDatabaseAsync(_repository);
            return Ok(recordsAdded);
        }
    }
}
