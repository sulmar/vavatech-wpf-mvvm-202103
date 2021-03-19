using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vavatech.Shop.ConsoleClient
{
    class Program
    {

        // C# 7.0
        static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

        // C# 7.1
        // static async Task Main(string[] args)
        //{
        //}

        static async Task MainAsync(string[] args)
        {
            Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} Start ain ");

            // SyncTest();

            // ThreadTest();

            // TaskTest();

            await AsyncAwaitTest();

            await AsyncAwaitTest();

            await AsyncAwaitTest();


            //for (int i = 0; i < 100; i++)
            //{
            //    //Task<string> t = Task.Run(() => Download("http://www.google.com"));
            //    //t.ContinueWith(t2 => Console.WriteLine($"{t2.Result.Length}"));

            //    //Task.Run(() => Download("http://www.google.com"))  // <- t1
            //    //    .ContinueWith(t1 => Console.WriteLine($"{t1.Result.Length}"));


            //    //Task.Run(() => Download("http://www.google.com"))  // <- t1
            //    //    .ContinueWith(t1 => Download("http://www.microsoft.com"))
            //    //        .ContinueWith(t2 => Console.WriteLine($"{t2.Result}"));


            //    ContinueWithTest();


            //    //Task<string> t3 = Task.Run(() => Download("http://www.google.com"));
            //    //Task<string> t4 = Task.Run(() => Download("http://www.microsoft.com"));

            //    //Task.WaitAny(t3, t4);

            //    //int result = t1.Result.Length + t2.Result.Length;



            //}

            Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} End Main ");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void SyncTest2()
        {
            string content = Download("http://www.google.com");
            string content2 = Download($"http://www.microsoft.com/?param={content.Length}");
            Console.WriteLine($"{content2}");
        }

        private static async Task AsyncAwaitTest()
        {
            string content = await DownloadAsync("http://www.google.com").ConfigureAwait(false);
            string content2 = await DownloadAsync($"http://www.microsoft.com/?param={content.Length}");
            Console.WriteLine($"{content2.Length}");
        }

        private static void ContinueWithTest()
        {
            DownloadAsync("http://www.google.com")  // <- t1
                 .ContinueWith(t1 => DownloadAsync($"http://www.microsoft.com/?param={t1.Result.Length}"))
                     .ContinueWith(t2 => Console.WriteLine($"{t2.Result}"));
        }



        public static Task<string> DownloadAsync(string url)
        {
            return Task.Run(() => Download(url));
        }

        public static string Download(string url)
        {
            using (var client = new WebClient())
            {
                Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} Downloading {url}...");

                string content = client.DownloadString(url);

                Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} Downloaded. {url}");

                return content;
            }
        }


        private static void TaskTest()
        {
            for (int i = 0; i < 100; i++)
            {
                //Task t = new Task(() => Download("http://www.google.com"));
                //t.Start();

                // Task.Factory.StartNew(() => Download("http://www.google.com"));

                Task.Run(() => Download("http://www.google.com"));
            }
        }

        private static void ThreadTest()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread t = new Thread(() => Download("http://www.google.com"));
                t.Start();


            }
        }

        private static void SyncTest()
        {
            for (int i = 0; i < 100; i++)
            {
                Download("http://www.google.com");
            }
        }


    }
}
