// Learn more about F# at http://fsharp.org

open System

(*Дан целочисленный массив и натуральный индекс (число, меньшее
размера массива). Необходимо определить является ли элемент по
указанному индексу локальным минимумом.*)
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

//--------------------------------------конец вывода/ввода


let minList list index =
    let rec min list index curIndex =
        match list with
        |[] -> 0
        |head::tail  when (index = curIndex) -> head
        |head::tail -> min tail index (curIndex+1)
    min list index 0


let rec locMinLessNextElm list locmin index curindex=
    match list with
    |[]->false
    |head::tail when (curindex = (index+1)) && (head > locmin) -> true
    |head::tail when (curindex = (index+1)) && (head < locmin) -> false
    |head::tail -> locMinLessNextElm tail locmin index (curindex+1)

let searchLocMin list locmin index flocmin =
    let rec search list locmin curindex index flocmin =
        match list with
        |[]->false
        |head::tail when (curindex = (index-1)) && (head < locmin) -> flocmin tail locmin index (curindex+1)
        |head::tail when (curindex = (index-1)) && (head > locmin) -> false
        |head::tail -> search tail  locmin (curindex+1) index flocmin
    search list locmin 0 index flocmin

[<EntryPoint>]
let main argv =
    let list = readSizeList
    outPutList list

    printfn "Введите натуральный индекс меньше размера массива %d:"  list.Length   
    let indexLocMin = System.Convert.ToInt32(System.Console.ReadLine())
    let minLocIndex = minList list indexLocMin
    if((searchLocMin list minLocIndex indexLocMin locMinLessNextElm)=true) then printfn "Да, элемент по указанному индексу [%d] является локальным минимумом [%d] " indexLocMin minLocIndex 
    else
        printfn "Нет, элемент по указанному индексу [%d] не является локальным минимумом [%d] " indexLocMin minLocIndex 
    0 // return an integer exit code
    (*Дан целочисленный массив и натуральный индекс (число, меньшее
    размера массива). Необходимо определить является ли элемент по
    указанному индексу локальным минимумом.*)