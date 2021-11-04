# Fractions

A library for arithmetic of fractions, allowing operations on non-integers without floating point errors.

## Installation

To download and install the package download the `.nupkg` file from this repository, and set the package source to be the location of the file in the Visual Studio nuget package manager. Then click install.

Then just include the reference:

`open Fractions.Operations`

## Usage

To create a fraction, it is recommended to use one of the following methods:

```
fromInt: int -> Fraction<int>
fromInt64: int64 -> Fraction<int64>
fromBigint: bigint -> Fraction<bigint>
fromIntTuple: (int * int) -> Fraction<int>
fromInt64Tuple: (int64 * int64) -> Fraction<int64>
fromBigintTuple: (bigint * bigint) -> Fraction<bigint)
```

as opposed to creating an instance of the record manually. This is because all operations will simplify the fractions, crucial for the certain functions to operate correctly.

The `+`, `-`, `*` and `/` are all overloaded to work with this fraction type and will maintain the fraction in simplest form. In addition, the `^^` operator will take a fraction to an integer power. Supported operations were chosen on the grounds that they must guarantee an exact result, which is the purpose of this library. Any other operations such as fractional powers should be done using floating point numbers.

To extract the numerator or denominator just use `frac.Numerator` or `frac.Denominator` respectively.

There are also methods to be called on a fraction to convert to a float (`asFloat`), convert to a decimal (`asDecimal`), and verify if it is a whole number (`isWhole`).

To display a fraction to the console use:

`printfn "%A" frac`

which will present the fraction in the form *numerator/denominator*
