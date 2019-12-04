using System.Threading.Tasks;
using CleanArchitecture.Core;
using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Web.Pages.ToDoRazorPage
{
    public class PopulateModel : PageModel
    {
        private readonly IRepository _repository;

        public PopulateModel(IRepository repository)
        {
            _repository = repository;
        }

        public int RecordsAdded { get; set; }

        public async Task OnGetAsync()
        {
            RecordsAdded = await DatabasePopulator.PopulateDatabaseAsync(_repository);
        }
    }
}
