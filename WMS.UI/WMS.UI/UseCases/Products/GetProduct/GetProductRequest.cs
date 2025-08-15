using MediatR;

namespace WMS.UI.UseCases.Products.GetProduct;

public record GetProductRequest(Guid Id) : IRequest<GetProductResult>; 