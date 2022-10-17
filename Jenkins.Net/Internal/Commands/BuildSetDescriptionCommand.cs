using System;
using System.Net;
using System.Web;

namespace JenkinsNET.Internal.Commands
{
    internal class BuildSetDescriptionCommand : JenkinsHttpCommand
    {
        public bool Result { get; private set; } = true;
        public BuildSetDescriptionCommand(IJenkinsContext context, string jobName, string buildNumber, string description)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (string.IsNullOrEmpty(jobName))
                throw new ArgumentException("'jobName' cannot be empty!");

            bool useDirectUrl = false;
            if (string.IsNullOrEmpty(buildNumber))
            {
                if (jobName.StartsWith("http://") || jobName.StartsWith("https://"))
                {
                    useDirectUrl = true;
                }
                else
                {
                    throw new ArgumentException("'buildNumber' cannot be empty!");
                }
            }

            var descParameter = $"submitDescription?description={HttpUtility.UrlEncode(description)}";

            if (useDirectUrl)
            {
                Url = NetPath.Combine(jobName, descParameter);
            }
            else
            {
                Url = NetPath.Combine(context.BaseUrl, "job", jobName, buildNumber, descParameter);
            }

            UserName = context.UserName;
            ApiToken = context.ApiToken;
            Crumb = context.Crumb;

            OnWrite = request => {
                request.Method = "POST";
            };

            OnRead = response =>
            {
                Result = response.StatusCode == HttpStatusCode.OK;
            };

#if NET_ASYNC
            OnWriteAsync = async (request, token) => {
                request.Method = "POST";
            };

            OnReadAsync = async (response, token) => {
                Result = response.StatusCode == HttpStatusCode.OK;
            };
#endif
        }
    }
}
