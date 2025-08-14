using MediatR;

namespace WMS.UI.UseCases.Products.UpsertProducts;

public record UpsertProductsRequest(IFormFile ProductsFile, bool SkipErrors) : IRequest<UpsertProductsResult>;