// Copyright (c) 2019 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftCircuits.SparseCollections;
using System.Linq;

namespace TestSparseMatrix
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestArray()
        {
            SparseArray<int> array = new SparseArray<int>();

            array[0] = 1;
            array[0] = 1;   // Duplicate
            array[100] = 2;
            array[1000] = 3;
            array[10000] = 4;
            array[100000] = 5;

            // Items
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[100]);
            Assert.AreEqual(3, array[1000]);
            Assert.AreEqual(4, array[10000]);
            Assert.AreEqual(5, array[100000]);

            // Empty items
            Assert.AreEqual(default, array[50]);
            Assert.AreEqual(default, array[500]);
            Assert.AreEqual(default, array[5000]);
            Assert.AreEqual(default, array[50000]);
            Assert.AreEqual(default, array[500000]);

            // 
            var items = array.GetItems().ToArray();
            Assert.AreEqual(5, items.Length);
            Assert.AreEqual(1, items[0]);
            Assert.AreEqual(2, items[1]);
            Assert.AreEqual(3, items[2]);
            Assert.AreEqual(4, items[3]);
            Assert.AreEqual(5, items[4]);

            // Indices
            var indices = array.GetIndices().ToArray();
            Assert.AreEqual(5, indices.Length);
            Assert.AreEqual(0, indices[0]);
            Assert.AreEqual(100, indices[1]);
            Assert.AreEqual(1000, indices[2]);
            Assert.AreEqual(10000, indices[3]);
            Assert.AreEqual(100000, indices[4]);

            // Negative indices
            array[-5000] = 12345;
            Assert.AreEqual(12345, array[-5000]);
        }

        [TestMethod]
        public void TestMatrix()
        {
            SparseMatrix<int> matrix = new SparseMatrix<int>();

            matrix[0, 0] = 1;
            matrix[0, 0] = 1;   // Duplicate
            matrix[100, 100] = 2;
            matrix[1000, 1000] = 3;
            matrix[10000, 10000] = 4;
            matrix[100000, 100000] = 5;

            // Items
            Assert.AreEqual(1, matrix[0, 0]);
            Assert.AreEqual(2, matrix[100, 100]);
            Assert.AreEqual(3, matrix[1000, 1000]);
            Assert.AreEqual(4, matrix[10000, 10000]);
            Assert.AreEqual(5, matrix[100000, 100000]);

            // Empty items
            Assert.AreEqual(default, matrix[50, 50]);
            Assert.AreEqual(default, matrix[500, 500]);
            Assert.AreEqual(default, matrix[5000, 5000]);
            Assert.AreEqual(default, matrix[50000, 50000]);
            Assert.AreEqual(default, matrix[500000, 500000]);

            //
            var items = matrix.GetItems().ToArray();
            Assert.AreEqual(5, items.Length);
            Assert.AreEqual(1, items[0]);
            Assert.AreEqual(2, items[1]);
            Assert.AreEqual(3, items[2]);
            Assert.AreEqual(4, items[3]);
            Assert.AreEqual(5, items[4]);

            // Indices
            var indices = matrix.GetIndices().ToArray();
            Assert.AreEqual(5, indices.Length);
            Assert.AreEqual(0, indices[0].Row);
            Assert.AreEqual(0, indices[0].Col);
            Assert.AreEqual(100, indices[1].Row);
            Assert.AreEqual(100, indices[1].Col);
            Assert.AreEqual(1000, indices[2].Row);
            Assert.AreEqual(1000, indices[2].Col);
            Assert.AreEqual(10000, indices[3].Row);
            Assert.AreEqual(10000, indices[3].Col);
            Assert.AreEqual(100000, indices[4].Row);
            Assert.AreEqual(100000, indices[4].Col);

            // Negative indices
            matrix[-5000, -5000] = 12345;
            Assert.AreEqual(12345, matrix[-5000, -5000]);
        }
    }
}
