namespace Sidub.Platform.Filter.Builders
{

    /// <summary>
    /// Filter component(s) builder interface for joining component statements. Used for 
    /// joining the statement portions of a filter clause.
    /// </summary>
    public interface IFilterBuilderJoin : IFilterBuilder
    {

        #region Interface methods

        /// <summary>
        /// Add a logical operator to the builder.
        /// </summary>
        /// <param name="operator">Logical operator type.</param>
        /// <returns>An IFilterBuilderStatement for the next step in the builder.</returns>
        IFilterBuilderStatement Add(LogicalOperator @operator);

        #endregion

    }

}
