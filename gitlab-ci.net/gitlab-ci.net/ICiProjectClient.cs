using System.Collections.Generic;
using Gitlab.Ci.Models;

namespace Gitlab.Ci
{
    public interface ICiProjectClient
    {
        /// <summary>
        /// Get a list of projects accessible by the authenticated user.
        /// </summary>
        IEnumerable<CiProject> Accessible { get; }

        /// <summary>
        /// Get a list of projects owned by the authenticated user.
        /// </summary>
        IEnumerable<CiProject> Owned { get; }

        /// <summary>
        /// Get a list of all GitLab projects (admin only).
        /// </summary>
        IEnumerable<CiProject> All { get; }

        CiProject this[int id] { get; }

        CiProject Create(CiProjectCreate project);
        
        bool Delete(int id);
    }
}