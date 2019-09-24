const choosingFunc = function()  {
    //arguments[0] - parametrs (Array*param+)
    //arguments[1] - function     
	if( Array.isArray(arguments[0][0]))  {
        var parameters = Array.prototype.slice.call(arguments[0], 1);
		const resultArray = arguments[1].call(this, parameters, arguments[0][0]);
		return resultArray;
	}
	const resultFunc = arguments[1].bind(this, ...arguments[0]);
    this._func[this._func.length] = resultFunc;
	return this;
}

var arrayFunctionCollection = {

    _array : [], 
    _func : [],

	take : function() {
		return choosingFunc.call(this,
			arguments,
			function ( number, array){
				let newArr = [];
				for(let i = 0; (i < number && i < array.length); i++){
					newArr[i] = array[i];
				}
				return newArr;
			}, 			
		);
    },
    
    skip : function (){
		return choosingFunc.call(this,
			arguments,
			function ( number, array){
				let newArr = [];
				for(let i = number; i < array.length; i++){
					newArr[i - number] = array[i];
				}
				return newArr;
			},
		);
    },	

    map :  function (){
		return choosingFunc.call(this, 
			arguments, 
			function (callback, array){
				for(let i = 0; i < array.length; i++){
					array[i] = callback(array[i], i, array);
				}
				return array;
			},
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
		return choosingFunc.call(
			this, 
			arguments, 
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
			}
		);
	},

	foreach : function(){ 
		return choosingFunc.call(
			this, 
			arguments, 
			function ( callback, array){
				for(let i = 0; i < array.length; i++){
					array[i] = callback(array[i]);
				}
				return array;
			}
		);
	},

	chain: function (array){
		this._array = array;
		return this;
	},

	value : function (array){
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
	.take(4).skip(2).map((item, index) => item * item).filter((item)=> (item>9)).foreach( (item) => item * item).value()
);

