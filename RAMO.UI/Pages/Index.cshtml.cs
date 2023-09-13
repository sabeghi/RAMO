using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RAMO.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGetNames()
        {
            return new JsonResult("ok");
        }

        public JsonResult OnPostGetTime([FromBody] string name) {

            return new JsonResult(name + " " + DateTime.Now.Date);
        }
    }
}