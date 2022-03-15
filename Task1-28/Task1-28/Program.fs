// Learn more about F# at http://fsharp.org

open System
(*Дан целочисленный массив. Необходимо найти элементы,
расположенные между первым и последним максимальным*)
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


let maxElm x y =
    match x with
    |x when x >= y -> true
    |x->false

let lastMaxList list list2 max fMax =
    let rec maxList list list2 max index indexMax fMax =
        match list with
        |[]-> (list2@[max]@[indexMax])
        |head::tail when (fMax head max ) -> maxList tail list2 head (index+1) index fMax
        |head::tail -> maxList tail list2 max (index+1) indexMax fMax
    maxList list list2 max 0 0 fMax

let firstMaxList list list2 lastMax indexLastMax =
    let rec firstMax list list2 index lastMax indexLastMax =
        match list with
        |[]-> list2
        |head::tail when (head=lastMax) && (index<>indexLastMax)  -> (list2@[head]@[index])
        |head::tail -> firstMax tail list2 (index+1) lastMax indexLastMax
    firstMax list list2 0 lastMax indexLastMax

let elmFirst_LastMax list list2 indexFirst indexLast =
    let rec elmFirs_Last list list2 indexFirst indexLast index =
        match list with
        |[]->list2
        |head::tail when (index > indexFirst) && (index <indexLast) -> elmFirs_Last tail (list2@[head]) indexFirst indexLast (index+1)
        |head::tail -> elmFirs_Last tail list2 indexFirst indexLast (index+1)
    elmFirs_Last list list2 indexFirst indexLast 0


[<EntryPoint>]
let main argv =
    let list = readSizeList
    outPutList list
    let list2 = lastMaxList list [] (list.Head) maxElm
    printf " Последний максимальный элемен, индекс макс элемента  "
    outPutList list2

    let listindexLast = list2.Tail
    let list3 = firstMaxList list [] (list2.Head) (listindexLast.Head)
    if(list3=[]) then 
        printfn " Максимальный элемент один , невозможно найти элементы между 1 и последним " 
        0
    else
    
        printf " Первый максимальный элемен, индекс макс элемента  "
        outPutList list3
        
        let listindexFirst = list3.Tail
        let listElm_First_LastMax = elmFirst_LastMax list [] (listindexFirst.Head) (listindexLast.Head)

        printf " Элементы между первым и последним макс [%d,%d]" (listindexFirst.Head) (listindexLast.Head)
        outPutList listElm_First_LastMax
        0 // return an integer exit code
        (*Дан целочисленный массив. Необходимо найти элементы,
        расположенные между первым и последним максимальным*)