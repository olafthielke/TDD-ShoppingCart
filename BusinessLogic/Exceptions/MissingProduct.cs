namespace BusinessLogic.Exceptions
{
    public class MissingProduct : Exception
    {
        public MissingProduct()
            : base("Must have a product.")
        { }
    }
}
