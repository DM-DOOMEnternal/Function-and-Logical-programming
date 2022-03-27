// Learn more about F# at http://fsharp.org

open System
(*2 Абстрактный класс «Геометрическая фигура» содержит виртуальный   
метод для вычисления площади фигуры.
   3 Класс «Прямоугольник» наследуется от класса «Геометрическа фигура». 
   Ширина и высота объявляются как свойства (property).
   Класс должен содержать конструктор по параметрам «ширина» и «высота».
   4 Класс «Квадрат» наследуется от класса «Прямоугольник». 
   Класс    должен содержать конструктор по длине стороны.*)
   (*Для классов «Прямоугольник», «Квадрат», «Круг» переопределить
   виртуальный метод Object.ToString(), который возвращает в виде
   строки основные параметры фигуры и ее площадь.*)

[<AbstractClass>]
type figure() = 
    abstract areaFigure : float with get
    //abstract ToString : string with get


type rectangleClass(width:float, height: float, name:string) = 
    inherit figure()
    
    member this._width = width
    member this._height = height
    member this._name = name

    override this.areaFigure = this._height*this._width
    
    override this.ToString() = this._name + ": width = " + this._width.ToString() +
        " height = " + this._height.ToString() + " area = " + this.areaFigure.ToString()
    
    new(length:float,name:string) = rectangleClass(length,length,name)
    
type circleClass(radius:float,name:string) =
    inherit figure()
    member this._radius = radius
    member this._name = name

    override this.areaFigure = this._radius * System.Math.PI
    override this.ToString() = this._name + ": radius = " + this._radius.ToString() +
    " area = " + this.areaFigure.ToString()

type squareClass(length:float) =
    inherit rectangleClass(length,"Square")
  
let printFigure(figure: figure) = printfn "Square: %f" (figure.areaFigure)

let printString (figure:figure) = printfn "%s" (figure.ToString())
   
[<EntryPoint>]
let main argv =
    let rectangle = rectangleClass(5.0,4.0,"Rectangle")
    let circle = circleClass(25.0,"Circle")
    let square = squareClass(50.0)
    printFigure(rectangle)
    printFigure(circle)
    printFigure(square)
    printString(rectangle)
    printString(circle)
    printString(square)

    0 // return an integer exit code

    