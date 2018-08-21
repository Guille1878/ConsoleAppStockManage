using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestStockManageService;

namespace UnitTestProjectStockManage
{
    [TestClass]
    public class UnitTest_BackEnd_WebAPI
    {
        [TestMethod]
        public void TestMethod_UpdateSaldo()
        {
            using (var service = new UnitTestStockManageServiceClient())
            {
                var saldo = service.GetSaldo();

                service.UpdateSaldo(5);

                var saldoAfterBuying = service.GetSaldo();

                Assert.AreEqual(saldo + 5, saldoAfterBuying);

                service.UpdateSaldo(-2);

                var saldoAfterSelling = service.GetSaldo();

                Assert.AreEqual(saldoAfterBuying - 2, saldoAfterSelling);

            }
        }
    }
}
