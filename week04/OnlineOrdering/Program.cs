class Program
{
    static void Main(string[] args)
    {
        
        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "NY",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

     
        Product product1 = new Product(
            "Laptop",
            "P001",
            800,
            1
        );

        Product product2 = new Product(
            "Mouse",
            "P002",
            25,
            2
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);


      
        Address address2 = new Address(
            "15 Allen Avenue",
            "Lagos",
            "Lagos",
            "Nigeria"
        );

        Customer customer2 = new Customer(
            "David Johnson",
            address2
        );

        
        Product product3 = new Product(
            "Keyboard",
            "P003",
            50,
            1
        );

        Product product4 = new Product(
            "Monitor",
            "P004",
            200,
            2
        );

        Product product5 = new Product(
            "USB Cable",
            "P005",
            10,
            3
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);


        
        System.Console.WriteLine("========== ORDER 1 ==========");
        System.Console.WriteLine(order1.GetPackingLabel());
        System.Console.WriteLine(order1.GetShippingLabel());
        System.Console.WriteLine($"TOTAL PRICE: ${order1.GetTotalCost():F2}");

        System.Console.WriteLine();

   
        System.Console.WriteLine("========== ORDER 2 ==========");
        System.Console.WriteLine(order2.GetPackingLabel());
        System.Console.WriteLine(order2.GetShippingLabel());
        System.Console.WriteLine($"TOTAL PRICE: ${order2.GetTotalCost():F2}");
    }
}