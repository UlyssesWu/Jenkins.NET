using System;
using System.IO;
using System.Xml.Serialization;
using JenkinsNET.Models;

namespace JenkinsNET.Internal.Commands
{
    internal class JobGetBuildsCommand : JenkinsHttpCommand
    {
        public freeStyleProject Result { get; private set; }


        public JobGetBuildsCommand(IJenkinsContext context, string jobName, string requiredFields = "*", int beginIndex = 0,
            int endIndex = 100)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (string.IsNullOrEmpty(jobName))
                throw new ArgumentException("Value cannot be empty!", nameof(jobName));

            Url = NetPath.Combine(context.BaseUrl, "job", jobName,
                $"api/xml?tree=builds[{requiredFields}]{{{beginIndex},{endIndex}}}&depth=1");

            UserName = context.UserName;
            ApiToken = context.ApiToken;
            Crumb = context.Crumb;

            OnWrite = request => { request.Method = "GET"; };

            OnRead = response =>
            {
                using var reader = new StringReader(ReadString(response));
                Result = new XmlSerializer(typeof(freeStyleProject)).Deserialize(reader) as freeStyleProject;
            };

#if NET_ASYNC
            OnWriteAsync = async (request, token) => { request.Method = "GET"; };

            OnReadAsync = async (response, token) =>
            {
                using var reader = new StringReader(await ReadStringAsync(response));
                Result = new XmlSerializer(typeof(freeStyleProject)).Deserialize(reader) as freeStyleProject;
            };
        }
#endif
    }
}