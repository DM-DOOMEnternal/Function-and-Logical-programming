// Learn more about F# at http://fsharp.org

open System
(*Дан целочисленный массив. Необходимо найти элементы,
расположенные после первого максимального.*)

let rec readList n =
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readSizeList =
    printfn "Задайте размер листа, затем вводите последовательно числа"
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec outPutList list =
    match list with
    |head::[] -> printfn "%A" head
    |head::tail-> printf "%A," head; outPutList tail
    |[]-> printfn ""

let indexMaxElm elm max = (max=elm)    
 
let afterMax elm list index  = 
    let rec elms elm list index  =
        match list with
        |[] -> false
        |head::tail when (index < fst(elm)) -> true
        |head::tail -> elms elm tail index 
    elms elm list index

[<EntryPoint>]
let main argv =
    let list = readSizeList
    outPutList list
    let maxElmList =  List.max(list)
    let index = List.findIndex(fun elm -> indexMaxElm elm maxElmList) list
    printfn " Max Elem : %d [%d]" maxElmList index
    let list2 = List.indexed(list)
    outPutList list2
    let list3 = List.filter(fun elm -> afterMax elm list2 index) list2 //let list2 = afterMax list [] index
    outPutList list3
    printfn " Количество элементов %d " (List.length(list3)) 
    0 // return an integer exit code
    (*Дан целочисленный массив. Необходимо найти элементы,
    расположенные после первого максимального.*)