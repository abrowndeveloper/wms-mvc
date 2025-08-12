using MediatR;

namespace WMS.UI.UseCases.Products.UpsertProducts;

public record UpsertProductsRequest() : IRequest<UpsertProductsResult>;