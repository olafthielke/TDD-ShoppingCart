namespace BusinessLogic.Exceptions
{
    public class ProductAlreadyInCart : Exception
    {
        public ProductAlreadyInCart()
            : base("Product 'Apple' is already in the cart.")
        { }
    }
}