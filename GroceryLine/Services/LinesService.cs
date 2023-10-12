namespace GroceryLine.Services
{
    using GroceryLine.Models;
    using System;
    using System.Timers;

    public class LinesService
    {
        private bool isScanningItems = true;
        private int checkoutRateMilliseconds = 500;
        private int checkoutAmount = 1;
        private Timer CheckoutTimer { get; set; }

        public List<Line> Lines { get; set; }
        public int CheckoutRateMilliseconds
        {
            get
            {
                return checkoutRateMilliseconds;
            }
            set
            {
                checkoutRateMilliseconds = value;
                UpdateTimer();
            }
        }

        public int CheckoutAmount
        {
            get
            {
                return checkoutAmount;
            }
            set
            {
                checkoutAmount = value;
                UpdateTimer();
            }
        }

        public bool IsScanningItems
        {
            get
            {
                return isScanningItems;
            }
            set
            {
                isScanningItems = value;
                UpdateTimer();
            }
        }

        public LinesService(List<Line> lines)
        {
            Lines = lines;
            CheckoutTimer = new Timer();
            CheckoutTimer.Elapsed += CheckoutTimerElapsed;
            UpdateTimer();
        }

        public void AddCustomer(int itemCount)
        {
            if (itemCount <= 0)
            {
                return;
            }

            Customer customer = new(itemCount);
            Line line = FindLeastFullLine();
            line.Add(customer);
        }

        private Line FindLeastFullLine()
        {
            return Lines.Aggregate(
                    (minItem, nextItem) =>
                    minItem.TotalItemCount < nextItem.TotalItemCount
                    ? minItem
                    : nextItem
                    );
        }

        private void TickAllLinesDown()
        {
            foreach (Line line in Lines)
            {
                if (line.Customers.Count <= 0)
                {
                    continue;
                }

                line.Customers[0].ItemCount -= CheckoutAmount;
                if (line.Customers[0].ItemCount <= 0)
                {
                    line.Customers.RemoveAt(0);
                }
            }
        }

        private void UpdateTimer()
        {
            CheckoutTimer.Enabled = IsScanningItems;
            //CheckoutTimer.Start
            CheckoutTimer.Interval = CheckoutRateMilliseconds;
            //CheckoutTimer.AutoReset = true;
        }

        private async void CheckoutTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            TickAllLinesDown();
        }

    }
}
