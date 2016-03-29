using System;
using B2BTecnology.Financeiro.DataBase.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace B2BTecnology.Financeiro.Teste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var clienteRepository = new ClienteRepository();
            var todos = clienteRepository.GetCliente(1);
        }
    }
}
