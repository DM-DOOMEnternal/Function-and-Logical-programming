// Learn more about F# at http://fsharp.org

open System

(*5 Создать класс, содержащий информацию о документе.*)

type Document_PassportRF() =

    let mutable _serial_Passport : int list =[]
    let mutable _number_Passport : int list= []
    let mutable _surnmae_Passport : string = ""
    let mutable _name_Passport : string = ""
    let mutable _patronymic_Passport : string = ""
    let mutable _birthPlace : string =""
    let mutable _birthday : string ="01.01.1900"

    let checkDigit x = 
        match x with
        |x when x%10=x -> true
        |x when x%10<>x -> false
        |x -> false
    
    let rec inputDigit a checkDig=
         match a with
         |a when checkDig a = true ->a
         |a when checkDig a = false -> printf " Неверный ввод, введите заново(одна цифра)!"
                                       inputDigit (System.Convert.ToInt32(System.Console.ReadLine())) checkDig
         |a -> a
    let rec serial_numberList n =
           if n=0 then []
           else
                let mutable a = System.Convert.ToInt32(System.Console.ReadLine())       
                let Head = inputDigit a checkDigit
                let Tail = serial_numberList (n-1)
                Head::Tail
    
    (*let rec writeBirthday data : string =
        let dataformat = "dd-MM-yyyy"
        let dat = data// DateTime.Parse(data)  
        match dat with
        |data when Int32.Parse(dat.Split(' ')[1])=2 -> 
            printf " Не верно введена дата (дд,мм,гггг)"
            writeBirthday (System.Console.ReadLine())
        |data -> (string (data)) *)

    member write.inputData =
        printfn " Input serial (6) : "
        _serial_Passport <- serial_numberList 6
        printfn " Input number (4) : "
        _number_Passport <- serial_numberList 4
        printf " Input Surname : "
        _surnmae_Passport <- System.Console.ReadLine()
        printf " Input Name : "
        _name_Passport <- System.Console.ReadLine()
        printf " Input Patronymic : "
        _patronymic_Passport <- System.Console.ReadLine()
        printf " Input Birth Place : "
        _birthPlace <- System.Console.ReadLine()
        printf " Input Birth Place (dd.mm.yyyy): "
        _birthday <- System.Console.ReadLine()

    member print.printDocument =
        printfn " Serial   Number   Surname    Name    Patronymic    birthPlace    birthday\n"
        let serial = System.String.Concat(_serial_Passport)
        let number = System.String.Concat(_number_Passport)
        printfn " %A  %A   %s  %s  %s  %s  %A " serial number _surnmae_Passport _name_Passport _patronymic_Passport _birthPlace _birthday

    member serial.getSerial
        with get() = _serial_Passport
        and private set(value:int list) = _serial_Passport <-value 
    member number.getNumber
        with get() = _number_Passport
        and private set(value:int list) = _number_Passport <-value
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


  

[<EntryPoint>]
let main argv =
    let passport = Document_PassportRF()
    passport.inputData
    passport.printDocument
    (*printfn " %A " passport.getSerial
    printfn " %A " passport.getNumber
    printfn " %A " passport.getSurname
    printfn " %A " passport.getName
    printfn " %A " passport.getPatronymic
    printfn " %A " passport.getBirthPlace
    printfn " %A " passport.getBirthday*)
    0 // return an integer exit code
(*Task 5 1 April 17 00
  Task 6 2 April 9 43*)