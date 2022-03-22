﻿// Learn more about F# at http://fsharp.org

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

(*
let noRepeat list (x,y) =
    let rec notrep list (x,y) c =
        match list with
        |[]->true
        |h::t when h=y && c>1 -> false
        |h::t when h=y -> notrep t (x,y) (c+1)
        |h::t when c>1 -> false
        |h::t -> notrep t (x,y) c
    notrep list (x,y) 0
*)
(*
let repeat list (x,y) =
    let rec rep list (x,y) (i,c) =
        match list with
        |[] -> (i,c)
        |h::t when (snd(h))=y -> rep t (x,y) (i,(c+1))
        |h::t -> rep t (x,y) (i,c)
    rep list (x,y) (x,0)
*)
let getFirst (c,_,_) = c
let getSnd (_,c) = c
let getThird (_,_,c) = c

let quael elm1 list2 = List.exists(fun x -> (elm1=(fst(x))) && (snd(x))=1 ) list2 

//let repeat1 (x,y) res  = List.find(fun z -> snd(fst((z)))=y && fst(z)=x) res

//let search y L2 = List.find (fun z -> y=(fst(snd(z)))) L2

//let repeat (x,y) L  = List.find(fun z -> fst(z)=x && (search y L)=y ) L

let Rp x L = List.exists(fun z -> snd(z)=fst(x) && snd(x)=1) L

[<EntryPoint>]
let main argv =
    let list = [2;3;4;5;4;3;1]
    outPutList list
    //let list2 = List.filter(fun elm -> noRepeat list elm) (List.indexed(list))
    let res = list |> List.countBy id
    printfn " Частота встречаемости элементов  в исходном списке: "
    outPutList res //(List.indexed(List.rev(List.sortBy (fun (a,b) -> b=1) res)))
    let L1 = List.indexed(List.filter(fun lx  -> quael lx res ) list )
    printfn "элементы L1 это неповторяющиеся элементы исходного списка "
    outPutList L1
   // let l2 = (List.indexed(List.rev(List.sortBy (fun (a,b) -> b=1) res)))
   // outPutList l2
    //let list3 = List.map(fun x -> repeat (List.indexed(list)) x) list2  
   // let list3 = List.map(fun x -> (fst(x), repeat x l2) ) L1
    let L2 = List.indexed(List.filter(fun x -> snd(x)=1 && Rp x L1 ) res)
    printfn "элемент списка L2 с номером i показывает, сколько раз элемент списка L1 с таким номером повторяется в исходном "
    outPutList L2
    0 // return an integer exit code
    (*Для введенного списка построить два списка L1 и L2, где элементы L1
    это неповторяющиеся элементы исходного списка, а элемент списка L2 с
    номером i показывает, сколько раз элемент списка L1 с таким номером
    повторяется в исходном.*)
