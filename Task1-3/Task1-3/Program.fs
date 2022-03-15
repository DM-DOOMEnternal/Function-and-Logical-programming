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

//-------------------------------------Конец Вывода/Ввода

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
  
let indexMinList list min   =
    let rec index_min list min indexMin =
        match list with
        |[]-> indexMin
        |head::tail when (head = min ) -> indexMin
        |head :: tail -> index_min tail min (indexMin+1)
    index_min list min 0

let list_list2afterMinToBegin list list2 indexmin  =
    let rec afterMinToBegin list list2 indexmin countInd1 =
        match list with
        |[]-> list2
        |head::tail when countInd1 > indexmin -> afterMinToBegin tail (list2@[head]) indexmin (countInd1+1)
        |head::tail -> afterMinToBegin tail list2 indexmin (countInd1+1)   
    afterMinToBegin list list2 indexmin 0


let list_list2BeforeMinToEnd list list2 indexmin  =
    let rec beforeMinToEnd list list2 indexmin countInd1 = 
        match list with
        |[]-> list2
        |head:: tail when countInd1<>indexmin-> beforeMinToEnd tail (list2@[head]) indexmin (countInd1+1)   
        |head::tail -> list2
    beforeMinToEnd list list2 indexmin 0


[<EntryPoint>]
let main argv =
    let list = readSizeList
    outPutList list
    let min = minList list minElm (list.Head)
    let index = indexMinList list min 
    printfn "Min %d [%d]" min index
    let list2=list_list2afterMinToBegin list [] index 
    outPutList list2
    let list3 = list_list2BeforeMinToEnd list [] index 
    outPutList list3
    let list4 = list2 @ list3
    outPutList list4
    0 // return an integer exit code

(*Дан целочисленный массив. Необходимо разместить элементы,
расположенные до минимального, в конце массива.*)