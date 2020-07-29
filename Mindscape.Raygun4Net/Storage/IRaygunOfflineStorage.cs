using System.Collections.Generic;
using Mindscape.Raygun4Net.Messages;

namespace Mindscape.Raygun4Net.Storage
{
  public interface IRaygunOfflineStorage
  {
    /// <summary>
    /// Persist the <paramref name="message"/>> to local storage.
    /// </summary>
    /// <param name="message">The serialized error report to store locally.</param>
    /// <param name="apiKey">The key for which these file are associated with.</param>
    /// <param name="maxReportsStored">The number of reports allowed to be stored locally.</param>
    /// <returns></returns>
    bool Store(string message, string apiKey, int maxReportsStored);

    /// <summary>
    /// Retrieve all files from local storage.
    /// </summary>
    /// <param name="apiKey">The key for which these file are associated with.</param>
    /// <returns>A container of files that are currently stored locally.</returns>
    IList<IRaygunFile> FetchAll(string apiKey);

    /// <summary>
    /// Delete a file from local storage that has the following <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The filename of the local file.</param>
    /// <param name="apiKey">The key for which these file are associated with.</param>
    /// <returns></returns>s
    bool Remove(string name, string apiKey);
  }
}