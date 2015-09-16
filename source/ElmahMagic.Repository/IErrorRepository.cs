using System.Collections.Generic;
using System.Threading.Tasks;
using NullGuard;

namespace ElmahMagic.Repository
{
    public interface IErrorRepository
    {
        /// <summary>
        ///     Add an error to the repository.
        /// </summary>
        /// <param name="error">The error message to add.</param>
        /// <returns>
        ///     The id of the saved error.
        /// </returns>
        Task<string> AddErrorAsync(ErrorRecord error);

        /// <summary>
        ///     Gets an error from the repository.
        /// </summary>
        /// <param name="errorId">The error's id.</param>
        /// <returns>
        ///     The requested error or null if the error does not exist.
        /// </returns>
        [return: AllowNull]
        Task<ErrorRecord> GetErrorAsync(string errorId);

        /// <summary>
        ///     Get a page of errors from the repository in descending order of logged time.
        /// </summary>
        /// <param name="pageIndex">The page of errors to get.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="errors">The collection of errors to update.</param>
        /// <returns>
        ///     The total number of errors in the repository.
        /// </returns>
        Task<int> GetErrorsAsync(int pageIndex, int pageSize, IDictionary<string, ErrorRecord> errors);
    }
}