// Learn more about F# at http://fsharp.org

open System
(*Дан целочисленный массив. Необходимо найти количество
элементов, расположенных после последнего максимального.*)

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

let maxElm list =
    List.max(list)
  
let indexMaxElm elm max = (max=elm)    
 
let afterMax list list2 index = 
    let rec elms list list2 index count =
        match list with
        |[]->list2
        |head::tail when(count > index) -> elms tail (list2@[head]) index (count+1)
        |head::tail -> elms tail list2 index (count+1)
    elms list list2 index 0
    


[<EntryPoint>]
let main argv =
    let list = readSizeList
    outPutList list
    let maxElmList = maxElm list
    let index = (List.length(list)-1)-(List.findIndex(fun elm -> indexMaxElm elm maxElmList) (List.rev(list)))
    printfn " Max Elem : %d  [%d]" maxElmList index 
    let list2 = afterMax list [] index
    outPutList list2
    0 // return an integer exit code

    (*Дан целочисленный массив. Необходимо найти количество
    элементов, расположенных после последнего максимального.*)
