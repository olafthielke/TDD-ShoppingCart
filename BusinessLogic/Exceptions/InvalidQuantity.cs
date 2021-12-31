namespace BusinessLogic.Exceptions
{
    public class InvalidQuantity : Exception
    {
        public InvalidQuantity(int quantity)
            : base($"{quantity} is an invalid quantity.")
        { }
    }
}
