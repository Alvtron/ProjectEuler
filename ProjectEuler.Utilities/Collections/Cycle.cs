using System.Collections;

namespace ProjectEuler.Utilities.Collections;

public class Cycle<TElement> : IEnumerable<TElement>
{
    private readonly Queue<TElement> queue;

    public Cycle()
    {
        this.queue = new Queue<TElement>();
    }

    public Cycle(IEnumerable<TElement> elements)
    {
        this.queue = new Queue<TElement>(elements);
    }

    public TElement Next()
    {
        var item = this.queue.Dequeue();
        this.queue.Enqueue(item);

        return item;
    }

    public TElement Peek()
    {
        return this.queue.Peek();
    }

    public void Add(TElement item)
    {
        this.queue.Enqueue(item);
    }

    public IEnumerator<TElement> GetEnumerator()
    {
        return this.LoopForever().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private IEnumerable<TElement> LoopForever()
    {
        while (true)
        {
            yield return this.Next();
        }
    }
}