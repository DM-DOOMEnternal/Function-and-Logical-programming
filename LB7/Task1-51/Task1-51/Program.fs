// Learn more about F# at http://fsharp.org

open System
(*Для введенного списка построить два списка L1 и L2, где элементы L1
это неповторяющиеся элементы исходного списка, а элемент списка L2 с
номером i показывает, сколько раз элемент списка L1 с таким номером
повторяется в исходном.*)
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


let noRepeat list (x,y) =
    let rec notrep list (x,y) c =
        match list with
        |[]->true
        |h::t when h=y && c>1 -> false
        |h::t when h=y -> notrep t (x,y) (c+1)
        |h::t when c>1 -> false
        |h::t -> notrep t (x,y) c
    notrep list (x,y) 0

let repeat list (x,y) =
    let rec rep list (x,y) (i,c) =
        match list with
        |[] -> (i,c)
        |h::t when (snd(h))=y -> rep t (x,y) (i,(c+1))
        |h::t -> rep t (x,y) (i,c)
    rep list (x,y) (x,0)

[<EntryPoint>]
let main argv =
    let list = [2;3;4;5;4;3;1]
    outPutList list
    let list2 = List.filter(fun elm -> noRepeat list elm) (List.indexed(list))
    printfn "элементы L1 это неповторяющиеся элементы исходного списка "
    outPutList list2
    let list3 = List.map(fun x -> repeat (List.indexed(list)) x) list2  
    printfn "элемент списка L2 с номером i показывает, сколько раз элемент списка L1 с таким номером повторяется в исходном "
    outPutList list3
    0 // return an integer exit code
    (*Для введенного списка построить два списка L1 и L2, где элементы L1
    это неповторяющиеся элементы исходного списка, а элемент списка L2 с
    номером i показывает, сколько раз элемент списка L1 с таким номером
    повторяется в исходном.*)
