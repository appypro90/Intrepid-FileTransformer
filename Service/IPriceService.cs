using Domain;
using System.Collections.Generic;

namespace Service
{
    public interface IPriceService
    {
        List<OutputFormat> processInputRecords(List<InputFormat> inputRecords);
    }
}
