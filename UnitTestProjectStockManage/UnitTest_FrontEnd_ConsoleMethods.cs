using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppStockManage;

namespace UnitTestProjectStockManage
{
    [TestClass]
    public class UnitTest_FrontEnd_ConsoleMethods
    {
        [TestMethod]
        public void TestMethod_ConsoleInput_S5_and_L()
        {
            int saldo = Program.ProcessCommando("L").Saldo.Value;

            Assert.IsTrue(Program.ProcessCommando("S5").Success);

            int saldoAfterSales = Program.ProcessCommando("L").Saldo.Value;

            Assert.IsTrue(saldo - 5 == saldoAfterSales);

        }

        [TestMethod]
        public void TestMethod_ConsoleInput_I5_and_L()
        {
            int saldo = Program.ProcessCommando("L").Saldo.Value;

            Assert.IsTrue(Program.ProcessCommando("I5").Success);

            int saldoAfterSales = Program.ProcessCommando("L").Saldo.Value;

            Assert.IsTrue(saldo + 5 == saldoAfterSales);
        }

        [TestMethod]
        public void TestMethod_ConsoleInput_WrongInput()
        {
            Assert.IsFalse(Program.ProcessCommando("II5").Success);

            Assert.IsFalse(Program.ProcessCommando("L5").Success);
            
            Assert.IsFalse(Program.ProcessCommando("Sw5").Success);

            Assert.IsFalse(Program.ProcessCommando("5").Success);
                        
        }
    }
}
