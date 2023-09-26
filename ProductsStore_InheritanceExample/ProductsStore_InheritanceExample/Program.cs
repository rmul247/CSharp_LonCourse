using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStore_InheritanceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Desks
            Product desk = new Desk();

            desk.Price = 100;
            ((Desk)desk).ImportTaxPercentage = 2;

            desk.Add();
            desk.Add();

            // Drones
            // 'Turbo' Drones
            Product turboDrone = new TurboDrone();

            turboDrone.Price = 200;

            ((Drone)turboDrone).QuantityBatchSize = 10;

            turboDrone.Add();
            turboDrone.Add();

            // 'Standard' Drones
            Drone standardDrone = new StandardDrone();

            standardDrone.Price = 150;

            standardDrone.QuantityBatchSize = 5;

            standardDrone.Add();
            standardDrone.Add();
            standardDrone.Add();

            List<Product> products = new List<Product>();

            products.Add(desk);
            products.Add(turboDrone);
            products.Add(standardDrone);

            Console.WriteLine();
            Console.WriteLine("Stock Inventory Report");
            Console.WriteLine("______________________");
            Console.WriteLine();

            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }


            decimal grandTotalStockValue = products.Sum(p => p.GetTotalValueInStock());

            Console.WriteLine();
            Console.WriteLine($"Total Value in stock is {grandTotalStockValue}");
            Console.ReadKey();
        }
    }

    public class TurboDrone : Drone
    {
        public override string ProductName
        {
            get
            {
                return "Turbo Drone";
            }
        }

    }

    public class StandardDrone : Drone
    {
        public override string ProductName
        {
            get
            {
                return "Standard Drone";
            }
        }

    }

    public class Drone : Product
    {
        public int QuantityBatchSize { get; set; }

        public override string ProductName
        {
            get
            {
                return "Drone";
            }
        }

        public Drone()
        {
            QuantityBatchSize = 1;
        }

        public override void Add()
        {
            _quantity += QuantityBatchSize;
        }

    }
    
    public class Desk : Product
    {
        public decimal ImportTaxPercentage { get; set; }
        public override string ProductName 
        { 
            get
            {
                return "Desk";
            }
        }

        public Desk()
        {

        }

        public override decimal GetTotalValueInStock()
        {
            return base.GetTotalValueInStock() * (1 - (ImportTaxPercentage/100));
        }
    }

    public abstract class Product
    {  
        protected int _quantity = 0;

        public decimal Price { get; set; }

        public Product()
        {

        }

        public abstract string ProductName { get; }

        public virtual void Add()
        {
            _quantity++;
        }

        public void Remove()
        {
            if(_quantity > 0)
            {
                _quantity--;
            }
        }

        public virtual decimal GetTotalValueInStock()
        {
            return _quantity * Price;
        }

        public override string ToString()
        {
            return $"Product Name: {ProductName}, Price: {Price}, Quantity: {_quantity}, Total Value: {GetTotalValueInStock()}";
        }
    }
}
