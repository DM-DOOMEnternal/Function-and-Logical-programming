// Learn more about F# at http://fsharp.org

open System

(*Построить функцию, которая принимает три аргумента
- список
- предикат p : int -> bool
- функцию f : int -> int
И возвращает список, состоящий из значений f от тех элементов, которые
удовлетворяют предикату p. Реализовать с помощью этой функции функцию,
которая строит список из сумм цифр положительных элементов списка. Для
реализации воспользоваться хвостовой рекурсией и списками Черча.*)

let rec outputList list =
    match list with
    |[] -> printfn "]"
    |h::t -> printf " %d, " h; outputList t

let isPositive x = x>0

let sumDigitElm x =
    let rec summa x acc =
        match x with
        |x when x=0 -> acc
        |x -> summa (x/10) (acc+(x%10))
    summa x 0

let listOfSummDigitPosElm list pred fSum =
    let rec listOfSum list list2 pred fSum =
        match list with
        |[] -> list2
        |h::t when(pred h) -> listOfSum t (list2@[(fSum h)]) pred fSum
        |h::t -> listOfSum t list2 pred fSum
    listOfSum list [] pred fSum

(*Построить аккумулирующую функцию (свертки), которая принимает три
аргумента
- число
- предикат pr : int -> bool
- аккумулирующее значение acc
И возвращающую результат список цифр числа, удовлетворяющих предикату. С
помощью данной функции и функции из задачи один найти произведение четных
цифр числа*)

let isOddElm x = x%2=0

let multOddElm list fOdd =
    let rec multElm list fOdd acc =
        match list with
        |[] -> acc
        |h::t when (fOdd h) -> multElm t fOdd (h*acc)
        |h::t -> multElm t fOdd acc
    multElm list fOdd 1

let rec listOfOddDigElm num list fOdd acc =
    match num with
    |num when num=0 -> outputList list; multOddElm list fOdd
    |num when num%2=0 -> listOfOddDigElm (num/10) (list@[num%10]) fOdd acc
    |num -> listOfOddDigElm (num/10) list fOdd acc

let multOddDigElm num fOdd acc = listOfOddDigElm num [] fOdd acc

[<EntryPoint>]
let main argv =
    let list = [25;30;-50;-67;-90;1]
    outputList list
    let list2 = listOfSummDigitPosElm list isPositive sumDigitElm
    outputList list2
    printfn " Mult odd digit number : %d " (multOddDigElm 123456789 isOddElm 1)
    0 // return an integer exit code
