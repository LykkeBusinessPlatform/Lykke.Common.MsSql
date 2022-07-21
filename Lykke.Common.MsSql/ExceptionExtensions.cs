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
    }
}