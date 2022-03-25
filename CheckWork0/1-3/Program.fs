// Learn more about F# at http://fsharp.org

open System

(*Для введенного списка построить новый список, который получен из
начального упорядочиванием по количеству встречаемости элемента,
То есть из списка [5,6,2,2,3,3,3,5,5,5] необходимо получить список
[5,5,5,5,3,3,3,2,2,6].*)

let rec outputList list =
    match list with
    |[] -> printfn" [end] "
    |h::t -> printf " %A, " h; outputList t

let rec sort (a,b) list =
    match b with
    |b when b = 0 -> list
    |b -> sort (a,(b-1)) (list@[a])

let rec sortListcountBY curList newList fsort =
    match curList with
    |[] -> newList
    |h::t -> sortListcountBY t (fsort h newList) fsort


[<EntryPoint>]
let main argv =
    let list = [5;6;2;2;3;3;3;5;5;5]
    let res = sortListcountBY (List.sortBy(fun x -> snd(x)) (list |> List.countBy id ) |> List.rev) [] sort 
    outputList res
    0 // return an integer exit code
