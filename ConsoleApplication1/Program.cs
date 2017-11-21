using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            //b.Display();
            A a = new C();
            a.Display();
            a.GetData("1");
            Task[] tk = new Task[3];
             tk[0] = new Task(()=> { a.GetData("1"); });
             tk[1] = new Task(async () => { await b.DisplayNew(); });
             tk[2]= new Task(() => { a.GetData("3"); });
            tk.ToList().ForEach(s => s.Start());
            #region GET
            //HttpWebRequest re = HttpWebRequest.CreateHttp("http://localhost:82/PayMentService.svc/paybill/1");
            //re.Method = "GET";
            //re.ContentType = "application/json";
            //re.ContentLength = 0;
            //HttpWebResponse response = re.GetResponse() as HttpWebResponse;
            ////byte[] bt = new byte[1000];
            ////MemoryStream st = new MemoryStream(response.GetResponseStream().Read(bt,0,1000));
            //Stream st = response.GetResponseStream();
            ////st.Read(bt, 0, 1000);
            //string content = string.Empty;
            //using (Stream stream = response.GetResponseStream())
            //{
            //    using (StreamReader sr = new StreamReader(stream))
            //    {
            //        content = sr.ReadToEnd();
            //    }
            //}            
            //DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(Employee));
            //object emp = (Employee)ds.ReadObject(st);
            #endregion

            #region Post
            ////Employee emp = new Employee() { EmpName="Hello",ID=3};
            ////DataContractJsonSerializer ser =
            ////   new DataContractJsonSerializer(typeof(Employee));
            ////MemoryStream mem = new MemoryStream();
            ////ser.WriteObject(mem, emp);
            ////string data =
            ////    Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            ////WebClient webClient = new WebClient();
            ////webClient.Headers["Content-type"] = "application/json";
            ////webClient.Encoding = Encoding.UTF8;
            ////webClient.UploadString("http://localhost:82/PayMentService.svc/AddPayee", "POST", data);              
            ////Console.WriteLine("Order placed successfully...");
            #endregion

            //WebClient proxy = new WebClient();
            //string serviceURL = string.Format("http://localhost:61090/OrderService.svc/GetOrderDetails/1");
            //byte[] data = proxy.DownloadData(serviceURL);
            //Stream stream = new MemoryStream(data);
            //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(OrderContract));
            //OrderContract order = obj.ReadObject(stream) as OrderContract;
            //Console.WriteLine("Order ID : " + order.OrderID);
            //Console.WriteLine("Order Date : " + order.OrderDate);
            //Console.WriteLine("Order Shipped Date : " + order.ShippedDate);
            //Console.WriteLine("Order Ship Country : " + order.ShipCountry);
            //Console.WriteLine("Order Total : " + order.OrderTotal);

            //OrderContract order = new OrderContract
            //{
            //    OrderID = "10550",
            //    OrderDate = DateTime.Now.ToString(),
            //    ShippedDate = DateTime.Now.AddDays(10).ToString(),
            //    ShipCountry = "India",
            //    OrderTotal = "781"
            //};

            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(OrderContract));
            //MemoryStream mem = new MemoryStream();
            //ser.WriteObject(mem, order);
            //string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            //WebClient webClient = new WebClient();
            //webClient.Headers["Content-type"] = "application/json";
            //webClient.Encoding = Encoding.UTF8;
            //webClient.Credentials = new NetworkCredential("mm", "mm");
            //webClient.UploadString("http://localhost:61090/OrderService.svc/PlaceOrder", "POST", data);
            //Console.WriteLine("Order placed successfully...");

            //WebClient webClient = new WebClient();
            //webClient.Headers["Content-type"] = "application/json";
            //webClient.Encoding = Encoding.UTF8;
            //// webClient.UseDefaultCredentials = true;
            //webClient.Credentials = new NetworkCredential("abc","def");
            ////webClient.Headers["Authorization"] = "ABC";
            //byte[] gt=webClient.DownloadData("http://localhost:61090/OrderService.svc/GetOrderDetails/1");
            //Stream ss = new MemoryStream(gt);
            //DataContractJsonSerializer dx = new DataContractJsonSerializer(typeof(OrderContract));
            //OrderContract str=dx.ReadObject(ss) as OrderContract;
            Console.ReadLine();
        }
    }

    abstract class A
    {
        const string st="";
        readonly string tp;
        public A()
        {
            tp = "";
            Console.WriteLine("A ctor");
        }
        static A()
        {
           // A.tp="";
            Console.WriteLine("In static A");
        }

        public virtual void Display()
        {
            
            Console.WriteLine("In A");
        }
    }

    static class D
    {
       // private static D instance;

        static D()
        {

        }
        public static void GetData(this A aa,string p)
        {
            //lock(aa)
            try
            {
                Monitor.Enter(aa);
                {
                    Console.Write("extension thread" + p);
                    //throw new Exception(); test
                }
                
            }
            catch (Exception ex)
            {

                string st = ex.ToString();
            }
            finally
            {
                Monitor.Exit(aa);
            }
        }
        //private D()
        //{

        //}
    }
    class C : B
    {
        public C()
        {
            Console.WriteLine("C ctor");
        }
        public new void Display()
        {
            Console.WriteLine("In C");
        }
    }
    class B:A
    {
        public B()
        {
            Console.WriteLine("B vtor");
        }
        static B()
        {
            Console.WriteLine("In static B");
        }
         public override void Display()
        {
            Console.WriteLine("In B");
        }

        public async Task DisplayNew()
        {
            //return Task.Run(() =>
            //{
            //    for (int i = 0; i < 2000000; i++)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}
            //);

            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                }
            });

        }
    }
}
