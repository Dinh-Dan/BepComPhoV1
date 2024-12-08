using System.Linq;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Helpers
{
    public static class Validation
    {
        // Validate Name
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length <= 70;
        }

        // Validate Address
        public static bool IsValidAddress(string address)
        {
            return !string.IsNullOrEmpty(address) && address.Length <= 200;
        }

        // Validate AddMap
        public static bool IsValidAddMap(string addMap)
        {
            // Format: latitude, longitude
            return !string.IsNullOrEmpty(addMap) && addMap.Length <= 200;
        }

        // Validate Phone Numbers
        public static bool IsValidNumberPhone(string numberPhone)
        {
            return !string.IsNullOrEmpty(numberPhone) && numberPhone.Length >= 10 && numberPhone.All(char.IsDigit);
        }

        // Validate Intro
        public static bool IsValidIntro(string intro)
        {
            return  intro.Length <= 500;
        }

        // Validate Rate
        public static bool IsValidRate(int rate)
        {
            return rate >= 1 && rate <= 5;
        }

        // Validate Date
        /*  public static bool IsValidDate(DateTime date)
          {
              return date <= DateTime.Now;
          }*/
    }
}
