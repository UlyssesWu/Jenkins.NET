﻿using System;
using System.IO;
using System.Text;

namespace JenkinsNET.Internal.Commands
{
    internal class BuildHtmlCommand : JenkinsHttpCommand
    {
        public string Result {get; private set;}


        public BuildHtmlCommand(IJenkinsContext context, string jobName, string buildNumber)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (string.IsNullOrEmpty(jobName))
                throw new ArgumentException("'jobName' cannot be empty!");

            if (string.IsNullOrEmpty(buildNumber))
                throw new ArgumentException("'buildNumber' cannot be empty!");

            Url = NetPath.Combine(context.BaseUrl, "job", jobName, buildNumber, "consoleFull");
            UserName = context.UserName;
            ApiToken = context.ApiToken;
            Crumb = context.Crumb;

            OnRead = response => {
                using (var stream = response.GetResponseStream()) {
                    if (stream == null) return;

                    var encoding = TryGetEncoding(response.ContentEncoding, Encoding.UTF8);
                    using (var reader = new StreamReader(stream, encoding)) {
                        Result = reader.ReadToEnd();
                    }
                }
            };

        #if NET_ASYNC
            OnReadAsync = async (response, token) => {
                using (var stream = response.GetResponseStream()) {
                    if (stream == null) return;

                    var encoding = TryGetEncoding(response.ContentEncoding, Encoding.UTF8);
                    Result = await stream.ReadToEndAsync(encoding, token);
                }
            };
        #endif
        }
    }
}
