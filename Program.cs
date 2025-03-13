using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Customer customer = new GoldCustomerRegister
            {
                CustomerId = 2,
                FirstName = "Kohinoor",
                LastName = "Tiwari",
                Email = "tiwarikohinoor@gmail.com"
            };
            customer.Register();

            ICustomerGetDiscount newDiscount = new GoldCustomerDiscount();
            newDiscount.CustomerDiscountPercentage();

            IProcessOrder process = new ProcessOrderCLass(newDiscount);
            process.ProcessOrder();
        }
    }
  
    
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual void Register()
        {
            Console.WriteLine("Customer is Registered!!");
        }
    }

    public class PlatinumCustomerRegister : Customer
    {
        public override void Register()
        {
            Console.WriteLine($"{FirstName} is registered as a platinum customer!!");
        }
    }

    public class GoldCustomerRegister : Customer
    {
        public override void Register()
        {
            Console.WriteLine($"{FirstName} is registered as a gold customer!!");
        }

    }

    public class SilverCustomerRegister : Customer
    {
        public override void Register()
        {
            Console.WriteLine($"{FirstName} is registered as a silver customer!!");
        }
    }

    public class BronzeCustomerRegister : Customer
    {
        public override void Register()
        {
            Console.WriteLine($"{FirstName} is registered as a bronze customer!!");
        }
    }



    public interface ISaveCustomer
    {
        bool SaveCustomer();
    }

    public class SavedCustomer : ISaveCustomer
    {
        private Customer _customer;

        public SavedCustomer(Customer customer)
        {
            _customer = customer;
        }

        public bool SaveCustomer()
        {
            Console.WriteLine($"{_customer.FirstName} is saved to th db.");
            return true;
        }

    }

    public interface ICustomerGetDiscount
    {
        int CustomerDiscountPercentage();
    }

    public class PlatinumCustomerDiscount : ICustomerGetDiscount
    {
        public int CustomerDiscountPercentage()
        {
            return 20;
        }
    }

    public class GoldCustomerDiscount : ICustomerGetDiscount
    {
        public int CustomerDiscountPercentage()
        {
            return 25;
        }
    }


    public class SilverCustomerDiscount : ICustomerGetDiscount
    {
        public int CustomerDiscountPercentage()
        {
            return 15;
        }
    }

    public class BronzeCustomerDiscount : ICustomerGetDiscount
    {
        public int CustomerDiscountPercentage()
        {
            return 25;
        }
    }


    public interface IProcessOrder
    {
        void ProcessOrder();
    }

    public class ProcessOrderCLass : IProcessOrder
    {
        private ICustomerGetDiscount _getDiscount;

        public ProcessOrderCLass(ICustomerGetDiscount  getDiscount)
        {
            _getDiscount = getDiscount;
        }

        public void ProcessOrder()
        {
            var discount = _getDiscount.CustomerDiscountPercentage();
            Console.WriteLine($"Customer has got discount of {discount}");
            Console.WriteLine("Order is Placed");
        }


    }

    public class Leads
    {
        public string name;
        public string email;

        public void GetLeadDetails()
        {
            Console.WriteLine($"chating with {name} ");
        }
    }
}


    

    
    
         
    
 


