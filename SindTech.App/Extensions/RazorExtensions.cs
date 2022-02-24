using Microsoft.AspNetCore.Mvc.Razor;

namespace SindTech.App.Extensions
{
    public static class RazorExtensions
    {
        public static string RetornaNomeEnum<TEnum>(this RazorPage page, int enumConst)
        {
            return Enum.GetName(typeof(TEnum), enumConst);
        }

        public static string FormataCPF(this RazorPage page, string documento)
        {
            return Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00");
        }
    }
}
