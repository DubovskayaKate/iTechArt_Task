# Functional Array Library

## Short Description

You are to implement a functional library for working with arrays.

## Topics

1.  Closure
2.  "this" keyword
3.  Functional Programming
4.  ES6 features
5.  Memoization
## Requirements


-   Code style
-   No bundling and modules
-   The library should provide the following functionality:
    
    `1) take(array,n)`    
    `2) skip(array, n)`    
    `3) map(array, callback)`    
    `4) reduce(array, callback, initialValue)`    
    `5) filter(array, callback)`    
    `6) foreach(array, callback)`    
    Here is an example of calling:
    
    `nameOfYourLibrary.take([1,2,3,4],2)`  will return  `[1,2]`    
    The rest of the functions work the same way.    
    `nameOfYourLibrary.map([1,2,3], a => a * 2 )`  will return  `[2,4,6]`
    
-   After finishing implementation of these methods, you should implement new  `chain`  and  `value`  functions, which will allow to use the library in the following way:
    
    `arrayLib.chain([1,2,3]).take(2).skip(1).value()`  will return  `[2]`
    
    **NOTE: it should still be possible to call the function in the old way.**


# Function Puzzles

## Short Description

You are to solve some functional puzzles.

## Requirements

### Problem 1: Partial Application

Implement function F that allows to do partial function application in a form of: G(x, y, z ... ) = N F(x, G(x, y, z ... )) → H(y, z ... ) = N

F should accept any number of parameters to apply. G may accept any number of parameters. Is there any JavaScript built-in alternative?

In order to solve this problem you have to be familiar with next concepts:

1.  Partial Application
2.  High-order and First-class functions
3.  Activation Object and handling of variable number of function arguments

### Problem 2: Currying

Implement function curry that allows to do currying like: f(x, y, z) = N, curry(f) = x → (y → (z → N))

Function f may accept any number of explicit parameters. Implicit parameters are not subject to curry. How is it differ from Partial Application?

In order to solve this problem you have to be familiar with next concepts:

1.  Currying and Partial Application
2.  High-order and First-class functions
3.  Activation Object and handling of variable number of function arguments

### Problem 8: Memoization

Implement a function that for any given function F produces function G that caches its previous calling results.

Function F accept single explicit parameter. Implicit parameters should not be taken into account. Watch out for NaN, undefined and circular references.

In order to solve this problem you have to be familiar with next concepts:

1.  Memoization
2.  High-order and First-class functions

### Problem 9: Inheritance

Make hierarchy of geometric figures: base Shape class, inherited Rectangle and Square classes. Rectangle should have ”width” and ”height” properties. Square should have ”sideLength” property. Also each shape has “name” property and methods to calculate perimeter and area. Make ShapesStore which contains shapes. It should have method which returns total perimeter of all rectangles and method which return total area of all squares which contained in it.

### Problem 10: Function with any number of parameters

Write a function which will calculate multiplication of all parameters that were passed into the function.
    