using System.Runtime.CompilerServices;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases


        // Test 1
        // Scenario: See if 10 accounts can be added to queue
        // Expected Result: Should add correctly

        Console.WriteLine("Test 1");

        var cs1 = new CustomerService(10);

        // Add customers
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Adding customer {i}");
        }

        Console.WriteLine(cs1);

        // Defect(s) Found: Queue is still 0, because the infomratio required is private

        Console.WriteLine("=================");



        // Test 2
        // Scenario: See if 12 accounts can be added to queue
        // Expected Result: Should NOT allow more than 10 customers

        Console.WriteLine("Test 2");

        var cs2 = new CustomerService(10);

        for (int i = 1; i <= 12; i++)
        {
            Console.WriteLine($"Adding customer {i}");
        }

        Console.WriteLine(cs2);

        // Defect(s) Found: Is not limiting the customers to 10

        Console.WriteLine("=================");



        // Test 3
        // Scenario: Serve a customer from queue
        // Expected Result: First customer should be removed and displayed

        Console.WriteLine("Test 3");

        var cs3 = new CustomerService(5);

        Console.WriteLine(cs3);

        // Defect(s) Found: Queue list empty

        Console.WriteLine("=================");



        // Test 4
        // Scenario: Serve customer from empty queue
        // Expected Result: Error message should display

        Console.WriteLine("Test 4");

        var cs4 = new CustomerService(5);

        Console.WriteLine("Attempt to serve customer from empty queue.");

        // Defect(s) Found: This one is good, because the list is empty

        Console.WriteLine("=================");



        // Test 5
        // Scenario: Create queue with invalid size
        // Expected Result: Queue size should default to 10

        Console.WriteLine("Test 5");

        var cs5 = new CustomerService(0);

        Console.WriteLine(cs5);

        // Defect(s) Found: None

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    public class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        public string Name { get; }
        public string AccountId { get; }
        public string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    public void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    public void ServeCustomer()
    {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}