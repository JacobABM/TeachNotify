using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeachNotify.Pages
{
    public class DocenteModel : PageModel
    {
        private readonly ILogger<DocenteModel> _logger;

        public DocenteModel(ILogger<DocenteModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}