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


[<EntryPoint>]
let main argv =
    let list = [2;3;4;5;4;3;1]
    outPutList list
    let res = list |> List.countBy id
    printfn " Частота встречаемости элементов  в исходном списке: "
    outPutList res 
    let L1 = List.map fst res
    printfn " L1 неповторяющиеся элементы исходного списка "
    outPutList L1
    let L2 = List.map snd res
    printfn "элемент списка L2 с номером i показывает, сколько раз элемент списка L1 с таким номером повторяется в исходном "
    outPutList L2
    0 // return an integer exit code
    (*Для введенного списка построить два списка L1 и L2, где элементы L1
    это неповторяющиеся элементы исходного списка, а элемент списка L2 с
    номером i показывает, сколько раз элемент списка L1 с таким номером
    повторяется в исходном.*)
