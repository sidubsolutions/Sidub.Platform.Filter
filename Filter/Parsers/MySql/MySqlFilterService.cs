#region Imports

using Sidub.Platform.Filter.Services;

#endregion

namespace Sidub.Platform.Filter.Parsers.MySql
{

    public class MySqlFilterService : FilterService<MySqlFilterConfiguration>
    {

        #region Constructors

        public MySqlFilterService(IEnumerable<IFilterValueParser> globalValueParsers) : base(globalValueParsers)
        {
        }

        #endregion

    }

}
