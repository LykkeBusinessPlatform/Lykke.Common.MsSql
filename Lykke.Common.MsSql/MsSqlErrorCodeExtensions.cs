namespace Lykke.Common.MsSql
{
    /// <summary>
    /// Microsoft SQL Server error code extensions
    /// </summary>
    public static class MsSqlErrorCodeExtensions
    {
        /// <summary>
        /// If MS SQL error code means duplicate constraint violation (either key or index)
        /// </summary>
        /// <param name="sqlErrorCode"></param>
        /// <returns></returns>
        public static bool IsDuplicateKeyViolation(this int sqlErrorCode) =>
            MsSqlErrorCodes.IsDuplicateKeyViolation(sqlErrorCode);
    }
}