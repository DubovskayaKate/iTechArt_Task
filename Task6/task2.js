let FFunction = function(uncurried) {
    var parameters = Array.prototype.slice.call(arguments, 1);
    return function() {
        var remainingArgs =  parameters.concat(Array.prototype.slice.call(arguments)); 
        if (uncurried.length > remainingArgs.length){
            return FFunction.apply(null, uncurried, remainingArgs);
        }
        else{
            return uncurried.apply(null,remainingArgs);
        }
            
    };
  };

let GFunction = function(a,b,c){
    return a+b+c;
}

var t = FFunction(GFunction, 6);
console.log(t(1,2,3));

 