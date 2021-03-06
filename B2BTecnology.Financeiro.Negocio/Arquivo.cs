﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using TipoPdf = B2BTecnology.Financeiro.DTO.Enumeradores.TipoPdf;

namespace B2BTecnology.Financeiro.Negocio
{
    public class Arquivo
    {
        public byte[] GerarPdf<T>(List<T> listaPagamento, string nome, DateTime dataMesPagamento, TipoPdf tipoPdf, decimal imposto)
        {
            var pagamento = listaPagamento.FirstOrDefault();
            if (pagamento == null) return null;

            const string caminho = @"C:\PDF";
            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);

            var caminhoCompleto = string.Format(@"{0}\{1}_{2}.pdf", caminho, nome, dataMesPagamento.ToString("MMyyyy"));

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(caminhoCompleto, FileMode.Create));
            doc.Open();

            var corpoEmail = CorpoEmail();
            var data = dataMesPagamento.ToString("Y");
            corpoEmail = corpoEmail.Replace("[InformacaoBody]", TipoPdf.Comissao == tipoPdf ?
                                                        InformacaoBodyComissao() :
                                                        InformacaoBodyPagamento());
            corpoEmail = corpoEmail.Replace("[mes]", data.Substring(0, 1).ToUpper() + data.Substring(1, data.Length - 1));
            corpoEmail = corpoEmail.Replace("[tabela]", TipoPdf.Comissao == tipoPdf ? TabelaComissao() : TabelaPagamento());
            corpoEmail = corpoEmail.Replace("[canal]", nome);
            corpoEmail = corpoEmail.Replace("[body]", TipoPdf.Comissao == tipoPdf ?
                                                        BodyTabelaComissao(listaPagamento.Cast<ComissaoDTO>().ToList(), imposto) :
                                                        BodyTabelaPagamento(listaPagamento.Cast<PagamentoDTO>().ToList()));
            corpoEmail = corpoEmail.Replace("[foot]", TipoPdf.Comissao == tipoPdf ?
                                                        FooterTabelaComissao(listaPagamento.Cast<ComissaoDTO>().ToList(), imposto) :
                                                        FooterTabelaPagamento(listaPagamento.Cast<PagamentoDTO>().ToList()));

            var hw = new HTMLWorker(doc);
            hw.Parse(new StringReader(corpoEmail));

            doc.Close();

            return File.ReadAllBytes(caminhoCompleto);
        }

        private string CorpoEmail()
        {
            var documentoRepository = new DocumentoRepository();
            return documentoRepository.GetDocumento().Layout;
        }

        private static string InformacaoBodyComissao()
        {
            var html = new StringBuilder()
                .AppendLine("<div style='border-top: 3px solid #000;'>")
                .AppendLine("COMISSÃO REFERENTE À ARRECADAÇÃO DE: <b>[mes]</b>")
                .AppendLine("</div>")
                .AppendLine("<div style='border-top: 3px solid #000;'>")
                .AppendLine("CANAL: <b>[canal]</b>")
                .AppendLine("</div>");

            return html.ToString();
        }

        private static string InformacaoBodyPagamento()
        {
            var html = new StringBuilder()
                .AppendLine("<div style='border-top: 3px solid #000;'>")
                .AppendLine("Resumo de Pagamento dos Clientes.")
                .AppendLine("</div>")
                .AppendLine("<div style='border-top: 3px solid #000;'>")
                .AppendLine("Cliente: <b>[canal]</b>")
                .AppendLine("</div>");

            return html.ToString();
        }

        private static string BodyTabelaComissao(List<ComissaoDTO> listaPagamento, decimal imposto)
        {
            var tbody = new StringBuilder();
            listaPagamento.ForEach(p =>
            //tbody.AppendFormat("<tr><td>{0}</th><td>{1}</th><td>{2}</th><td>{3}</th></tr>"
            //    , p.NomeCliente
            //    , p.ValorPagar.ToString("C")
            //    , (p.ValorPagar - (p.ValorPagar * (imposto/100))).ToString("C")
            //    , p.Comissao.ToString("C")
            //    ));

            tbody.AppendFormat("<tr><td>{0}</th><td>{1}</th><td>{2}</th></tr>"
                , p.NomeCliente
                //, p.ValorPagar.ToString("C")
                , (p.ValorPagar - (p.ValorPagar * (imposto / 100))).ToString("C")
                , p.Comissao.ToString("C")
                ));

            return tbody.ToString();
        }

        private static string FooterTabelaComissao(List<ComissaoDTO> listaPagamento, decimal imposto)
        {
            //return string.Format("<tr><td>{0}</th><td>{1}</th><td>{2}</th><td>{3}</th></tr>"
            //    , "Total: "
            //    , listaPagamento.Sum(p => p.ValorPagar).ToString("C")
            //    , listaPagamento.Sum(p => p.ValorPagar - (p.ValorPagar * (imposto / 100))).ToString("C")
            //    , listaPagamento.Sum(p => p.Comissao).ToString("C"));
            return string.Format("<tr><td>{0}</th><td>{1}</th><td>{2}</th></tr>"
                , "Total: "
                //, listaPagamento.Sum(p => p.ValorPagar).ToString("C")
                , listaPagamento.Sum(p => p.ValorPagar - (p.ValorPagar * (imposto / 100))).ToString("C")
                , listaPagamento.Sum(p => p.Comissao).ToString("C"));
        }

        private static string TabelaComissao()
        {
            var html = new StringBuilder()
                .AppendLine("<table border='1'>")
                .AppendLine("<thead>")
                .AppendLine("<tr>")
                .AppendLine("<th style='width: 200px; text-align: center;'>")
                .AppendLine("<b>Empresa</b>")
                .AppendLine("</th>")
                //.AppendLine("<th style='width: 200px; text-align: center;'>")
                //.AppendLine("<b>Faturamento Bruto</b>")
                //.AppendLine("</th>")
                .AppendLine("<th style='width: 200px; text-align: center;'>")
                .AppendLine("<b>Faturamento Líquido</b>")
                .AppendLine("</th>")
                .AppendLine("<th style='width: 200px; text-align: center;'>")
                .AppendLine("<b>Comissão à Pagar</b>")
                .AppendLine("</th>")
                .AppendLine("</tr>")
                .AppendLine("</thead>")
                .AppendLine("<tbody>")
                .AppendLine("[body]")
                .AppendLine("</tbody>")
                .AppendLine("<tfoot>")
                .AppendLine("[foot]")
                .AppendLine("</tfoot>")
                .AppendLine("</table>");

            return html.ToString();
        }

        private static string TabelaPagamento()
        {
            var html = new StringBuilder()
                .AppendLine("<table border='1'>")
                .AppendLine("<thead>")
                .AppendLine("<tr>")
                .AppendLine("<th style='width: 200px; text-align: center;'>")
                .AppendLine("<b>Nome</b>")
                .AppendLine("</th>")
                .AppendLine("<th style='width: 200px; text-align: center;'>")
                .AppendLine("<b>Data Pagamento</b>")
                .AppendLine("</th>")
                .AppendLine("<th style='width: 200px; text-align: center;'>")
                .AppendLine("<b>Valor Pago</b>")
                .AppendLine("</th>")
                .AppendLine("<th style='width: 200px; text-align: center;'>")
                .AppendLine("<b>Pago</b>")
                .AppendLine("</th>")
                .AppendLine("</tr>")
                .AppendLine("</thead>")
                .AppendLine("<tbody>")
                .AppendLine("[body]")
                .AppendLine("</tbody>")
                .AppendLine("<tfoot>")
                .AppendLine("[foot]")
                .AppendLine("</tfoot>")
                .AppendLine("</table>");

            return html.ToString();
        }

        private static string BodyTabelaPagamento(List<PagamentoDTO> listaPagamento)
        {
            var tbody = new StringBuilder();
            listaPagamento.ForEach(p =>
            tbody.AppendFormat("	<tr><td>{0}</th><td>{1}</th><td>{2}</th><td>{3}</th></tr>"
                , p.Contrato.NomeCliente
                , p.DataPagamento.ToString("Y")
                , p.ValorPago.ToString("C")
                , p.Pago ? "Sim" : "Não"
                ));

            return tbody.ToString();
        }

        private static string FooterTabelaPagamento(List<PagamentoDTO> listaPagamento)
        {
            return string.Format("<tr><td>{0}</th><td>{1}</th><td>{2}</th><td>{3}</th></tr>"
                , "Total: "
                , ""
                , listaPagamento.Sum(p => p.ValorPago).ToString("C")
                , "");
        }
    }
}
