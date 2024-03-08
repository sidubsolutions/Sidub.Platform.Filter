namespace Sidub.Platform.Filter.Builders
{

    /// <summary>
    /// Filter component(s) builder interface.
    /// </summary>
    public interface IFilterBuilder
    {

        #region Interface methods

        /// <summary>
        /// Executes the builder and returns the resulting IFilter representation.
        /// </summary>
        /// <returns>Filter.</returns>
        IFilter? Build();

        #endregion

    }

}
