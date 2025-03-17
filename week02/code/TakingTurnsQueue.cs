/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly Queue<QueueMember> _queue = new();  // Using "QueueMember" to avoid conflicts

    public int Length => _queue.Count;

    /// <summary>
    /// Add a new person to the queue with a name and number of turns.
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var individual = new QueueMember(name, turns);
        _queue.Enqueue(individual);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public QueueMember GetNextPerson()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        QueueMember individual = _queue.Dequeue();

        if (individual.Turns > 1)
        {
            individual.Turns -= 1;
            _queue.Enqueue(individual);
        }
        else if (individual.Turns <= 0)
        {
            _queue.Enqueue(individual);
        }

        return individual;
    }

    public override string ToString()
    {
        return $"Queue: [{string.Join(", ", _queue)}]";
    }
}

/// <summary>
/// Defines a QueueMember (formerly Person) to avoid conflicts with other "Person" classes.
/// </summary>
public class QueueMember
{
    public string Name { get; }
    public int Turns { get; set; }

    public QueueMember(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    public override string ToString()
    {
        return $"{Name} ({Turns} turns left)";
    }
}