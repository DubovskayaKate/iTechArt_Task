function f(x) {
    return Math.random()*x;
}
  
function makeCaching(f) {
    var cache = {};

    return function(item) {
        if (!(item in cache)) {
            cache[item] = f.call(this, item);
        }
        return cache[item];
    };
}
  
f = makeCaching(f);

var a = f(1);
var b = f(1);
console.log( a == b ); 

b = f(2);
console.log( a == b ); 