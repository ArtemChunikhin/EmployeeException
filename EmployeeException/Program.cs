using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeException
{
    struct Worker
    {
        public String FullNameEmployee { get; set; }
        public String Position { get; set; }
        public DateTime DateOfHire { get; set; }
        public Int32 Experience { get; set; }
    }

    internal static class UI
    {
        private const Int32 countElements = 5;
        public static Worker[] Input()
        {
            Worker[] workers = new Worker[countElements];
            Worker worker = new Worker();
            try
            {
                for (int i = 0; i < countElements; i++)
                {
                    Console.Write("Enter Full Name: ");
                    worker.FullNameEmployee = Console.ReadLine();

                    Console.Write("\nEnter Position: ");
                    worker.Position = Console.ReadLine();

                    Console.Write("\nEnter Date Of Hire: ");
                    worker.DateOfHire = DateTime.Parse(Console.ReadLine());

                    Console.Write("\nEnter an experience: ");
                    worker.Experience = Int32.Parse(Console.ReadLine());
                    workers[i] = worker;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return workers;
        }

        public static void Output(Worker[] workers)
        {
            foreach (Worker emp in workers)
            {
                Console.WriteLine("************");
                Console.WriteLine("[Full Name {0}]\n[Position: {1}]\n[Date: {2}]\nExperience", emp.FullNameEmployee, emp.Position,
                                                                                    emp.DateOfHire.ToShortDateString(), 
                                                                                    emp.Experience);
                Console.WriteLine("************");
            }
        }
        public static void Output(Worker worker)
        {
            Console.WriteLine("************");
            Console.WriteLine("[Full Name {0}]\n[Position: {1}]\n[Date: {2}]\nExperience", worker.FullNameEmployee,
                                                                                    worker.Position,
                                                                                    worker.DateOfHire.ToShortDateString(),
                                                                                    worker.Experience);
            Console.WriteLine("************");
        }
    }

    internal class WorkerService
    {
        private Int32 experience;
        private Worker tmp;
        public Worker[] WorkerSort(Worker[] workers)
        {
            for (int i = 0; i < workers.Length - 1; i++)
            {
                for (int j = i + 1; j < workers.Length; j++)
                {
                    if (String.Compare(workers[i].FullNameEmployee, workers[j].FullNameEmployee) > 0)
                    {
                        tmp = workers[i];
                        workers[i] = workers[j];
                        workers[j] = tmp;
                    }
                }
            }
            return workers;
        }
        public void FilterByExperience(Worker[] workers)
        {
            try
            {
                Console.Write("Enter employee`s experience: ");
                experience = Int32.Parse(Console.ReadLine());
                foreach (Worker worker in workers)
                {
                    if (worker.Experience > experience)
                    {
                        UI.Output(worker);
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WorkerService workerService = new WorkerService();
            Worker[] workers = UI.Input();
            workerService.WorkerSort(workers);
            UI.Output(workers);
            workerService.FilterByExperience(workers);
        }
    }
}
