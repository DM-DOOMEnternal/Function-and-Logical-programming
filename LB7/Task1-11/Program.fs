// Learn more about F# at http://fsharp.org

open System
(*Дан целочисленный массив, в котором лишь один элемент
отличается от остальных. Необходимо найти значение этого элемента.*)

let rec readList n =
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

(*let readSizeList =
    printfn "Задайте размер листа, затем вводите последовательно числа"
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    readList n*)

let rec outPutList list =
    match list with
    |head::[] -> printfn "%A" head
    |head::tail-> printf "%A," head; outPutList tail
    |[]-> printfn ""

let notQuael elm list2 = 
    let rec notQ elm list2 c =
        match list2 with
        |[]->true
        |h::t when (h <> elm) && (c=1) -> notQ elm t c
        |h::t when (h=elm) && (c=0) -> notQ elm t (c+1)
        |h::t when (h=elm) && (c=1) -> false
        |h::t -> notQ elm t c
    notQ elm list2 0


[<EntryPoint>]
let main argv =
   //
    let list = [1;2;3;4;5;2;1;5;3]
    outPutList list
    let list2 = List.map(fun x -> x) list
    printfn " List 2 : " 
    outPutList list2
    let res = List.find(fun lx -> notQuael lx list2 )list
    printfn " result = %d" res  
    0 // return an integer exit code
    (*Дан целочисленный массив, в котором лишь один элемент
    отличается от остальных. Необходимо найти значение этого элемента.*)