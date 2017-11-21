using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Employee ep = new Employee() { ID=1,EmpName="Mohsin",evm=new ExpanderVM()};
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ep;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(execute));
            t.Name = "Mohsin";
            t.Start();
        }

        public void execute()
        {
            //Dispatcher.Invoke(() =>
            //{
            //    textBlock.Text = "Current Thread " + Thread.CurrentThread.ManagedThreadId.ToString();
            //}
            //

            DispatcherOperation dp=Dispatcher.BeginInvoke((Action) (() =>
            {
                textBlock.Text = "Current Thread " + Thread.CurrentThread.ManagedThreadId.ToString();
            }));
            dp.Completed += Dp_Completed;
            CancellationToken ct = new CancellationToken();
            
            Task<Employee> tk = new Task<Employee>(
                () => {
                    
                    return new Employee() { ID=3,EmpName="Hello"};
                },ct
                );
            tk.Start();
                        
            Dispatcher.BeginInvoke(

                  (Action<string>)( (args) => { button.Content =args; }),"world"
                    
                );
            //tk.ContinueWith<>
            
        }

        private void Dp_Completed(object sender, EventArgs e)
        {
            SqlConnection con = null;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

            try
            {
                con.Open();

                SqlDataAdapter ad = new SqlDataAdapter("select * from employee", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                
            }
            catch (Exception ex)
            {
                con.Close();

                
            }
            finally
            {
                con.Close();
            }
        }
        HttpWebRequest re = HttpWebRequest.CreateHttp("http://localhost:82/PayMentService.svc/paybill/1");
        private void textBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int i = 0;
            Action t = () => i = 2;
            Predicate<object> p = (pp) => pp.ToString().Equals("1");
            // Func<string, object> fn = (fp, p) =>  p = 5;
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
            svc.ClientCredentials.UserName.UserName = "a";
            svc.ClientCredentials.UserName.Password = "a";
            //ServiceReference2.PayMentServiceClient pvc = new ServiceReference2.PayMentServiceClient();
           
            try
            {
                textBlock.Text = svc.GetData(10);
                
               // re.Method = "PUT";
               // re.ContentType = "application/json";
               // re.ContentLength = 0;
               // //re.BeginGetResponse(null, null);
               // //var request = (HttpWebRequest)re.GetResponse(("http://localhost:82/PayMentService.svc/paybill/1/htt");
               // //re.BeginGetRequestStream(BuildRequest, null);
               //HttpWebResponse response = re.GetResponse() as HttpWebResponse;
               // //byte[] bt = new byte[1000];
               // //MemoryStream st = new MemoryStream(response.GetResponseStream().Read(bt,0,1000));
               // Stream st = response.GetResponseStream();
               // //st.Read(bt, 0, 1000);
                
               // //while(st.ReadByte()!=-1)
               // //{

               // //}
               // //st.Position = 0;
               // DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(Employee));
               //object emp=(Employee) ds.ReadObject(st);
                
                //long pt = st.Length;

            }
            catch (FaultException<ServiceReference1.FaultDemo> ex)
            {
                textBlock.Text = ex.Message;
                
            }
            
        }
        protected void BuildRequest(IAsyncResult result)
        {
            // Get the operation state
            object userState = result.AsyncState;

            Stream postStream = re.EndGetRequestStream(result);

           //string postData = _operation.GetMessageBody(re);

           // byte[] byteArray = Encoding.UTF8.GetBytes(postData);

           // // Write to the request stream
           // postStream.Write(byteArray, 0, byteArray.Length);
           // postStream.Close();
        }

        private void textBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
            svc.ClientCredentials.UserName.UserName = "a";
            svc.ClientCredentials.UserName.Password = "a";
            //ServiceReference2.PayMentServiceClient pvc = new ServiceReference2.PayMentServiceClient();

            try
            {
                textBlock.Text = svc.GetData(10);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
