using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMSwebapi;
using BMSwebapi.Models;

namespace BMSwebapiTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPassbookDetails()
        {
            PassBook pb = new PassBook();
            pb.AccountNumber = 1010;
            pb.Amount = 10;
            pb.TimeofTransaction = new DateTime(2020, 09, 02);
            pb.Mode = "Deposit";
            Assert.AreEqual(pb.AccountNumber, 1010);
            Assert.AreEqual(pb.Amount, 200);
            Assert.AreEqual(pb.TimeofTransaction, new DateTime(2020, 09, 02));
            Assert.AreEqual(pb.Mode,"Deposit");
        }
    }
}
