namespace GroceryLine.Services
{
    using GroceryLine.Models;

    public class RandomService
    {
        public List<Line> GetRandomLines()
        {
            List<Line> lines = new();

            int linesCount = Faker.RandomNumber.Next(3, 7);
            for (int i = 0; i < linesCount; i++)
            {
                var customers = GetRandomCustomers();
                lines.Add(new Line(customers));
            }

            return lines;
        }

        public List<Customer> GetRandomCustomers()
        {
            List<Customer> customers = new();

            int customerCount = Faker.RandomNumber.Next(0, 10);
            for (int i = 0; i < customerCount; i++)
            {
                int customerItemCount = Faker.RandomNumber.Next(1, 50);
                customers.Add(new Customer(customerItemCount));
            }
            return customers;
        }
    }
}
