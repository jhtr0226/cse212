using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities and dequeue them.
    // Expected Result: The highest-priority item should be dequeued first.
    // Defect(s) Found: None.
    public void TestPriorityQueue_EnqueueAndDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("HighPriority", 3);
        priorityQueue.Enqueue("MediumPriority", 2);

        Assert.AreEqual("HighPriority", priorityQueue.Dequeue());
        Assert.AreEqual("MediumPriority", priorityQueue.Dequeue());
        Assert.AreEqual("LowPriority", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same priority and ensure FIFO ordering.
    // Expected Result: Items with the same priority should be dequeued in the order they were added.
    // Defect(s) Found: None.
    public void TestPriorityQueue_FifoSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found: None.
    public void TestPriorityQueue_EmptyDequeue()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add an item with a very low priority and make sure it dequeues last.
    // Expected Result: The item with priority 0 should be dequeued last.
    // Defect(s) Found: None.
    public void TestPriorityQueue_LowestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Normal", 5);
        priorityQueue.Enqueue("Low", 0);
        priorityQueue.Enqueue("Higher", 10);

        Assert.AreEqual("Higher", priorityQueue.Dequeue());
        Assert.AreEqual("Normal", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }
}