namespace Catalog.API.Products.GetProductsByCategory;

//public record GetProductsByCategoryRequest(string Category);
public record GetProductByCategoryResponse(IEnumerable<Product> Products);

public class GetProductsByCategoryEnpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var resut = await sender.Send(new GetProductsByCategoryQuery(category));
            var response = resut.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductsByCategory")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products By Category")
        .WithDescription("Get Products By Category");
    }
}
