using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Git.Platform.Context;
using Git.Platform.Operation.Main;

namespace Git.Platform.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestContext()
        {
            ContextSetup oContextSetup = new ContextSetup(@"C:\Users\USER\Documents\JW Developers\Git.Platform\Git.Platform.Context\bin\ContextConfig.xml");
        }

        [TestMethod]
        public void TestOperationMain()
        {
            OperationMain oOperationMain = new OperationMain();
            oOperationMain.Start();
        }
    }
}
