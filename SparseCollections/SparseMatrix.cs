// Copyright (c) 2019-2020 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftCircuits.SparseCollections
{
    public class SparseMatrix<T>
    {
        /// <summary>
        /// Internal data.
        /// </summary>
        private readonly Dictionary<Int64, T> Data;

        /// <summary>
        /// Gets or sets the default value returned for empty positions.
        /// </summary>
        public T DefaultValue { get; set; }

        /// <summary>
        /// Constructs a new <see cref="SparseMatrix{T}"/> instance.
        /// </summary>
        /// <param name="defaultValue">Specifies the value returned for matrix
        /// positions that have no value.</param>
        public SparseMatrix(T defaultValue = default)
        {
            Data = new Dictionary<Int64, T>();
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// Gets or sets the item at the specified row and column.
        /// </summary>
        /// <param name="row">Item row position.</param>
        /// <param name="column">Item column position.</param>
        /// <returns>The item at the specified position, or the default value if the
        /// position is empty.</returns>
        public T this[int row, int column]
        {
            get => Data.TryGetValue(MatrixPosition.ToKey(row, column), out T item) ? item : DefaultValue;
            set => Data[MatrixPosition.ToKey(row, column)] = value;
        }

        /// <summary>
        /// Gets the total number of items in this collection.
        /// </summary>
        public int Count => Data.Count;

        /// <summary>
        /// Clears all items from this collection.
        /// </summary>
        public void Clear() => Data.Clear();

        /// <summary>
        /// Removes the specified item from the collection.
        /// </summary>
        /// <param name="row">Item row position.</param>
        /// <param name="column">Item column position.</param>
        /// <returns>True if successful, false if the specified item didn't exist.</returns>
        public bool RemoveAt(int row, int column) => Data.Remove(MatrixPosition.ToKey(row, column));

        /// <summary>
        /// Returns all items from this collection.
        /// </summary>
        /// <returns>All items from this collection.</returns>
        public IEnumerable<T> GetItems() => Data.Values;

        /// <summary>
        /// Returns all the matrix row, column positions that refer to non-empty items.
        /// </summary>
        /// <returns>All the matrix row, column positions that refer to non-empty items.</returns>
        public IEnumerable<MatrixPosition> GetPositions() => Data.Keys.Select(k => new MatrixPosition(k));
    }
}
