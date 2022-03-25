// Learn more about F# at http://fsharp.org

open System

let fib n =
    let rec loop acc1 acc2 n =
        match n with
        | 0 -> acc1
        | 1 -> acc2
        | _ ->
            loop acc2 (acc1 + acc2) (n - 1)
    loop 0 1 n
    
let rec fib2 n =
    match n with
    |1 |2 -> 1
    |_ -> fib2 (n-1) + fib2(n-2)

let rec pr n =
    match n with
    |1 -> printfn "%d" (fib2 n)
    |_-> pr (n-1); printfn "%d" (fib2 n)


let fact k =
    let rec f acc n =
        match n with 
        |n when n=1 -> acc
        |n when n<>0 -> f (acc*n) (n-1)
    f 1 k

let odd x = x%2<>0

let sumOdd list func =
    let rec summ list func acc =
        match list with
        |[]-> acc
        |h::t when func h -> summ t func (acc+h)
        |h::t -> summ t func acc
    summ list func 0

[<EntryPoint>]
let main argv =
    //printfn "%d" (fib 16)
    //pr 8
    //printfn "%d" (fact 5)
    let list = [1;2;4;2;5;3;1]
    //let res = sumOdd list odd
   // printfn " %d " res
    let res = fun f x fodd -> printf "%d" (f x fodd)
    res sumOdd list odd
    //let count = fun f (x:int) (y:int) countfun -> printfn "Количесво взаимно простых с %d : %d " x (f x y countfun)
    //count linkcount 58 0 searchSimpleNumber
    0 // return an integer exit code
