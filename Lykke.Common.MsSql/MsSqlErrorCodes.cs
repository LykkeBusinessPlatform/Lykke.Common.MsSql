namespace Lykke.Common.MsSql
{
    /// <summary>
    /// Microsoft SQL Server error codes
    /// </summary>
    public static class MsSqlErrorCodes
    {
        /// <summary>
        /// Cannot insert duplicate key row 
        /// </summary>
        public const int DuplicateIndex = 2601;
        
        /// <summary>
        /// Violation of PRIMARY KEY constraint 
        /// </summary>
        public const int PrimaryKeyConstraintViolation = 2627;

        /// <summary>
        /// If error code means duplicate constraint violation (either key or index)
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static bool IsDuplicateKeyViolation(int errorCode) =>
            errorCode == DuplicateIndex || errorCode == PrimaryKeyConstraintViolation;
    }
}