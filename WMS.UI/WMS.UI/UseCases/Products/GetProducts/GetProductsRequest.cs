using MediatR;

namespace WMS.UI.UseCases.Products.GetProducts;

public record GetProductsRequest : IRequest<GetProductsResult>; 