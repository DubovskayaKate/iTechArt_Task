let multiplicator = function(){
    let result = 1;
    for(let item of arguments){
        result *= item;
    }
    return result;    
}

console.log(multiplicator(4,5,6))