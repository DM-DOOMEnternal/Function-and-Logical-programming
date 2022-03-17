// Learn more about F# at http://fsharp.org

open System
(*Дан целочисленный массив. Найти количество чётных элементов.*)
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


[<EntryPoint>]
let main argv =
    let list = [2;4;5;3;2;1;6;8;9]
    outPutList list
    let list2 = List.filter(fun x -> x%2=0) list
    outPutList list2
    printfn " Count odd elems : %d " (List.length(list2))
    0 // return an integer exit code
    (*Дан целочисленный массив. Найти количество чётных элементов.*)
