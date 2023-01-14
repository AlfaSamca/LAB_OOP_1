using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LB_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ToString_Check()//�������� ������ ������ ToString()
        {
            byte[] a = { 1 };
            JIBitArray array_1 = new JIBitArray(a);
            string b = "00000001";
            Assert.AreEqual(array_1.ToString(), b);
        }
        [TestMethod]
        public void Insert_Check()//�������� ������� Add and Insert
        {
            byte [] a = { 2 };
            JIBitArray array = new JIBitArray(a);
            JIBitArray array_1 = new JIBitArray();
            for (int i = 0; i < 7; i++)
            {
                array_1.Add(false);
            }
            array_1.Insert(6, true);
            Assert.AreEqual(array.ToString(), array_1.ToString());
        }
        [TestMethod]
        public void Set_Check()//�������� ������ ������ Set()
        {
            byte[] a = { 2 };
            JIBitArray array = new JIBitArray(a);
            JIBitArray array_1 = new JIBitArray();
            for (int i = 0; i < 8; i++)
            {
                array_1.Add(false);
            }
            array_1.Set(6, true);
            Assert.AreEqual(array.ToString(), array_1.ToString());
        }
        [TestMethod]
        public void Get_Check()//�������� ������ ������ Get()
        {
            byte[] a = { 1 };
            JIBitArray array_1 = new JIBitArray(a);          
            Assert.AreEqual(array_1.Get(7), true);
        }
        [TestMethod]
        public void Count_Check()//�������� ������ ��������� Count
        {
            byte[] a = { 1 };
            JIBitArray array_1 = new JIBitArray(a);
            Assert.AreEqual(array_1.Count, 8);
        }
        [TestMethod]
        public void SetAll_Check()//�������� ������ ������ SetAll_Check()
        {
            byte[] a = { 1 };
            JIBitArray array_1 = new JIBitArray(a);
            string b = "11111111";
            array_1.SetAll(true);
            Assert.AreEqual(array_1.ToString(), b);
        }
        [TestMethod]
        public void Not_Check()//�������� ������ ������ Not()
        {
            byte[] a = { 1 };
            JIBitArray array_1 = new JIBitArray(a);
            string b = "11111110";
            Assert.AreEqual(array_1.Not().ToString(), b);
        }
        [TestMethod]
        public void SubJIBitArray_Check()//�������� ������ ������ SubJIBitArray()
        {
            byte[] a = { 1 };
            JIBitArray array_1 = new JIBitArray(a);
            string b = "0001";
            Assert.AreEqual(array_1.SubJIBitArray(4,4).ToString(), b);
        }
        [TestMethod]
        public void GetLong_Check()//�������� ������ ������ GetLong()
        {
            long[] a = { 3446789765345, 34567865456, 878654678654 };
            JIBitArray array_1 = new JIBitArray(a);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(array_1.GetLong()[i], a[i]);
            }            
        }
        //�������� ��������� ����
        [TestMethod]
        public void RemoveBeginingZeros_Check()//�������� ������ ������ RemoveBeginingZeros()
        {
            byte[] a = { 1 };
            JIBitArray array_1 = new JIBitArray(a);
            string b = "1";
            Assert.AreEqual(array_1.RemoveBeginingZeros().ToString(), b);
        }
        [TestMethod]
        public void FixLength_Check()//�������� ������ ������ FixLength_Check()
        {
            byte[] a = { 1 };
            JIBitArray array_1 = new JIBitArray(a);
            string b = "0000000000000001";
            Assert.AreEqual(JIBitArray.FixLength(array_1, 16).ToString(), b);
        }
        [TestMethod]
        public void And_Check()//�������� ������ ������ And_Check
        {
            byte[] a = { 221 };
            byte[] c = { 187 };
            string b = "10011001";
            JIBitArray array_1 = new JIBitArray(a);
            JIBitArray array_2 = new JIBitArray(c);           
            Assert.AreEqual((array_1 & array_2).ToString(), b);
        }
        [TestMethod]
        public void Or_Check()//�������� ������ ������ Or_Check
        {
            byte[] a = { 144 };
            byte[] c = { 9};
            string b = "10011001";
            JIBitArray array_1 = new JIBitArray(a);
            JIBitArray array_2 = new JIBitArray(c);
            Assert.AreEqual((array_1 | array_2).ToString(), b);
        }
        [TestMethod]
        public void Xor_Check()//�������� ������ ������ Xor_Check
        {
            byte[] a = { 240 };
            byte[] c = { 105 };
            string b = "10011001";
            JIBitArray array_1 = new JIBitArray(a);
            JIBitArray array_2 = new JIBitArray(c);
            Assert.AreEqual((array_1 ^ array_2).ToString(), b);
        }
        [TestMethod]
        public void ShiftRight_Check()//�������� ������ ������ ShiftRight_Check
        {
            byte[] a = { 128 };
            string b = "00000001";
            JIBitArray array_1 = new JIBitArray(a);
            Assert.AreEqual((array_1>>7).ToString(), b);
        }
        [TestMethod]
        public void ShiftLeft_Check()//�������� ������ ������ ShiftLeft_Check
        {
            byte[] a = { 1 };
            string b = "10000000";
            JIBitArray array_1 = new JIBitArray(a);
            Assert.AreEqual((array_1 << 7).ToString(), b);
        }
    }
}
