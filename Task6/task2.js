let FFunction = function(uncurried) {
    let argsLength = uncurried.length;
    return (function resolver() {
        var remainingArgs =  Array.prototype.slice.call(arguments); 
        return function(){
            let local = remainingArgs.slice();            
            Array.prototype.push.apply( local, arguments );
            let next = local.length >= argsLength? uncurried : resolver;
            return next.apply(null, local);
        };            
    }());
  };

let GFunction = function(a,b,c){
    return a+b+c;
}

var t = FFunction(GFunction);
console.log(t(1)(2)(3));

 