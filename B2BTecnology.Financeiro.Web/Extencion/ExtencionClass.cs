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
    }
}