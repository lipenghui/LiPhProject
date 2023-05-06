namespace LiPhProject.RunTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine("running");
                    Thread.Sleep(1000);
                }
            });

            Console.ReadKey();
        }
    }
}