﻿namespace Teleimot.Web.Wcf
{
    using Teleimot.Web.Wcf.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;

    [ServiceContract]
    public interface IUsers
    {
        [OperationContract]
        [WebInvoke(Method = "Get", UriTemplate = "services/users.svc")]
        IEnumerable<ListedUserModel> GetAll(string page);
    }
}
