// See https://aka.ms/new-console-template for more information


// Process p1 = new Process("Process 1", 15);
// p1.printProcessInfo();
// p1.updateRemaining(3);
// p1.printProcessInfo();

RoundRobin rb = new RoundRobin(2);
rb.printQueue();
rb.runRoundRobin();