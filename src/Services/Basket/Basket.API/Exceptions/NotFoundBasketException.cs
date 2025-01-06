namespace Basket.API.Exceptions;

public class NotFoundBasketException : NotFoundException
{
    public NotFoundBasketException(string userName) : base("Basket", userName)
    {

    }
}
