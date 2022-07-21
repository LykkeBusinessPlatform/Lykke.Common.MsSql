using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Lykke.Common.MsSql
{
    public static class ExceptionExtensions
    {
        private static readonly string MissingRowMessage = RelationalStrings.UpdateConcurrencyException(1, 0);
        
        /// <summary>
        /// If exception is based on a fact that data is missing in a database table, then returns true.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static bool IsMissingDataException(this DbUpdateConcurrencyException exception)
        {
            return exception.Message.Equals(MissingRowMessage);
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