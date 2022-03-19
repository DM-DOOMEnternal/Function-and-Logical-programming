open System 

(*Дан целочисленный массив, в котором лишь один элемент 
отличается от остальных. Необходимо найти значение этого элемента.*) 

let rec outPutList list = 
    match list with 
    |head::[] -> printfn "%A" head 
    |head::tail-> printf "%A," head; outPutList tail 
    |[]-> printfn "" 

let quael elm1 list2 = List.exists(fun x -> (elm1=(fst(x))) && (snd(x))=1 ) list2 

[<EntryPoint>] 
let main argv = 

    let list = [1;2;3;4;5;2;1;5;3] 
    outPutList list  
    let res = List.countBy id <| list 
    outPutList res    
    let result = List.find(fun lx  -> quael lx res ) list 
    printf " \nэлемент отличается от остальных %d " result
    0
   (*Дан целочисленный массив, в котором лишь один элемент 
    отличается от остальных. Необходимо найти значение этого элемента.*) 
 