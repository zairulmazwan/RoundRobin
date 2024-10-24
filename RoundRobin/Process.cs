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
    Queue<Process> queue = new Queue<Process>();
    int numOfProcess;

    public RoundRobin (int n)
    {
        numOfProcess = n;
        genDataset(n);   //copy the dataset into the RoundRobin's property variable
    }

    public void genDataset(int n)
    {
        for(int i=0; i<n; i++)
        {
            Random r = new Random();
            int bt = r.Next(3,12);
            Process p = new Process("P_"+(i+1), bt);
            queue.Enqueue(p);
        }
    }

    public void insertProcess()
    {
        Process x = queue.Dequeue(); //take the process from the queue on FIFO basis
        processed.Add(x); //attend the process
        x.updateWaitingTime(currentSlot-x.prevSlot); //update the waiting time of the process
        currentSlot += (x.getRemaining()<timeSlot) ? x.getRemaining():timeSlot; //update the current slot after the process
        x.updateRemaining(timeSlot); //update the remaining burst time for the process
        x.updatePrevSlot(currentSlot); //update the process' slot

        if(x.getRemaining() > 0) //if the process still has burst time, insert the process back into the queue
        {
            queue.Enqueue(x);
        }
    }

    public void runRoundRobin ()
    {
        while(queue.Count > 0)
        {
            insertProcess();
        }
        printRes();
    }

    public void printQueue()
    {
        Console.WriteLine("There are "+queue.Count+" processes in the queue");

        foreach(Process x in queue)
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
            // Console.Write("\tWaiting time: "+x.waitingTime);
            Console.WriteLine();
        }
        for(int i=0; i<numOfProcess; i++)
        {
            Console.WriteLine("Process "+processed[i].processName+" waiting time is "+processed[i].waitingTime);
        }
    }
}