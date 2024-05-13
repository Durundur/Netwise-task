using Microsoft.AspNetCore.Mvc;
using netwise_task.Services;

namespace netwise_task.Controllers
{
    public class HomeController : Controller
    {

        private readonly FactService _factService;
        private readonly FileService _fileService;

        public HomeController(FactService factService, FileService fileService)
        {
            _factService = factService;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetFact()
        {
            try
            {
                var fact = await _factService.GetFact();
                string filePath = Path.Combine(AppContext.BaseDirectory, "facts.txt");
                await _fileService.AppendToFileAsync(fact.ToString(), filePath);
                return View("Index", fact);
            } catch(Exception ex) 
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Index");
            }
        }
    }
}
