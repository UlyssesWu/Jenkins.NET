using System;
using JenkinsNET.Models;

namespace JenkinsNET
{
    /// <summary>
    /// Describes the context of a Jenkins.NET client.
    /// </summary>
    public interface IJenkinsContext
    {
        /// <summary>
        /// The address of the Jenkins instance.
        /// ie: http://localhost:8080
        /// </summary>
        string BaseUrl {get;}

        /// <summary>
        /// [optional] Jenkins Username.
        /// </summary>
        string UserName {get;}

        /// <summary>
        /// [optional] Jenkins ApiToken for the <see cref="UserName"/>.
        /// </summary>
        string ApiToken {get; set; }
        
        /// <summary>
        /// [optional] Jenkins CSRF Crumb.
        /// </summary>
        JenkinsCrumb Crumb {get;}
    }
}
