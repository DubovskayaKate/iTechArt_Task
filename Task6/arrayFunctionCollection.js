class ArrayFunctionCollection {
	constructor(array){
		this._array = array;
		this._func = [];
	}	

	static take(number, array){
		let newArr = [];
		for(let i = 0; (i < number && i < array.length); i++){
			newArr[i] = array[i];
		}
		return newArr;
	};

	take() {
		this._func.push(ArrayFunctionCollection.take.bind(this, ...arguments));
		return this;
	};
	
	static skip( number, array){
		let newArr = [];
		for(let i = number; i < array.length; i++){
			newArr[i - number] = array[i];
		}
		return newArr;
	};
    
    skip (){
		this._func.push(ArrayFunctionCollection.skip.bind(this, ...arguments));
		return this;
	};
	
	static map(callback, array){
		for(let i = 0; i < array.length; i++){
			array[i] = callback(array[i], i, array);
		}
		return array;
	};

    map(){
		this._func.push(ArrayFunctionCollection.map.bind(this, ...arguments));
		return this;
	};	

	reduce( callback, initialValue, array){
		let result = initialValue;
		for(let i = 0; i < array.length; i++){
			result = callback(result, array[i]);
		}
		return result;
	};

	static filter(callback, array){
		let newArr = [];
		let j = 0;
		for(let item of array){
			if (callback(item)){
				newArr[j] = item;
				j++;
			}
		}
		return newArr;
	};

	filter(){ 
		this._func.push(ArrayFunctionCollection.filter.bind(this, ...arguments));
		return this;
	};

	static foreach( callback, array){
		for(let i = 0; i < array.length; i++){
			array[i] = callback(array[i]);
		}
		return array;
	};

	foreach(){ 
		this._func.push(ArrayFunctionCollection.foreach.bind(this, ...arguments));
		return this;
	};

	 static chain(array){
		return new ArrayFunctionCollection(array);
	};

	value(){
        this._func.forEach((func) => {
            this._array = func(this._array);
        });
		return this._array;
	};
}


console.log(ArrayFunctionCollection.chain([1,2,3,4,5,6,7])
	.take(4).skip(2).map((item, index) => item * item).filter((item)=> (item>9)).foreach( (item) => item * item)
	.value()
);
