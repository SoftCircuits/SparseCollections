// Copyright (c) 2019 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
using System;

namespace SoftCircuits.SparseCollections
{
    public class MatrixPosition
    {
        /// <summary>
        /// Gets or sets the matrix row position.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the matrix column position.
        /// </summary>
        public int Column { get; set; }

        internal MatrixPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        internal MatrixPosition(long key)
        {
            Row = ToRow(key);
            Column = ToColumn(key);
        }

        /// <summary>
        /// Converts a matrix row and column to an internal key.
        /// </summary>
        internal static long ToKey(Int32 row, Int32 col) => ((Int64)row << 32) | ((Int64)col & 0xffffffff);

        /// <summary>
        /// Extracts a matrix row value from an internal key.
        /// </summary>
        internal static int ToRow(Int64 key) => (Int32)(key >> 32);

        /// <summary>
        /// Extracts a matrix column value from an internal key.
        /// </summary>
        internal static int ToColumn(Int64 key) => (Int32)(key & 0xffffffff);
    }
}
