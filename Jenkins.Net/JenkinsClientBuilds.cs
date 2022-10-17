using JenkinsNET.Exceptions;
using JenkinsNET.Internal.Commands;
using JenkinsNET.Models;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace JenkinsNET
{
    /// <summary>
    /// A collection of methods used for interacting with Jenkins Builds.
    /// </summary>
    /// <remarks>
    /// Used internally by <seealso cref="JenkinsClient"/>
    /// </remarks>
    public sealed class JenkinsClientBuilds
    {
        private readonly IJenkinsContext context;


        internal JenkinsClientBuilds(IJenkinsContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets information describing a Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <exception cref="JenkinsJobGetBuildException"></exception>
        public T Get<T>(string jobName, string buildNumber) where T : class, IJenkinsBuild
        {
            try {
                var cmd = new BuildGetCommand<T>(context, jobName, buildNumber);
                cmd.Run();
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsJobGetBuildException($"Failed to retrieve build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

    #if NET_ASYNC
        /// <summary>
        /// Gets information describing a Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsJobGetBuildException"></exception>
        public async Task<T> GetAsync<T>(string jobName, string buildNumber, CancellationToken token = default) where T : class, IJenkinsBuild
        {
            try {
                var cmd = new BuildGetCommand<T>(context, jobName, buildNumber);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsJobGetBuildException($"Failed to retrieve build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }
    #endif

        /// <summary>
        /// Gets the console output from a Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public string GetConsoleText(string jobName, string buildNumber)
        {
            try {
                var cmd = new BuildTextCommand(context, jobName, buildNumber);
                cmd.Run();
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve console output from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

    #if NET_ASYNC
        /// <summary>
        /// Gets the console output from a Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public async Task<string> GetConsoleTextAsync(string jobName, string buildNumber, CancellationToken token = default)
        {
            try {
                var cmd = new BuildTextCommand(context, jobName, buildNumber);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve console output from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }
    #endif

        /// <summary>
        /// Gets the console output from a Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public string GetConsoleHtml(string jobName, string buildNumber)
        {
            try {
                var cmd = new BuildHtmlCommand(context, jobName, buildNumber);
                cmd.Run();
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve console output from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

    #if NET_ASYNC
        /// <summary>
        /// Gets the console output from a Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public async Task<string> GetConsoleHtmlAsync(string jobName, string buildNumber, CancellationToken token = default)
        {
            try {
                var cmd = new BuildHtmlCommand(context, jobName, buildNumber);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve console output from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }
    #endif

        /// <summary>
        /// Gets the progressive text output from a Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="start">The character position to begin reading from.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public JenkinsProgressiveTextResponse GetProgressiveText(string jobName, string buildNumber, int start)
        {
            try {
                var cmd = new BuildProgressiveTextCommand(context, jobName, buildNumber, start);
                cmd.Run();
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve progressive text from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

    #if NET_ASYNC
        /// <summary>
        /// Gets the progressive text output from a Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="start">The character position to begin reading from.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public async Task<JenkinsProgressiveTextResponse> GetProgressiveTextAsync(string jobName, string buildNumber, int start, CancellationToken token = default)
        {
            try {
                var cmd = new BuildProgressiveTextCommand(context, jobName, buildNumber, start);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve progressive text from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }
    #endif

        /// <summary>
        /// Gets the console output from a Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="start">The character position to begin reading from.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public JenkinsProgressiveHtmlResponse GetProgressiveHtml(string jobName, string buildNumber, int start)
        {
            try {
                var cmd = new BuildProgressiveHtmlCommand(context, jobName, buildNumber, start);
                cmd.Run();
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve progressive HTML from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

    #if NET_ASYNC
        /// <summary>
        /// Gets the console output from a Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="start">The character position to begin reading from.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public async Task<JenkinsProgressiveHtmlResponse> GetProgressiveHtmlAsync(string jobName, string buildNumber, int start, CancellationToken token = default)
        {
            try {
                var cmd = new BuildProgressiveHtmlCommand(context, jobName, buildNumber, start);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve progressive HTML from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }


        /// <summary>
        /// Stop a running build
        /// </summary>
        /// <param name="jobName">You can use a job url and set <paramref name="buildNumber"/> to null</param>
        /// <param name="buildNumber"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> StopBuildAsync(string jobName, string buildNumber, CancellationToken token = default)
        {
            try
            {
                var cmd = new BuildStopCommand(context, jobName, buildNumber);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (WebException webException)
            {
                if (webException.Message.Contains("(403) Forbidden")) //WTF, it returns 403 but still does the job
                {
                    return true;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        /// Set description for a build
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="buildNumber"></param>
        /// <param name="description"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> SetBuildDescriptionAsync(string jobName, string buildNumber, string description,
            CancellationToken token = default)
        {
            try
            {
                var cmd = new BuildSetDescriptionCommand(context, jobName, buildNumber, description);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (WebException webException)
            {
                if (webException.Message.Contains("(403) Forbidden")) //WTF, it returns 403 but still does the job
                {
                    return true;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return false;
        }
#endif
        /// <summary>
        /// Stop a running build
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="buildNumber"></param>
        /// <returns></returns>
        public bool StopBuild(string jobName, string buildNumber)
        {
            try
            {
                var cmd = new BuildStopCommand(context, jobName, buildNumber);
                cmd.Run();
                return cmd.Result;
            }
            catch (WebException webException)
            {
                if (webException.Message.Contains("(403) Forbidden")) //WTF, it returns 403 but still does the job
                {
                    return true;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return false;
        }
    }
}
