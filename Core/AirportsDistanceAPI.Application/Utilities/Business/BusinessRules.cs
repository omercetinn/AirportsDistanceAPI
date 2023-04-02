using AirportsDistanceAPI.Application.Utilities.Results;

namespace AirportsDistanceAPI.Application.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //params ile tüm metodları yan yana yazabiliriz araya virgül koyarak
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
