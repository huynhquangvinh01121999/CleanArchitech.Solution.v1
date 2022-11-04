using System;

namespace Application.Parameters.CustomerParams
{
    public class GetCustomerParameters : RequestParameter
    {
        public string colFil { get; set; } = string.Empty;
        public string keyword { get; set; } = string.Empty;
        public DateTime? startDob { get; set; }
        public DateTime? endDob { get; set; }
    }
}
