// Learn more about F# at http://fsharp.org

open System

type MathematicalFuntionClass() =
    do printfn " Hello, my user!!"

    let mutable _areaCircle = 0.0
    let mutable _volumeCylinder = 0.0

    (*Написать функцию решения квадратного уравнения.*)
    let equation (n:int, a:float, b:float, x:float, y:float) =
        match n with
        |n when n=1 -> (Math.Sqrt(Math.Pow((x-a),2.0)+Math.Pow(y-b,2.0)))
        |n when n=2 -> (x*x*20.0+x+2.5)
        |n when n=3 -> (x*x+x+2.468)
        |n -> 0.0

    let rec checkN(n:int) =
        match n with
        |n when n=0 -> 0
        |n when n>=1 && n<4 ->n
        |n -> 
            printf "Equation: "
            let n1 = System.Convert.ToInt32(System.Console.ReadLine())
            checkN (n1)

    member this.squareEquation (a:float, b:float, x:float, y:float) = 
        printfn " Choose :\n 1) Radius \n 2)(x*x*20.0+x+2.5) \n 3) (x*x+x+2.468)" 
        let mutable n = checkN(4)
        if(n=0) then printfn "Exit.."
        else printfn "%f" (equation(n,a,b,x,y))

    (*Написать функцию вычисления площади круга piR^2 и другую
    функцию вычисления объема цилиндра piR^2*h с использованием написанной
    функции. *)
    member this.areaCircle (a:float, b:float, x:float, y:float) =
        printfn " Radius = %f"  (equation(1,a,b,x,y))
        //TODO: можно осущ ввод координат, но для уч цели задаются изначально
        this.readWriteAreaCircle <- (Math.PI*Math.Pow((equation(1,a,b,x,y)),2.0))
        printfn " Area Circle : %f " this.readWriteAreaCircle

    member this.volumeCylinder (a:float, b:float, x:float, y:float,h:float) =
        if (_areaCircle<>0.0) then 
            this.readWriteAreaVolumeCylinder <- (_areaCircle*h)
            printfn " Volume Cylinder : %f " this.readWriteAreaVolumeCylinder
        else
        printfn " Radius = %f"  (equation(1,a,b,x,y))
        //TODO: можно осущ ввод координат, но для уч цели задаются изначально
        this.readWriteAreaVolumeCylinder <- (Math.PI*Math.Pow((equation(1,a,b,x,y)),2.0)*h)
        printfn " Volume Cylinder : %f " this.readWriteAreaVolumeCylinder

    member private this.readWriteAreaCircle
        with get() = _areaCircle
        and set(value) = _areaCircle <-value

    member private this.readWriteAreaVolumeCylinder
        with get() = _volumeCylinder
        and set(value) = _volumeCylinder <-value
    
    (*Новая программа «Работа с числами». Написать рекурсивную
    функцию для нахождения суммы цифр числа. Использовать рекурсию
    вверх.*)    
    member this.sumDigElm (x:int) =
        match x with
        |x when x=0 -> 0
        |x -> (x%10)+this.sumDigElm(x/10)

[<EntryPoint>]
let main argv =
    let mathCalculation = MathematicalFuntionClass()
    mathCalculation.squareEquation(2.5,3.5,5.0,7.0)
    mathCalculation.areaCircle(2.5,3.5,5.0,7.0)
    mathCalculation.volumeCylinder(2.5,3.5,5.0,7.0,2.9)
    printfn "%d" (mathCalculation.sumDigElm(123))
    0 // return an integer exit code
