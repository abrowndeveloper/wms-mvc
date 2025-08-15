using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WMS.UI.Models;
using WMS.UI.UseCases.Products.UpsertProducts;
using WMS.UI.UseCases.Products.GetProducts;
using WMS.UI.UseCases.Products.UpsertProduct;
using WMS.UI.UseCases.Products.GetProduct;
using MediatR;
using WMS.Domain.Units;
using WMS.UI.UseCases.Products.Common;
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

    [HttpGet]
    public async Task<IActionResult> GetProductsJson()
    {
        var request = new GetProductsRequest();
        var result = await _mediator.Send(request);
        
        return Json(result.Products);
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

    public async Task<IActionResult> Product(Guid? id)
    {
        if (id is null)
            return View(
                new ProductModel
                {
                    Product = new ProductDto(null, string.Empty, string.Empty, string.Empty, false, string.Empty, 0,
                        WeightUnit.KG.ToString(), 0, 0)
                }
            );

        var getRequest = new GetProductRequest(id.Value);
        var getResult = await _mediator.Send(getRequest);

        if (getResult.Product is null)
        {
            TempData["Error"] = "Product not found.";
            return RedirectToAction(nameof(Products));
        }

        var productModel = new ProductModel
        {
            Product = getResult.Product
        };

        return View(productModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Product(ProductModel model)
    {
        var upsertRequest = new UpsertProductRequest(model.Product);
        var upsertResult = await _mediator.Send(upsertRequest);

        if (upsertResult.Error is not null)
        {
            TempData["Error"] = upsertResult.Error;
            return View(model);
        }

        TempData["Error"] = "Successfully saved!";
        
        return View(new ProductModel { Product = upsertResult.Product });
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