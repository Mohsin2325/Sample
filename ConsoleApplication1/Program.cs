using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //B b = new B();
            //b.Display();
            A a = new C();
            a.Display();

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
                HttpWebRequest re = HttpWebRequest.CreateHttp("http://localhost:82/PayMentService.svc/paybill/1");
                re.Method = "GET";
                re.ContentType = "application/json";
                re.ContentLength = 0;
                HttpWebResponse response = re.GetResponse() as HttpWebResponse;
                //byte[] bt = new byte[1000];
                //MemoryStream st = new MemoryStream(response.GetResponseStream().Read(bt,0,1000));
                Stream st = response.GetResponseStream();
                //st.Read(bt, 0, 1000);
                string content = string.Empty;
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
                DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(Employee));
                object emp = (Employee)ds.ReadObject(st);
            #endregion

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

    class D
    {
        private static D instance;


        private D()
        {

        }
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
    }
}
