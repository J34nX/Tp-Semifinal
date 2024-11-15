namespace TPsemiFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "-Thread Starts-";

            Thread threadA = new Thread(MyThreadClass.Thread1);
            Thread threadB = new Thread(MyThreadClass.Thread2);
            Thread threadC = new Thread(MyThreadClass.Thread1);
            Thread threadD = new Thread(MyThreadClass.Thread2);

            threadA.Priority = ThreadPriority.Highest;
            threadB.Priority = ThreadPriority.Normal;
            threadC.Priority = ThreadPriority.AboveNormal;
            threadD.Priority = ThreadPriority.BelowNormal;

            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            label1.Text = "-End of Thread-";
        }

        public static class MyThreadClass
        {
            public static void Thread1()
            {
                for (int i = 0; i < 2; i++)
                {
                    Thread thread = Thread.CurrentThread;
                    Console.WriteLine($"Name of Thread: {thread.Name} Process = {i}");
                    Thread.Sleep(500);
                }
            }

            public static void Thread2()
            {
                for (int i = 0; i < 6; i++)
                {
                    Thread thread = Thread.CurrentThread;
                    Console.WriteLine($"Name of Thread: {thread.Name} Process = {i}");
                    Thread.Sleep(1500);
                }
            }

        }
    }
}

