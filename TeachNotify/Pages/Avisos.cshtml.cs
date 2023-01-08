using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeachNotify.Pages
{
    public class AlumnoModel : PageModel
    {
        private readonly ILogger<AlumnoModel> _logger;

        public AlumnoModel(ILogger<AlumnoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}