// Learn more about F# at http://fsharp.org

open System

(*Дан целочисленный массив и интервал a..b. Необходимо найти
максимальный из элементов в этом интервале.*)

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
    |x when x > y -> true
    |x->false


let rec elmListIntervA_B list a b max fMax =
    match list with
    |[]-> max
    |head::tail when (head >a) && (head < b) && (fMax head max ) -> elmListIntervA_B tail a b head fMax
    |head::tail -> elmListIntervA_B tail a b max fMax


[<EntryPoint>]
let main argv =
    let list = readSizeList
    outPutList list
    printfn "Ввод интервала в котором ищется максимум"
    printf " a : "
    let a = System.Int32.Parse(System.Console.ReadLine())
    printf " b : "
    let b = System.Int32.Parse(System.Console.ReadLine());

    let maxElmList = elmListIntervA_B list a b Int32.MinValue maxElm

    printfn " Максимальный элемент на интервале (%d,%d) = %d" a b maxElmList
    0 // return an integer exit code

(*Дан целочисленный массив и интервал a..b. Необходимо найти
максимальный из элементов в этом интервале.*)
