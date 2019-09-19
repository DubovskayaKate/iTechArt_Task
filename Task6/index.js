function polymorph() {
	var lenfunc = [];
	for(var i = 0; i < arguments.length; i++){
	  	if( typeof(arguments[i]) == "function")
			lenfunc[arguments[i].length] = arguments[i];
		return function() {
			  return lenfunc[arguments.length].apply(this, arguments);
		}
	}
}

var arrayFunctionCollection = {

	_array : [], 
	take : polymorph(
		function (array, number){
			let newArr = [];
			for(let i = 0; (i < number && i < array.length); i++){
				newArr[i] = array[i];
			}
			return newArr;
		},
		function (number){
			let newArr = [];
			for(let i = 0; (i < number && i < this._array.length); i++){
				newArr[i] = this._array[i];
			}
			this._array = newArr
			return this;
		},
	),

	skip : function (array, number){
		let newArr = [];
		for(let i = number; i < array.length; i++){
			newArr[i - number] = array[i];
		}
		return newArr;
	},

	map : function (array, callback){
		for(let i = 0; i < array.length; i++){
			array[i] = callback(array[i], i, array);
		}
		return array;
	},

	reduce : function (array, callback, initialValue){
		let result = initialValue;
		for(let i = 0; i < array.length; i++){
			result = callback(result, array[i]);
		}
		return result;
	},

	filter : function (array, callback){
		let newArr = [];
		let j = 0;
		for(let item of array){
			if (callback(item)){
				newArr[j] = item;
				j++;
			}
		}
		return newArr;
	},

	foreach : function (array, callback){
		for(let i = 0; i < array.length; i++){
			array[i] = callback(array[i]);
		}
		return array;
	},

	chain: function (array){
		this._array = array;
		return this;
	},

	value : function (array){
		let arr = this._array;
		this._array = [];
		return arr;
	}
}


console.log(`${arrayFunctionCollection.take([1,2,3,4,5,7], 4)} = [1,2,3,4]`);
console.log(`${arrayFunctionCollection.skip([1,2,3,4,5,7], 4)} = [5,7]`);

console.log(`${arrayFunctionCollection.map([1,2,3,4,5,7], (item, index, array) => item * index)} = [0, 2, 6, 12, 20, 35]`);
console.log(`${arrayFunctionCollection.reduce([1,2,3,4,5,6,7], (accumulator, currentValue) => accumulator+currentValue, 0)} = 28`);

console.log(`${arrayFunctionCollection.filter([1,2,3,4,5], (item)=> (item>3))} = [4, 5]`);
console.log(`${arrayFunctionCollection.foreach([1,2,3,4,5,7], (item) => item * item)} = [1,4,9,16,25,36]`);

console.log(arrayFunctionCollection.chain([1,2,3,4,5,6,7]).take(4).value());
