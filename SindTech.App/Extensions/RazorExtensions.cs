using Microsoft.AspNetCore.Mvc.Razor;
using SindTech.Business.Models;

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

        public static string FormataCeluluar(this RazorPage page, int tipoContato, string valorContato)
        {
            if(tipoContato == (int)TipoContato.Celular)
            {
                return Convert.ToUInt64(valorContato).ToString(@"(0) 00000-0000");
            }
            
            return valorContato;
        }
    }
}
