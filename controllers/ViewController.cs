using Microsoft.AspNetCore.Mvc;

namespace mymusic.controllers
{

    [ApiController]
    [Route("/")]
    public class ViewController: ControllerBase
    {

        private readonly IWebHostEnvironment _hostEnviroment;
        public ViewController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnviroment = hostEnvironment;
        }

        public IActionResult Index()
        {
            string filePath = "views/mymusic-front/index.html";
            string absolutePath = Path.Combine(_hostEnviroment.ContentRootPath, filePath);


            // Verifica se o arquivo existe
            if (System.IO.File.Exists(absolutePath))
            {
                var fileResult = new PhysicalFileResult(absolutePath, "text/html");

                return fileResult;
        }
            else
            {
                return NotFound();
            }
        }
    }
}
