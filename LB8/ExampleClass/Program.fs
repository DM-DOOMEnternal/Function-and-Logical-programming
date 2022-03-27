// Learn more about F# at http://fsharp.org

open System

type Class1(ap: int, bp: string) = 
    //свойство поле данных
    let mutable propertyValue = 0
    //private
    let private_int = 123
    let priv_func() = private_int*2
    //поля инициал парам констр

    member this.a: int = ap
    member this.b: string = bp
    //methods

    member this.print() =
        printfn "%i %s" this.a this.b

    member this.mult(mult:int) =
        printfn "%i" (this.a*mult)
    //статический метод
    static member static1() = printfn "static1"  
    //метод исп прив поля
    member this.print2() =
        let temp = priv_func()
        printfn "%i" temp
    //свойство
    member this.readWriteProperty
        with get() = propertyValue
        and set (value) = propertyValue <-value
    //alternaate construct
    new() = Class1(2,"str2")
    new(i:int) = Class1(i,"str3")
    //virtual method
    abstract virtPrint: unit -> unit
    default this.virtPrint() = printfn "%i %s" this.a this.b


[<EntryPoint>]
let main argv =
    let fistclass = Class1(1,"str")
    printfn "%A" fistclass.readWriteProperty
    fistclass.print()
    fistclass.virtPrint()
    fistclass.print2()
    fistclass.mult(5)
    Class1.static1()
    fistclass.readWriteProperty <- 15
    printfn "%A" fistclass.readWriteProperty
    let seccl = Class1()
    let thcl = Class1(5)
    seccl.print()
    0 // return an integer exit code

    
