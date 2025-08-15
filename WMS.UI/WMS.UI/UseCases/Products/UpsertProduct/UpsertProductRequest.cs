using MediatR;
using WMS.UI.UseCases.Products.Common;

namespace WMS.UI.UseCases.Products.UpsertProduct;

public record UpsertProductRequest(ProductDto Product) : IRequest<UpsertProductResult>; 