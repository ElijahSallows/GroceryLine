namespace GroceryLine.Models
{ 
    public class Customer
    {
        public int ItemCount { get; set; }

        public Customer(int itemCount)
        {
            ItemCount = itemCount;
        }
    }
}
