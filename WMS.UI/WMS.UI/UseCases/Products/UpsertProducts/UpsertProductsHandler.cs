using MediatR;

namespace WMS.UI.UseCases.Products.UpsertProducts;

public class UpsertProductsHandler : IRequestHandler<UpsertProductsRequest, UpsertProductsResult>
{
    public async Task<UpsertProductsResult> Handle(UpsertProductsRequest request, CancellationToken cancellationToken)
    {
        /* VALIDATION:
         * Are all required columns present?
         * Grouping by SKU should give a unique amount of 1 item per group
         * Is Manufacturer-code unique?
         * DateCreated should be before DateUpdated
         * Weight unit should be valid enum
         * Weight should be > 0
         * CategoryID should be unique per name
         * ManufacturerID should be unique per name
         * CostPrice and SellPrice should be more than 0 and decimal.TryParse should be used
         * Qty should be > -1
         *
         * On re-upload a category name and manufacturer name shouldn't be changeable
         */
        // What happens if a user re-uploads with same data, and different data on another?
        // Work out which to create and which to update
        
        return new();
    }
}