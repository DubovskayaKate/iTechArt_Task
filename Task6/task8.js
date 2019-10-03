function f(x) {
    return Math.random()*x;
}
  
function makeCaching(f) {
    let cache = {};

    return function(item) {
        if (item && !(item in cache)) {
            cache[item] = f.call(null, item);
        }
        return cache[item];
    };
}
  
let cachingF = makeCaching(f);

let a = cachingF(1);
let b = cachingF(1);
console.log( a == b ); 

let c= cachingF(null);
let d= cachingF(undefined);
console.log(c);
console.log(d);

b = cachingF(2);
console.log( a == b ); 