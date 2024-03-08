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
        OData,

        /// <summary>
        /// Gremlin filter parser.
        /// </summary>
        Gremlin,

        /// <summary>
        /// MySql filter parser.
        /// </summary>
        MySql
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
