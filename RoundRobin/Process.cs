public class Process
{
    string processName;
    int burstTime;
    int remainingTime;

    public Process (string name, int bt)
    {
        processName = name;
        burstTime = bt;
        remainingTime = bt;
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