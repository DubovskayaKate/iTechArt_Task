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
    