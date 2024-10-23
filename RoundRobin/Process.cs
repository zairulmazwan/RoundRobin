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
    int tiimeSlot = 3;

    public void insertProcess(Process x)
    {

    }
}