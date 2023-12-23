namespace _6_2_TaskManager
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

    public class TaskManager
    {
        public List<Task> Tasks { get; set; } = new List<Task>();

        public delegate void TaskCompletedHandler(Task task);
        public event TaskCompletedHandler TaskCompleted;

        public void CompleteTask(Task task)
        {
            task.Status = "выполнена";
            TaskCompleted?.Invoke(task);
        }
    }

    public class Notification
    {
        public void TaskCompletedNotification(Task task)
        {
            Console.WriteLine($"Задача {task.Title} была выполнена. Описание: {task.Description}");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager();
            taskManager.Tasks.Add(new Task { Title = "Задача 1", Description = "Описание 1" });
            taskManager.Tasks.Add(new Task { Title = "Задача 2", Description = "Описание 2" });
            taskManager.Tasks.Add(new Task { Title = "Задача 3", Description = "Описание 3" });



            var notification = new Notification();
            taskManager.TaskCompleted += notification.TaskCompletedNotification;

            foreach (var task in taskManager.Tasks)
            {
               
                taskManager.CompleteTask(task);
            }
        }
    }
}