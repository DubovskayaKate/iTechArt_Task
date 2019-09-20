class Shape{
    constructor(name){
        this.name = name;
    }
}

class Rectangle extends Shape{
    constructor(name, width, height){
        super(name);
        this.width = width;
        this.height = height;
    }
    perimetr() {
        return 2* this.width + this.height;
    }

    area(){ 
        return width * height;
    }
}

class Squre extends Shape{
    constructor(name, sideWidth){
        super(name);
        this.sideWidth = sideWidth;
    }
    perimetr() {
        return 4* this.sideWidth;
    }
    
    area() { 
        return this.sideWidth * this.sideWidth;
    }
}

class ShapeStore{
    constructor(shapeArray){
        this.shapeArray = shapeArray;
    }

    getAllRectanglePerimetrs(){
        let perimetrs = [];
        let index = 0;
        for (let shape of this.shapeArray){
            if (shape instanceof Rectangle){
                perimetrs[index++] = shape.perimetr();
            }
        }
        return perimetrs;
    }

    getAllSquareAreas(){
        let area = [];
        let index = 0;
        for (let shape of this.shapeArray){
            if (shape instanceof Squre){
                area[index++] = shape.area();
            }
        }
        return area;
    }
}

var store = new ShapeStore(
    [
        new Rectangle("1", 2,3),
        new Rectangle("1", 4,3), 
        new Rectangle("1", 3,3), 
        new Squre("3", 5),
        new Squre("3", 3),
        new Squre("3", 8)
    ]
);
console.log(store.getAllRectanglePerimetrs());
console.log(store.getAllSquareAreas());

