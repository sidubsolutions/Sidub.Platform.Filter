#region Imports


#endregion

namespace Sidub.Platform.Filter.Builders
{

    /// <summary>
    /// Filter component(s) builder interface for statements. Used for building the statement portion
    /// (i.e., a predicate or pipeline) of a filter clause.
    /// </summary>
    public interface IFilterBuilderStatement : IFilterBuilder
    {

        #region Interface methods

        /// <summary>
        /// Add a pipeline builder to the builder.
        /// </summary>
        /// <param name="pipelineBuilder">Builder for assembling a pipeline.</param>
        /// <returns>An IFilterBuilderJoin for the next step in the builder.</returns>
        IFilterBuilderJoin Add(Action<IFilterBuilderStatement> pipelineBuilder);

        /// <summary>
        /// Adds a predicate to the builder.
        /// </summary>
        /// <param name="filterField">Filter field.</param>
        /// <param name="operator">Filter operator.</param>
        /// <param name="value">Filter value.</param>
        /// <returns>An IFilterBuilderJoin for the next step in the builder.</returns>
        IFilterBuilderJoin Add(string filterField, ComparisonOperator @operator, object value);

        #endregion

    }
}
