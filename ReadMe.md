# Sparse Collections

[![NuGet version (SoftCircuits.SparseCollections)](https://img.shields.io/nuget/v/SoftCircuits.SparseCollections.svg?style=flat-square)](https://www.nuget.org/packages/SoftCircuits.SparseCollections/)

```
Install-Package SoftCircuits.SparseCollections
```

## Overview

The SparseCollections library includes two lightweight collection classes, `SparseArray<T>` and `SparseMatrix<T>`. The array class allow statements like `array[1000000] = 5` and `array[-1000000] = 6` without having to allocate a large array. The matrix class does the same thing using a two-dimensional-array metaphor.

## Examples

This example adds two items to a `SparseArray<T>` and confirms their value.

```cs
SparseArray<int> array = new SparseArray<int>();

// Assign some values
array[10000] = 4;
array[-100000] = 5;

Debug.Assert(array[10000] == 4);
Debug.Assert(array[-100000] == 5);
```

This example does the same thing with a `SparseMatrix<T>`.

```cs
SparseMatrix<int> matrix = new SparseMatrix<int>();

// Assign some values
matrix[10000, -10000] = 4;
matrix[-100000, 20000] = 5;

Debug.Assert(matrix[10000, -10000] == 4);
Debug.Assert(matrix[-100000, 20000] == 5);
```
