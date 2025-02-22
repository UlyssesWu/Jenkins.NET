﻿using System;
using System.IO;
using System.Text;

namespace JenkinsNET.Internal.Commands
{
    internal class BuildTextCommand : JenkinsHttpCommand
    {
        public string Result {get; private set;}


        public BuildTextCommand(IJenkinsContext context, string jobName, string buildNumber)
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

            if (useDirectUrl)
            {
                Url = NetPath.Combine(jobName, "consoleText");
            }
            else
            {
                Url = NetPath.Combine(context.BaseUrl, "job", jobName, buildNumber, "consoleText");
            }

            UserName = context.UserName;
            ApiToken = context.ApiToken;
            Crumb = context.Crumb;

            OnRead = response => {
                using (var stream = response.GetResponseStream()) {
                    if (stream == null) return;

                    var encoding = string.IsNullOrEmpty(response.ContentEncoding) ? Encoding.UTF8 : TryGetEncoding(response.ContentEncoding, Encoding.UTF8);
                    using (var reader = new StreamReader(stream, encoding)) {
                        Result = reader.ReadToEnd();
                    }
                }
            };

        #if NET_ASYNC
            OnReadAsync = async (response, token) => {
                using (var stream = response.GetResponseStream()) {
                    if (stream == null) return;

                    var encoding = string.IsNullOrEmpty(response.ContentEncoding)? Encoding.UTF8 : TryGetEncoding(response.ContentEncoding, Encoding.UTF8);
                    Result = await stream.ReadToEndAsync(encoding, token);
                }
            };
        #endif
        }
    }
}
