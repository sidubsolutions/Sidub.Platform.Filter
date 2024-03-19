namespace Sidub.Platform.Filter
{

    #region Enumerations

    /// <summary>
    /// Filter parser implementations.
    /// </summary>
    [Flags]
    public enum FilterParserType
    {
        /// <summary>
        /// OData filter parser.
        /// </summary>
        OData = 1 << 1,

        /// <summary>
        /// Gremlin filter parser.
        /// </summary>
        Gremlin = 1 << 2,

        /// <summary>
        /// MySql filter parser.
        /// </summary>
        MySql = 1 << 3
    }

    /// <summary>
    /// Filter logical operators.
    /// </summary>
    public enum LogicalOperator
    {
        /// <summary>
        /// Logical AND operator.
        /// </summary>
        And,

        /// <summary>
        /// Logical OR operator.
        /// </summary>
        Or
    }

    /// <summary>
    /// Filter predicate comparison operators.
    /// </summary>
    public enum ComparisonOperator
    {
        /// <summary>
        /// Equality comparison operator.
        /// </summary>
        Equals,

        /// <summary>
        /// Inequality comparison operator.
        /// </summary>
        NotEquals
    }

    #endregion

}
