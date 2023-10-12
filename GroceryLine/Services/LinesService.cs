using GroceryLine.Models;

namespace GroceryLine.Services
{
    public class LinesService
    {
        public List<Line> Lines { get; set; }

        public LinesService(List<Line> lines)
        {
            Lines = lines;
        }

        public void TickAllLinesDownByOne()
        {
            foreach (Line line in Lines)
            {
                line.Customers[0].ItemCount--;
                if (line.Customers[0].ItemCount <= 0)
                {
                    line.Customers.RemoveAt(0);
                }
            }
        }
    }
}
