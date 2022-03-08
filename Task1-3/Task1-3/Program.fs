// Learn more about F# at http://fsharp.org

open System
(*Дан целочисленный массив. Необходимо разместить элементы,
расположенные до минимального, в конце массива.*)
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

let rec list_list2afterMinToBegin list list2 indexmin countInd1  =
    match list with
    |[]-> list2
    |head::tail when countInd1 > indexmin -> list_list2afterMinToBegin tail (list2@[head]) indexmin (countInd1+1)
    |head::tail -> list_list2afterMinToBegin tail list2 indexmin (countInd1+1)   

let rec list_list2BeforeMinToEnd list list2 indexmin countInd1  =
    match list with
    |[]-> list2
    |head:: tail when countInd1<>indexmin-> list_list2BeforeMinToEnd tail (list2@[head]) indexmin (countInd1+1)   
    |head::tail -> list2


[<EntryPoint>]
let main argv =
    let list = readSizeList
    outPutList list
    let min = minList list minElm (list.Head)
    let index = indexMinList list min 0
    printfn "Min %d [%d]" min index
    let list2=list_list2afterMinToBegin list [] index 0 
    outPutList list2
    let list3 = list_list2BeforeMinToEnd list [] index 0
    outPutList list3
    let list4 = list2 @ list3
    outPutList list4
    0 // return an integer exit code

(*Дан целочисленный массив. Необходимо разместить элементы,
расположенные до минимального, в конце массива.*)