﻿using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncHttpGetActivityLibrary
{
    public class AsyncHttpGetAsyncActivity : AsyncCodeActivity<string>
    {
        public InArgument<string> Uri { get; set; }

        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback,
            object state)
        {
            WebRequest request = HttpWebRequest.Create(this.Uri.Get(context));
            context.UserState = request;
            return request.BeginGetResponse(callback, state);
        }

        protected override string EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            WebRequest request = context.UserState as WebRequest;
            using (WebResponse response = request.EndGetResponse(result))
            {
                using (StreamReader reader =
                    new StreamReader(response.GetResponseStream()))
                {

                    return reader.ReadToEnd();
                }
            }
        }
    }
}
