using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.InMemory.Internal;

namespace Lykke.Common.MsSql
{
    public static class ExceptionExtensions
    {
        private static readonly string MissingRowMessage = RelationalStrings.UpdateConcurrencyException(1, 0);
        private static readonly string MissingRowInMemoryMessage = InMemoryStrings.UpdateConcurrencyException;
        
        /// <summary>
        /// If exception is based on a fact that data is missing in a database table, then returns true.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static bool IsMissingDataException(this DbUpdateConcurrencyException exception)
        {
            return exception.Message.Equals(MissingRowMessage) || exception.Message.Equals(MissingRowInMemoryMessage);
        }
        
        /// <summary>
        /// If row already exists in a database table, then returns true.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static bool ValueAlreadyExistsException(this DbUpdateException exception)
        {
            return exception.InnerException is SqlException sqlException &&
                   (sqlException.Number == MsSqlErrorCodes.PrimaryKeyConstraintViolation ||
                    sqlException.Number == MsSqlErrorCodes.DuplicateIndex);
        }
    }
}