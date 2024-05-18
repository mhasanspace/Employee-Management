using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Common.CommonHelper
{
    public class DotNetRunner
    {
        public int RefId { get; set; }
        /// <summary>
        /// It is OperationTypeInfoEnum enum value. Name space is EMS.Common.EnumUtility
        /// </summary>
        public int OperationTypeInfoId { get; set; }
        public string Message { get; set; }
        public int MessageId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
