using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adds cases to the queue in the correct priority, and dequeues correctly
    // Expected Result: A, C, B
    // Defect(s) Found: A is not qeueing from the queue correctly and is returning to the queue 
    public void TestPriorityQueue_1()
    {
        var A = new PriorityItem("A", 5);
        var B = new PriorityItem("B", 1);
        var C = new PriorityItem("C", 3);

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(A.Value, A.Priority);
        priorityQueue.Enqueue(B.Value, B.Priority);
        priorityQueue.Enqueue(C.Value, C.Priority);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());

        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: If there is multiple items with the high priority that the order still goes FIFO
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var A = new PriorityItem("A", 5);
        var B = new PriorityItem("B", 1);
        var C = new PriorityItem("C", 3);
        var D = new PriorityItem("D", 5);

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(A.Value, A.Priority);
        priorityQueue.Enqueue(B.Value, B.Priority);
        priorityQueue.Enqueue(C.Value, C.Priority);
        priorityQueue.Enqueue(D.Value, D.Priority);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());


        //Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Of there is nothing in the queue an the "The queue is empty message is shown
    // Expected Result: The queue is empty.
    // Defect(s) Found: None found
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
            string.Format("Unexpected exception of type {0} caught: {1}",
            e.GetType(), e.Message)
         );
        }
    }




}
