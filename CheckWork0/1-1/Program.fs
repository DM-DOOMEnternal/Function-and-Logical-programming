// Learn more about F# at http://fsharp.org

open System

(*Реализовать функцию, вычисляющую количество делителей числа n с помощью
рекурсии вверх или вних*)

let countDelDown num =
    let rec count constNum num  acc =
        match num with
        |num when num=0 -> acc
        |num when (constNum%num=0) -> count constNum (num-1) (acc+1)
        |num -> count constNum (num-1) acc
    count num num 0

let rec countDelUp constNum num = 
    match num with
    |num when num=0 -> 0
    |num when (constNum%num=0) -> 1+countDelUp constNum (num-1)
    |num -> countDelUp constNum (num-1)

(*Реализовать функцию, вычисляющую произведение четных элементов списка с
помощью списков Черча и рекурсии вверх или вниз*)

(*
let rec writeList n =
    if(n=0) then []
    else
        let h = System.Convert.ToInt32(System.Console.ReadLine())
        let t = writeList (n-1)
        h::t

let readSizeList =
    printfn " Size List : "
    let size = System.Convert.ToInt32(System.Console.ReadLine())
    writeList size
*)

let rec outputList list =
    match list with 
    |[]-> printf "]"
    |h::t -> printfn "%d," h;outputList t

let odd x = x%2=0

let multOddElm list fOdd =
    let rec multElm list fOdd acc =
        match list with
        |[] -> acc
        |h::t when (fOdd h) -> multElm t fOdd (h*acc)
        |h::t -> multElm t fOdd acc
    multElm list fOdd 1

[<EntryPoint>]
let main argv =
    printfn "Result Down : %d" (countDelDown 50)
    printfn "Result Up : %d" (countDelUp 50 50)
    let list = [5;4;2;1;3;5]
    let multOddElmList = fun f x funcOdd -> printfn " Mult Odd elements list : %d" (f x funcOdd)
    let result = multOddElmList multOddElm list odd
    0 // return an integer exit code
