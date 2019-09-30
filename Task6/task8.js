function f(x) {
    return Math.random()*x;
}
  
function makeCaching(f) {
    var cache = {};

    return function(item) {
        if (!(item in cache) && (item != null)) {
            cache[item] = f.call(null, item);
        }
        return cache[item];
    };
}
  
let cachingF = makeCaching(f);

var a = cachingF(1);
var b = cachingF(1);
console.log( a == b ); 

let c= cachingF(null);
let d= cachingF(undefined);
console.log(c);
console.log(d);

b = cachingF(2);
console.log( a == b ); 