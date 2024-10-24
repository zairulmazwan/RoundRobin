using System.Data;

public class Process
{
    public string processName;
    int burstTime;
    int remainingTime;
    public int prevSlot = 0;
    public int waitingTime = 0;

    public Process (string name, int bt)
    {
        processName = name;
        burstTime = bt;
        remainingTime = bt;
    }

    public void updateRemaining (int value)
    {
        remainingTime = remainingTime-value;
    }

    public void updateWaitingTime (int value)
    {
        waitingTime += value;
    }

    public void updatePrevSlot(int ps)
    {
        prevSlot = ps;
    }
    public int getRemaining ()
    {
        return remainingTime;
    }

    public void printProcessInfo()
    {
        Console.WriteLine("Name : "+processName);
        Console.WriteLine("Burst time remaining : "+remainingTime);
    }

}

public class RoundRobin 
{
    List<Process> processed = new List<Process>();
    int timeSlot = 3;
    int currentSlot = 0;
    Queue<Process> data = new Queue<Process>();

    public RoundRobin (int n)
    {
        genDataset(n);   //copy the dataset into the RoundRobin's property variable
    }

    public void genDataset(int n)
    {
        for(int i=0; i<n; i++)
        {
            Random r = new Random();
            int bt = r.Next(3,12);
            Process p = new Process("P_"+(i+1), bt);
            data.Enqueue(p);
        }
    }

    public void insertProcess()
    {
        Process x = data.Dequeue();
        processed.Add(x);
        x.updateWaitingTime(currentSlot-x.prevSlot);
        currentSlot += (x.getRemaining()<timeSlot) ? x.getRemaining():timeSlot;
        x.updateRemaining(timeSlot); 
        x.updatePrevSlot(currentSlot);

        if(x.getRemaining() > 0)
        {
            data.Enqueue(x);
        }
    }

    public void runRoundRobin ()
    {
        while(data.Count > 0)
        {
            // Console.WriteLine("Process...");
            insertProcess();
        }
        printRes();
    }

    public void printQueue()
    {
        Console.WriteLine("There are "+data.Count+" processes in the queue");

        foreach(Process x in data)
        {
            Console.Write(x.processName);
            Console.Write("\t"+x.getRemaining());
            Console.WriteLine();
        }
    }

    public void printRes ()
    {
         Console.WriteLine("All processes have been attended");
          foreach(Process x in processed)
        {
            Console.Write(x.processName);
            Console.Write("\tWaiting time: "+x.waitingTime);
            Console.WriteLine();
        }
    }
}