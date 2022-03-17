// Learn more about F# at http://fsharp.org

open System
(*Дан целочисленный массив. Найти среднее арифметическое
модулей его элементов.*)

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
    let list = [5.0;3.0;-2.0;4.0;-1.0;-2.0;]
    outPutList list
    let result = List.fold(fun acc elm -> (Math.Abs(int elm))+acc) 0 list
    printfn " Summa : %d" result
    let result2 = (double result)/(double (List.length(list)))
    printfn " Result %f " (double result2)
    0 // return an integer exit code
    (*Дан целочисленный массив. Найти среднее арифметическое
    модулей его элементов.*)
