# Sparse Collections

[![NuGet version (SoftCircuits.SparseCollections)](https://img.shields.io/nuget/v/SoftCircuits.SparseCollections.svg?style=flat-square)](https://www.nuget.org/packages/SoftCircuits.SparseCollections/)

```
Install-Package SoftCircuits.SparseCollections
```

## Overview

The SparseCollections library provides the `SparseArray<T>` and `SparseMatrix<T>` collection classes. The array class allow statements such as `array[1000000] = 5` or `array[-1000000] = 6` without having to create a large array. The matrix class does the same thing using a two-dimensional-array metaphore.

These are lightweight classes. And they both use `Dictionary<T>`s internally to store the data.

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
