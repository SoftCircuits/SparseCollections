﻿// Copyright (c) 2019-2020 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SparseCollectionsTests")]
namespace SoftCircuits.SparseCollections
{
    public class MatrixPosition
    {
        /// <summary>
        /// Gets or sets the matrix row position.
        /// </summary>
        public int Row { get; internal set; }

        /// <summary>
        /// Gets or sets the matrix column position.
        /// </summary>
        public int Column { get; internal set; }

        // Internal constructor
        internal MatrixPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        // Internal constructor
        internal MatrixPosition(long key)
        {
            Row = ToRow(key);
            Column = ToColumn(key);
        }

        /// <summary>
        /// Converts a matrix row and column to an internal hash key.
        /// </summary>
        internal static long ToKey(Int32 row, Int32 col) => ((Int64)row << 32) | (col & 0xffffffff);

        /// <summary>
        /// Extracts a matrix row value from an internal hash key.
        /// </summary>
        internal static int ToRow(Int64 key) => (Int32)(key >> 32);

        /// <summary>
        /// Extracts a matrix column value from an internal hash key.
        /// </summary>
        internal static int ToColumn(Int64 key) => (Int32)key;
    }
}
