public class Process
{
    string processName;
    int burstTime;
    int remainingTime;
    int waitingTime;

    public Process (string name, int bt)
    {
        processName = name;
        burstTime = bt;
        remainingTime = bt;
        waitingTime = 0;
    }

    public List<Process> genDataset(int n)
    {
        List<Process> res = new List<Process>();
        return res;
    }

    public void updateRemaining (int value)
    {
        remainingTime = remainingTime-value;
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
    Queue<Process> queue = new Queue<Process>();
    int timeSlot = 3;
    List<Process> data;

    public RoundRobin (List<Process> d)
    {
        data.AddRange(d); //copy the dataset into the RoundRobin's property variable
    }


    public void insertProcess(Process x)
    {

    }

    public void runRoundRobin ()
    {
        while(data.Count > 0)
        {
            
        }
    }
}