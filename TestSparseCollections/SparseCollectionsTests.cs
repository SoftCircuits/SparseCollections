// Copyright (c) 2019 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftCircuits.SparseCollections;
using System.Collections.Generic;
using System.Linq;

namespace SparseCollectionsTests
{
    [TestClass]
    public class SparseCollectionsTests
    {
        static readonly List<int> Indexes = new List<int>();
        static readonly List<int> UnusedIndexes = new List<int>();

        static SparseCollectionsTests()
        {
            // Populate test data
            for (int i = 0; i < 100; i++)
            {
                Indexes.Add(int.MinValue + i);
                Indexes.Add(int.MaxValue - i);
                Indexes.Add(i);
                Indexes.Add(-(i + 1));  // Don't add zero twice
            }
            for (int i = 1000; i < 10001; i += 1000)
            {
                Indexes.Add(i);
                UnusedIndexes.Add(i + 500);
            }
        }

        [TestMethod]
        public void TestArray()
        {
            SparseArray<int> array = new SparseArray<int>();

            // Populate
            for (int i = 0; i < Indexes.Count; i++)
                array[Indexes[i]] = Indexes[i];

            // Test values
            for (int i = 0; i < Indexes.Count; i++)
                Assert.AreEqual(Indexes[i], array[Indexes[i]]);

            // Test unused values
            for (int i = 0; i < UnusedIndexes.Count; i++)
                Assert.AreEqual(default, array[UnusedIndexes[i]]);

            // Test item values
            int[] items = array.GetItems().ToArray();
            CollectionAssert.AreEqual(Indexes, items);

            // Test indexes
            int[] indexes = array.GetIndexes().ToArray();
            CollectionAssert.AreEqual(Indexes, indexes);
        }

        [TestMethod]
        public void TestMatrix()
        {
            SparseMatrix<int> matrix = new SparseMatrix<int>();
            //List<MatrixPosition> indexes = new List<MatrixPosition>();
            //List<int> values = new List<int>();

            // Populate
            for (int i = 0; i < Indexes.Count; i++)
            {
                for (int j = 0; j < Indexes.Count; j++)
                {
                    matrix[Indexes[i], Indexes[j]] = Indexes[i] + j;
                    //indexes.Add(Indexes[i] + j);
                    //values.Add()
                }
            }

            // Test values
            for (int i = 0; i < Indexes.Count; i++)
            {
                for (int j = 0; j < Indexes.Count; j++)
                    Assert.AreEqual(Indexes[i] + j, matrix[Indexes[i], Indexes[j]]);
            }

            // Test unused values
            for (int i = 0; i < UnusedIndexes.Count; i++)
            {
                for (int j = 0; j < UnusedIndexes.Count; j++)
                    Assert.AreEqual(default, matrix[UnusedIndexes[i], UnusedIndexes[j]]);
            }

            // Test item values
            int[] items = matrix.GetItems().ToArray();
            Assert.AreEqual(Indexes.Count * Indexes.Count, items.Length);

            // Test indexes
            MatrixPosition[] positions = matrix.GetPositions().ToArray();
            Assert.AreEqual(Indexes.Count * Indexes.Count, positions.Length);
        }

        [TestMethod]
        public void TestDuplicatesNoError()
        {
            SparseArray<int> array = new SparseArray<int>();
            for (int i = 0; i < 10; i++)
                array[500] = 5555;
            Assert.AreEqual(1, array.Count);
            var indexes = array.GetIndexes();
            Assert.AreEqual(1, indexes.Count());
            Assert.AreEqual(500, indexes.First());
            var items = array.GetItems();
            Assert.AreEqual(1, items.Count());
            Assert.AreEqual(5555, items.First());

            SparseMatrix<int> matrix = new SparseMatrix<int>();
            for (int i = 0; i < 10; i++)
                matrix[500, 500] = 5555;
            Assert.AreEqual(1, matrix.Count);
            var positions = matrix.GetPositions().ToArray();
            Assert.AreEqual(1, positions.Length);
            Assert.AreEqual(500, positions[0].Row);
            Assert.AreEqual(500, positions[0].Column);
            items = matrix.GetItems();
            Assert.AreEqual(1, items.Count());
            Assert.AreEqual(5555, items.First());
        }
    }
}
