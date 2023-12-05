using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RAMO.UI.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Message { get; private set; } = "................. ";

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Message+=" ok SALAM";
        }

        public JsonResult OnGetNames(string name)
        {
            return new JsonResult("ok + : " + name);
        }

        public JsonResult OnPostGetTime([FromBody] Test name) {

            return new JsonResult(name.name + " _ " + DateTime.Now.Date);
        }
    }

    public class Test
    {
        public string name { get; set; }
    }
}