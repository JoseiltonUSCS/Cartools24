using Cartools.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Cartools.Areas.Parceiro.Controllers
{
    [Area("Parceiro")]
    [Authorize(Roles = "Parceiro")]
    public class ParceiroImagensController : Controller
    {
        private readonly ConfigurationImagensParceiros _parcConfig;
        private readonly IWebHostEnvironment _parcHostingEnvironment;

        public ParceiroImagensController(IWebHostEnvironment parcHostingEnvironment, IOptions<ConfigurationImagensParceiros> parcConfiguration)
        {
            _parcHostingEnvironment = parcHostingEnvironment;
            _parcConfig = parcConfiguration.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }

            if (files.Count > 10)
            {
                ViewData["Erro"] = "Error: Quantidade de arquivos excedeu o limite";
                return View(ViewData);
            }
            long size = files.Sum(f => f.Length);

            var filePathsName = new List<string>();

            var filePath = Path.Combine(_parcHostingEnvironment.WebRootPath, _parcConfig.NomePastaImagensImgParceiros);


            foreach (var formFile in files)
            {
                if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".jpeg")
                    || formFile.FileName.Contains(".gif") || formFile.FileName.Contains(".png"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                    filePathsName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            ViewData["Resultado"] = $"{files.Count} arquivo(s) enviado(s) ao servidor, " +
                                    $" Tamanho do arquivo: {size} bytes";

            ViewBag.Arquivos = filePathsName;

            return View(ViewData);
        }

        public IActionResult GetImagens()
        {
            FileManagerModel model = new FileManagerModel();

            var userImagesPath = Path.Combine(_parcHostingEnvironment.WebRootPath,
                _parcConfig.NomePastaImagensImgParceiros);

            DirectoryInfo dir = new DirectoryInfo(userImagesPath);

            FileInfo[] files = dir.GetFiles();

            model.PathImagensProduto = _parcConfig.NomePastaImagensImgParceiros;

            if (files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta{userImagesPath}";
            }
            model.Files = files;

            return View(model);
        }
        public IActionResult Deletefile(string fname)
        {
            string _imagemDeleta = Path.Combine(_parcHostingEnvironment.WebRootPath,
                _parcConfig.NomePastaImagensImgParceiros + "\\", fname);

            if ((System.IO.File.Exists(_imagemDeleta)))
            {
                System.IO.File.Delete(_imagemDeleta);

                ViewData["Deletado"] = $"Arquivo(s) {_imagemDeleta} deletado com sucesso";
            }

            return View("index");
        }
    }
}
