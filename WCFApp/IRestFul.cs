using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFApp
{
    [ServiceContract]
    interface IRestFul
    {
        [OperationContract]
        [WebInvoke (Method ="GET",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json,UriTemplate ="/GETdetails",BodyStyle =WebMessageBodyStyle.Wrapped)]
        string GetDetails();
    }
}
