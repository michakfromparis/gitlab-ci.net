using System.Collections.Generic;
using Gitlab.Ci.Models;

namespace Gitlab.Ci
{
    public interface ICiRunnerClient
    {
        /// <summary>
        /// Get a list of projects accessible by the authenticated user.
        /// </summary>
        IEnumerable<CiRunner> Accessible { get; }

        /// <summary>
        /// Get a list of projects owned by the authenticated user.
        /// </summary>
        IEnumerable<CiRunner> Owned { get; }

        /// <summary>
        /// Get a list of all GitLab projects (admin only).
        /// </summary>
        IEnumerable<CiRunner> All { get; }

        CiRunner this[int id] { get; }

//        CiRunner Create(CiRunnerCreate project);
        
        CiRunner Delete(int id);
    }
}