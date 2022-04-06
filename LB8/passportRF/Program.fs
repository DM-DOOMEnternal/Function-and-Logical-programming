// Learn more about F# at http://fsharp.org

open System
open System.Text.RegularExpressions
open System.Text
open System.Collections.Generic

(*5 Создать класс, содержащий информацию о документе.*)

type Document_PassportRF() =
    
    let mutable _serial_Passport : string = "" 
    let mutable _number_Passport : string = ""
    let mutable _surnmae_Passport : string = ""
    let mutable _name_Passport : string = ""
    let mutable _patronymic_Passport : string = ""
    let mutable _birthPlace : string =""
    let mutable _birthday : string ="01.01.1900"

    let rec checkInputSerial_Number (x : string) (y:string) =
        let reg = new Regex(@"^([\d]+)$")
        if(y="serial") then
            match x with
            |x when x.Length<6 || x.Length >6 -> printfn " Слишком коротко или длинно!(Длина = 6!) Введите заново! "; checkInputSerial_Number (System.Console.ReadLine()) y
            |x when x.Length = 6 &&  reg.IsMatch(x) -> x
            |x -> printfn " Неверно, 6 цифр! Введите заново!"; checkInputSerial_Number (System.Console.ReadLine()) y
        else
            match x with
            |x when x.Length<4 || x.Length >4 -> printfn " Слишком коротко или длинно!(Длина = 4!) Введите заново! "; checkInputSerial_Number (System.Console.ReadLine()) y
            |x when x.Length = 4 &&  reg.IsMatch(x) -> x
            |x -> printfn " Неверно, 4 цифр! Введите заново!"; checkInputSerial_Number (System.Console.ReadLine()) y

    let serial_NumberPas (typeInput : string) = checkInputSerial_Number (System.Console.ReadLine()) typeInput

    let rec checkDateBirth (x :string) =
        let reg = new Regex(@"^(0[1-9]|[1-2][0-9]|3[0-1])[- /.](0[1-9]|1[0-1-2])[- /.](19|20)\d\d$")
        match x with
        |x when x.Length<>0 && reg.IsMatch(x) -> x
        |x -> printfn "Введено неверно, придерживайтесь формата: dd.mm.yyyy"; checkDateBirth (System.Console.ReadLine())

    let rec check_Name_Sur_Patr (x:string) =
        let reg = new Regex(@"^[a-zA-z]+$")
        match x with
        |x when reg.IsMatch(x) -> x
        |x -> printfn " Неверный ввод, только буквы! "; check_Name_Sur_Patr (System.Console.ReadLine())

    let rec check_BirthPlace (x:string) =
        let reg = new Regex("^([\p{L}\p{N} \.-]+)$")
        match x with
        |x when reg.IsMatch(x) -> x
        |x -> printfn " Неверный ввод(буквы и цифры допустимы)! "; check_BirthPlace (System.Console.ReadLine())

    interface IComparable with
        member this.CompareTo(o : obj) : int =
            match o with
            | :? Document_PassportRF as other -> if this.getSerial = other.getSerial then this.getNumber.CompareTo other.getNumber else this.getSerial.CompareTo other.getSerial
            |_ -> 0


    member write.inputData =
        printfn " Input serial (6) : "
        _serial_Passport <- serial_NumberPas "serial"
        printfn " Input number (4) : "
        _number_Passport <- serial_NumberPas "number"
        printf " Input Surname : "
        _surnmae_Passport <- check_Name_Sur_Patr (System.Console.ReadLine())
        printf " Input Name : "
        _name_Passport <- check_Name_Sur_Patr (System.Console.ReadLine())
        printf " Input Patronymic : "
        _patronymic_Passport <- check_Name_Sur_Patr (System.Console.ReadLine())
        printf " Input Birth Place : "
        _birthPlace <- check_BirthPlace (System.Console.ReadLine())
        printf " Input BirthDay (dd.mm.yyyy): "
        _birthday <- checkDateBirth (System.Console.ReadLine())

    member print.printDocument =
        printfn " Serial   Number   Surname    Name    Patronymic    birthPlace    birthday\n"
        printfn " %s  %s   %s  %s  %s  %s  %A " _serial_Passport _number_Passport _surnmae_Passport _name_Passport _patronymic_Passport _birthPlace _birthday

    override this.Equals (x : obj) =
        match x with
        | :? Document_PassportRF as other -> (other.getSerial = this.getSerial) && (other.getNumber = this.getNumber)
        |_->false

    override this.GetHashCode() =
        HashCode.Combine(_serial_Passport,_number_Passport)

    member serial.getSerial
        with get() = _serial_Passport
        and private set(value : string) = _serial_Passport <- value
    member number.getNumber
        with get() = _number_Passport
        and private set(value:string) = _number_Passport <-value
    member surname.getSurname
        with get() = _surnmae_Passport
    member name.getName
        with get() = _name_Passport
    member patronymic.getPatronymic
        with get() = _patronymic_Passport
    member birthdayPlace.getBirthPlace
        with get() = _birthPlace
    member birthday.getBirthday
        with get() = _birthday

[<AbstractClass>]
type CollectionDocument() =
    abstract member searchDoc : Document_PassportRF -> bool

type ArrayPassports( listPass : Document_PassportRF list) =
    inherit CollectionDocument()

    member this.ArrayPass = Array.ofList listPass

    override this.searchDoc(passport : Document_PassportRF) =
        Array.exists(fun x -> x.Equals passport) this.ArrayPass

type ListPassports(listPass : Document_PassportRF list) =
    inherit CollectionDocument()

    member this.ListPass = listPass

    override this.searchDoc(passport : Document_PassportRF) =
        List.exists(fun x -> x.Equals passport) this.ListPass

type SetPassports(listPass : Document_PassportRF list) =
    inherit CollectionDocument()

    member this.ListPass = Set.ofList listPass

    override this.searchDoc( passport : Document_PassportRF)=
        Set.contains passport this.ListPass

type BinPassport( listPass : Document_PassportRF list) =
    inherit CollectionDocument()

    let rec TreeSearch (listPass : Document_PassportRF list) (pass : Document_PassportRF) =
        match (List.length(listPass)) with
        |0 -> false
        |length -> 
            let S = length/2
            match compare pass listPass.[S] |> sign with
            |0->true
            |1-> TreeSearch listPass.[..S-1] pass
            |_->TreeSearch listPass.[S+1..] pass

    override this.searchDoc(passport) = 
        TreeSearch (List.sortBy(fun (x:Document_PassportRF) -> (x.getSerial, x.getNumber)) listPass) passport

let rec createPassport n =
    if n=0 then []
        else
            let Head = Document_PassportRF()
            Head.inputData
            let Tail = createPassport(n-1)
            Head::Tail
    

[<EntryPoint>]
let main argv =
    let passport = Document_PassportRF()
    passport.inputData
    (*passport.printDocument
    let passport2 = Document_PassportRF()
    passport2.inputData
    passport2.printDocument*)
    let listPass = createPassport 2 @ [passport] @ createPassport 1
    let passArray = ArrayPassports(listPass)
    let passList = ListPassports(listPass)
    let passSet = SetPassports(listPass)
    let passTree = BinPassport(listPass)


   // printfn "%b" (passport = passport2) 

    0 
(*Task 5 1 April 17 00
  Task 6 2 April 9 43
  Task 7 4 April 16 00
  Task 8 4 April 17 22*)