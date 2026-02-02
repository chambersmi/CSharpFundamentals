namespace DefaultInterfaceImplementation
{
    // DON'T USE UNLESS THE INTERFACE WILL BREAK THE CODE!

    internal class Program
    {
        static void Main(string[] args)
        {
            IOrder order = new Order();
            order.DelayDeliveryByDays(5);

            IOrder order2 = new CustomOrderWithDelay();
            order2.DelayDeliveryByDays(15);
        }
    }

    public class CustomOrderWithDelay : IOrder
    {

        public void DelayDeliveryByDays(int days)
        {
            Console.WriteLine($"CustomOrderWithDelay: {days}");
        }

        public void PlaceOrder()
        {
            throw new NotImplementedException();
        }
    }

    public class Order : IOrder
    {
        public void PlaceOrder()
        {
            throw new NotImplementedException();
        }
    }

    public interface IOrder
    {
        void PlaceOrder();

        public void DelayDeliveryByDays(int days)
        {
            Console.WriteLine($"Order was delayed by {days}.");
        }
    }
}
