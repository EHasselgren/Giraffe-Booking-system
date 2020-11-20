using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokningsSystem_SlutUppgift.Helpers
{
    public static class DateHelpers
    {
        public static bool HasSharedDateInterval(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2)
        {
            if ((startDate1 > startDate2 && startDate1 < endDate2) || (endDate1 > startDate1 && endDate1 < endDate2))
                {
                return true;
            }
            else if ((startDate2 > startDate1 && startDate2 < endDate1) || (endDate2 > startDate1 && endDate2 < endDate1))
            {
                return true;
            }
            return true;
        }
    }
}
