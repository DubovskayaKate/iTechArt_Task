function take(array, number){
	let newArr = [];
	for(let i = 0; (i < number && i < array.length); i++){
		newArr[i] = array[i];
	}
	return newArr;
}

function skip(array, number){
	let newArr = [];
	for(let i = number; (i < array.length); i++){
		newArr[i - number] = array[i];
	}
	return newArr;
}

function map(array, callback){
	for(let i = 0; i < array.length; i++){
		array[i] = callback(array[i]);
	}
	return array;
}

alert(map([1,2,3,4,5], 3));