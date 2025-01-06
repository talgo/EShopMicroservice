﻿namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName) :IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart ShoppingCart);

public class GetBasketHandler(IBasketRepository basketRepository) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetBasket(query.UserName, cancellationToken = default);

        return new GetBasketResult(basket);
    }
}
