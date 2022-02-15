namespace BusinessLogic.Exceptions
{
    public class ProductAlreadyInCart : Exception
    {
        public ProductAlreadyInCart(string productName)
            : base($"Product '{productName}' is already in the cart.")
        { }
    }
}