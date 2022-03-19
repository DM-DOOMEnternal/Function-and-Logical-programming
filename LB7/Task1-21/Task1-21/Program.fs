// Learn more about F# at http://fsharp.org

open System
(*Дан целочисленный массив. Необходимо найти элементы,
расположенные после первого максимального.*)

let rec outPutList list =
    match list with
    |head::[] -> printfn "%A" head
    |head::tail-> printf "%A," head; outPutList tail
    |[]-> printfn ""

let indexMaxElm elm max = (max=elm)    

let ind indMax curind = curind > indMax 

[<EntryPoint>]
let main argv =
    let list = [4;5;7;3;2;3;7;1;2]
    outPutList list
    let maxElmList =  List.max(list)
    let index = List.findIndex(fun elm -> indexMaxElm elm maxElmList) (List.rev(list))
    printfn " Max Elem : %d [%d]" maxElmList index
    let list2 = List.filter(fun elm -> ind index (fst(elm)) ) (List.indexed(list))
    let list3 = List.map(fun x -> snd x) list2
    outPutList list3
    printfn " Количество элементов %d " (List.length(list3)) 
    0 // return an integer exit code
    (*Дан целочисленный массив. Необходимо найти элементы,
    расположенные после первого максимального.*)