// Learn more about F# at http://fsharp.org

open System

(*Дан целочисленный массив. Вывести индексы массива в том
порядке, в котором соответствующие им элементы образуют
убывающую последовательность.*)

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

let rec noRepeatIndexList list a =
    match list with
    |[]->true
    |head::tail when a = head -> false
    |head::tail -> noRepeatIndexList tail a

let rec saveIndexDownSort list list2 max index stindex fnorepeat =
    match list with
    |[]->list2
    |head::tail when (max > head) && (index > stindex) && (fnorepeat list2 index) -> saveIndexDownSort tail (list2@[index]) head (index+1) stindex fnorepeat
    |head::tail when (max < head) && (index > stindex) && (fnorepeat list2 (index-1)) -> saveIndexDownSort tail (list2@[index-1]) max (index+1) stindex fnorepeat
    |head::tail when (max < head) && (index = stindex) && (fnorepeat list2 (index)) -> saveIndexDownSort tail (list2@[index]) head (index+1) stindex fnorepeat
    |head::tail when (max = head) && (index = stindex) && (fnorepeat list2 (index)) -> saveIndexDownSort tail (list2@[index]) head (index+1) stindex fnorepeat
    |head::tail when (index < stindex) -> saveIndexDownSort tail list2 head (index+1) stindex fnorepeat
    |head::tail -> saveIndexDownSort tail list2 max (index+1) stindex fnorepeat

[<EntryPoint>]
let main argv =
    let list = readSizeList
    outPutList list
    let a = list.Head
    let list2 = saveIndexDownSort list [] a 0 0 noRepeatIndexList
    printf " Индексы элементов который расположены по убыванию (с указанного начального) : \n"
    outPutList list2
    0 // return an integer exit code
    //563721  0 -> 0 2 4 5
    //563721 1 -> 1 2 4 5