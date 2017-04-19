using DollarConverter.Contract;
using DollarConverter.Server.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace DollarConverter.Server
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    internal class DollarToWordService : IDollarToWordService
    {
        private IDollarsToString _converter;

        public DollarToWordService()
        {
            _converter = Container.Global.Resolve<IDollarsToString>();
        }

        public string ConvertDollarsToWords(decimal value)
        {
            return _converter.GetStringForDollars(value);
        }
    }
}
