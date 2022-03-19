
open System 

(*Дан целочисленный массив. Необходимо найти количество 
элементов, расположенных после последнего максимального.*) 

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


let indexMaxElm y max = (max=y)     

let ind indMax curind = curind > indMax 

 
[<EntryPoint>] 
let main argv = 
    //let list = readSizeList 
    let list = [2;4;5;7;4;7;3;2] 
    outPutList list 
    let maxElmList = List.max(list) 
    let index = (List.length(list)-1)-List.findIndex(fun elm -> indexMaxElm elm maxElmList) (List.rev(list)) 
    printfn " Max Elem : %d  [%d]" maxElmList index  
    let list2 = List.filter(fun elm -> ind index (fst(elm)) ) (List.indexed(list))
    outPutList list2
    printfn " Количество элементов %d " (List.length(list2))  

    0 // return an integer exit code 

    (*Дан целочисленный массив. Необходимо найти количество 

    элементов, расположенных после последнего максимального.*) 