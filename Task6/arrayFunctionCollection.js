const choosingFunc = function(callback, ...arguments)  {
	if( Array.isArray(arguments[0]))  {
        var parameters = Array.prototype.slice.call(arguments, 1);
		const resultArray = callback.call(this, parameters, arguments[0]);
		return resultArray;
	}
	const resultFunc = callback.bind(this, ...arguments);
    this._func[this._func.length] = resultFunc;
	return this;
}

var arrayFunctionCollection = {

    _array : [], 
    _func : [],

	take : function() {
		return choosingFunc.apply(this,					
			Array.prototype.concat.call(
				function ( number, array){
					let newArr = [];
					for(let i = 0; (i < number && i < array.length); i++){
						newArr[i] = array[i];
					}
					return newArr;
				}, 
				Array.prototype.slice.call(arguments)
			)		
		);
    },
    
    skip : function (){
		return choosingFunc.apply(this,
			Array.prototype.concat.call(			
				function ( number, array){
					let newArr = [];
					for(let i = number; i < array.length; i++){
						newArr[i - number] = array[i];
					}
					return newArr;
				},
				Array.prototype.slice.call(arguments)
			)
		);
    },	

    map :  function (){
		return choosingFunc.apply(this, 
			Array.prototype.concat.call(				
				function (callback, array){
					for(let i = 0; i < array.length; i++){
						array[i] = callback(array[i], i, array);
					}
					return array;
				},
				Array.prototype.slice.call(arguments)
			)
		);
	},	

	reduce : function ( callback, initialValue, array){
		let result = initialValue;
		for(let i = 0; i < array.length; i++){
			result = callback(result, array[i]);
		}
		return result;
	},

	filter : function(){ 
		return choosingFunc.apply(
			this, 
			Array.prototype.concat.call(			
				function (callback, array){
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
				Array.prototype.slice.call(arguments)
			)
		);
	},

	foreach : function(){ 
		return choosingFunc.apply(
			this, 
			Array.prototype.concat.call(			 
				function ( callback, array){
					for(let i = 0; i < array.length; i++){
						array[i] = callback(array[i]);
					}
					return array;
				},
				Array.prototype.slice.call(arguments),
			)
		);
	},

	chain: function (array){
		this._array = array;
		return this;
	},

	value : function (){
        this._func.forEach((func) => {
            this._array = func(this._array);
        });
        let arr = this._array;
        this._array = [];
        this._func = [];
		return arr;
	}
}


console.log(arrayFunctionCollection.chain([1,2,3,4,5,6,7])
	.take(4)
	.skip(2)
	.map((item, index) => item * item)
	.filter((item)=> (item > 9))
	.foreach( (item) => item * item)
	.value()
);

//.skip(2).map((item, index) => item * item).filter((item)=> (item>9)).foreach( (item) => item * item)
