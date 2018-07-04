using TestApp.KunaService;

namespace TestApp
{
    public static class Extantion
    {
        public static string KeyToString(this MarketPair pair)
        {
            string rstr = null;

            for (int i = 0; i < pair.ToString().ToCharArray().Length; i++)
            {
                rstr += GetSlash(i, pair.ToString().ToCharArray().Length) + pair.ToString().ToCharArray()[i];
            }

            return rstr;
        }

        private static string GetSlash(int count, int lenght)
        {
            if ((lenght - count) == 3) return "/";
            else return "";
        }
    }
}
