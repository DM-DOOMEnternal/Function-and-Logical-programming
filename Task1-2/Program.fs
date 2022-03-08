// Learn more about F# at http://fsharp.org

open System

(*Дан целочисленный массив. Необходимо найти индекс
минимального элемента.*)

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

let minElm x y = 
    match x with
    |x when x > y -> y
    |x when x < y -> x
    |x -> x

let rec minList list fmin min =
    match list with
    |[] -> min
    | head::tail -> 
        let a = fmin min head 
        minList tail fmin a
  
let rec indexMinList list min indexMin  =
    match list with
    |[]-> indexMin
    |head::tail when (head = min ) -> indexMin
    |head :: tail -> indexMinList tail min (indexMin+1)

[<EntryPoint>]
let main argv =
    let list = readSizeList
    outPutList list
    let min = minList list minElm (list.Head)
    let index = indexMinList list min 0
    printfn "Min %d [%d]" min index
    0 // return an integer exit code
