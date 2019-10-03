function Shape(name){

    this.name = name;
}

function Rectangle(name, width, height){
    Shape.call(this, name)

    this.width = width;
    this.height = height;

    this.perimetr = () => {
        return 2* (this.width + this.height);
    }

    this.area = () => { 
        return width * height;
    }
}

function Squre (name, sideWidth){
    Shape.call(this, name);
    
    this.sideWidth = sideWidth;

    this.perimetr = () => {
        return 4* this.sideWidth;
    }
    
    this.area = () => { 
        return this.sideWidth * this.sideWidth;
    }
}

function ShapeStore(shapeArray){

    this.shapeArray = shapeArray;

    this.getAllRectanglePerimetrs = () => {
        let perimetrs = [];
        let index = 0;
        for (let shape of this.shapeArray){
            if (shape instanceof Rectangle){
                perimetrs[index++] = shape.perimetr();
            }
        }
        return perimetrs;
    }

    this.getAllSquareAreas = () => {
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

let store = new ShapeStore(
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

let rect1 = new Rectangle("Katya", 2, 4);
console.log(rect1.area());
console.log(rect1.perimetr());
console.log(rect1.name);
