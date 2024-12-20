
namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductByCategoryResut>;
public record GetProductByCategoryResut(IEnumerable<Product> Products);

public class GetProductsByCategoryHandler
    (IDocumentSession session, ILogger<GetProductsByCategoryHandler> logger) : 
    IRequestHandler<GetProductsByCategoryQuery, GetProductByCategoryResut>
{
    public async Task<GetProductByCategoryResut> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetProductsByCategoryHandler.Handler called with {query}");

        var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync(cancellationToken);

        return new GetProductByCategoryResut(products);
    }
}
