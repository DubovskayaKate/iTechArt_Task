const GFunction = function(...arguments){
    return arguments.reduce((accumulator, currentValue) => accumulator + currentValue);
}

const Ffunction = function(gFunction){
    var args = Array.prototype.slice.call(arguments, 1);
    return function(){
        var remainingArgs = Array.from(arguments);
        return gFunction.apply(null, args.concat(remainingArgs));
    }
}

console.log(GFunction(1, 2, 3, 4, 5));

let k = Ffunction(GFunction, 1,2,3,4,5);
console.log(k(6,7,8));