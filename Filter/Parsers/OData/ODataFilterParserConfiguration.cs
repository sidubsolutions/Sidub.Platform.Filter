using Sidub.Platform.Filter.Services;

namespace Sidub.Platform.Filter.Parsers.OData
{

    /// <summary>
    /// Represents the configuration for the OData filter parser.
    /// </summary>
    public class ODataFilterParserConfiguration : IFilterServiceConfiguration
    {

        #region Public properties

        /// <summary>
        /// Gets the list of filter parsers.
        /// </summary>
        public List<IFilterParser> FilterParsers { get; }

        /// <summary>
        /// Gets the list of value parsers.
        /// </summary>
        public List<IFilterValueParser> ValueParsers { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ODataFilterParserConfiguration"/> class.
        /// </summary>
        public ODataFilterParserConfiguration()
        {
            FilterParsers = new List<IFilterParser>()
                {
                    new FilterParserPredicate(),
                    new FilterParserLogicalOperator(),
                    new FilterParserPipeline()
                };

            ValueParsers = new List<IFilterValueParser>()
                {
                    new FilterValueParserNumeric(),
                    new FilterValueParserString(),
                    new FilterValueParserGuid()
                };
        }

        #endregion

    }

}
