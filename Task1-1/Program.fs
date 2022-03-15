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


let maxElm x y = 
    match x with
    |x when x > y -> x
    |x when x < y -> y
    |x -> x

let rec maxList list fmax max =
    match list with
    |[] -> max
    | head::tail -> 
        let a = fmax max head 
        maxList tail fmax a
  
let indexMaxList list max = //countInd1 countInd2 =
    let rec indexMax list max countInd1 countInd2 =
        match list with
        |[]->countInd1
        |head::tail when (head = max ) -> indexMax tail max (countInd1+countInd2+1) 0
        |head :: tail -> indexMax tail max countInd1 (countInd2+1)
    indexMax list max 0 0

let  countAfterMax_list list max fcount indexMax   =
    let rec countAfterMax list max fcount indexMax count countInd1 = // count countInd1
        match list with
        |[]->count
        |head:: tail when countInd1=indexMax-> fcount tail count 
        |head::tail -> countAfterMax tail max  fcount indexMax count (countInd1+1)
    countAfterMax list max fcount indexMax 0 0

let rec countElmList list count =
    match list with
    |[]->count
    |head::tail -> countElmList tail (count+1)

[<EntryPoint>]
let main argv =
    let list = readSizeList
    outPutList list
    let max = maxList list maxElm Int32.MinValue
    let indexmax = (indexMaxList list max)-1
    printfn "max element: %d [%d]" max indexmax
    let count = countAfterMax_list list max countElmList indexmax
    printfn "count elements after max %d: %d"  max count
    
    0 // return an integer exit code
