using System;

class Program
{
    static void Main(string[] args)
    {
        var controller = new TaskController();
        controller.ExecuteAllTasks();
    }
}

public class TaskController
{
    public void ExecuteAllTasks()
    {
        Task1.Run();
        Task2.Run();
        Task3.Run();
        Task4.Run();
    }
}
