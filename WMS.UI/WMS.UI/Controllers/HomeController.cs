using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using WMS.UI.Models;
using WMS.UI.UseCases.Products.UpsertProducts;
using MediatR;
using WMS.UI.Views;

namespace WMS.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;

    public HomeController(ILogger<HomeController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Products()
    {
        return View(new ProductsModel());
    }

    public IActionResult UploadProducts()
    {
        return View(new UploadProductsModel());
    }

    [HttpPost]
    public async Task<IActionResult> UploadProducts(CsvUploadModel model, bool skipErrors = false)
    {
        if (model.CsvFile == null || model.CsvFile.Length == 0)
        {
            TempData["Error"] = "Please select a CSV file to upload.";
            return RedirectToAction(nameof(Index));
        }

        if (!model.CsvFile.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
        {
            TempData["Error"] = "Please upload a valid CSV file.";
            return RedirectToAction(nameof(Index));
        }
        
        var request = new UpsertProductsRequest(model.CsvFile, skipErrors);
        var result = await _mediator.Send(request);

        if (result.Error is not null)
            TempData["Error"] = result.Error;
        else if (result.InvalidRows.Any() is false)
            TempData["Success"] = "CSV uploaded successfully!";

        return View(new UploadProductsModel{ InvalidRows = result.InvalidRows, Error = result.Error });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}