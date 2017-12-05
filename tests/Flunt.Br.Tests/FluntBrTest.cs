using Flunt.Br.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flunt.Validations;

namespace Flunt.Br.Tests
{
    [TestClass]
    public class FluntBrTest
    {
        [TestMethod]
        public void IsCpf_Invalid()
        {
            var wrong = new Contract()
                .IsCpf("12345678910", "document", "Invalid document");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsCpf_Valid()
        {
            var right = new Contract()
                .IsCpf("08381614996", "document", "Invalid document");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        public void IsCnpj_InValid()
        {
            var wrong = new Contract()
                .IsCnpj("123456789101112", "document", "Invalid document");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsCnpj_Valid()
        {
            var right = new Contract()
                .IsCnpj("58558674000196", "document", "Invalid document");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        public void IsPhone_InValid()
        {
            var wrong = new Contract()
                .IsPhone("123456789", "phone", "Invalid phone");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        [DataRow("(45)3222-4520")]
        [DataRow("(14)3227-6254")]
        [DataRow("(11)3280-0907")]
        public void IsPhone_Valid(string phone)
        {
            var right = new Contract()
                .IsPhone(phone, "phone", "Invalid phone");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        [DataRow("+55 (99) 9999-9999","+55 (45) 3222-4520")]
        [DataRow("+55 99 9999 9999","+55 45 3222 4520")]
        [DataRow("99 9999 9999","45 3222 4520")]
        public void IsPhone_Customized_Valid(string format, string phone)
        {
            var right = new Contract()
                .IsPhone(format, phone, "phone", "Invalid phone");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        [DataRow("+55 (99) 9999-9999","+55 45) 3222-4520")]
        [DataRow("+55 99 9999 9999","+55 4 3222 4520")]
        [DataRow("99 9999 9999","45 322 4520")]
        public void IsPhone_Customized_InValid(string format, string phone)
        {
            var wrong = new Contract()
                .IsPhone(format, phone, "phone", "Invalid phone");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsCellPhone_InValid()
        {
            var wrong = new Contract()
                .IsCellPhone("456456444456", "cellphone", "Invalid cellphone");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsCellPhone_Valid()
        {
            var right = new Contract()
                .IsCellPhone("(45)99999-9999", "cellphone", "Invalid cellphone");
            Assert.AreEqual(true, right.Valid);
        }
    }
}
