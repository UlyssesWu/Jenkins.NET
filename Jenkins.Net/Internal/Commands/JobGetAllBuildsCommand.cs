using System;
using System.IO;
using System.Xml.Serialization;
using JenkinsNET.Models;

namespace JenkinsNET.Internal.Commands
{
    internal class JobGetAllBuildsCommand : JenkinsHttpCommand
    {
        public freeStyleProject Result { get; private set; }


        public JobGetAllBuildsCommand(IJenkinsContext context, string jobName, string requiredFields = "*", int beginIndex = 0,
            int endIndex = 200)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (string.IsNullOrEmpty(jobName))
                throw new ArgumentException("Value cannot be empty!", nameof(jobName));

            Url = NetPath.Combine(context.BaseUrl, "job", jobName,
                $"api/xml?tree=allBuilds[{requiredFields}]{{{beginIndex},{endIndex}}}");

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