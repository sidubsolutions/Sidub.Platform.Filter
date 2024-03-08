using Sidub.Platform.Filter.Services;

namespace Sidub.Platform.Filter.Parsers.MySql
{

    /// <summary>
    /// Represents the configuration for the MySql filter parser.
    /// </summary>
    public class MySqlFilterParserConfiguration : IFilterServiceConfiguration
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
        /// Initializes a new instance of the <see cref="MySqlFilterParserConfiguration"/> class.
        /// </summary>
        public MySqlFilterParserConfiguration()
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
