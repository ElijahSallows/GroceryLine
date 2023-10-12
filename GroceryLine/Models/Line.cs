namespace GroceryLine.Models
{
    public class Line
    {
        public List<Customer> Customers { get; set; }

        public int TotalItemCount
        {
            get
            {
                return Customers.Sum(c => c.ItemCount);
            }
        }

        public Line(List<Customer> customers)
        {
            Customers = customers;
        }

        public void Add(Customer customer)
        {
            Customers.Add(customer);
        }

        public void Add(List<Customer> customers)
        {
            Customers.AddRange(customers);
        }
    }
}
