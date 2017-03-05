using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2BTecnology.Financeiro.Web.Extencion
{
    public static class ExtencionClass
    {
        public static string DocumentoSemMascara(this string documento)
        {
            return documento.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        public static string DocumentoComMascara(this string documento)
        {
            if (documento.Length == 11)
                return string.Format("{0}.{1}.{2}-{3}", documento.Substring(0, 3), documento.Substring(3, 3), documento.Substring(6, 3), documento.Substring(9, 2));

            if (documento.Length == 14)
                return string.Format("{0}.{1}.{2}/{3}-{4}", documento.Substring(0, 2), documento.Substring(2, 3), documento.Substring(5, 3), documento.Substring(8, 4), documento.Substring(12, 2));

            return documento;
        }
    }
}