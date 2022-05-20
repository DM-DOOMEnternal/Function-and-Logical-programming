open System
open System.Windows.Forms
open System.Drawing
Application.EnableVisualStyles()

(*Создать новый массив, в котором порядок элементов существующего массива будет изменен на обратный (Привет -> тевирП).*)

[<EntryPoint>]
let main argv =
    let form = new Form(Text="Работа с массивом.")
   
    //Создание подписи для поля ввода 
    let label1 = new Label()
    label1.Location<-new Point(100,25)
    label1.Text<-"Исходный:"
    label1.Width<-60
    label1.Height<-12

    //Создание подписи для поля вывода
    let label2 = new Label()
    label2.Location<-new Point(100,70)
    label2.Text<-"Новый:"
    label2.Width<-60
    label2.Height<-12

    //Создание текстового поля для ввода информации
    let txtInputA = new TextBox()
    txtInputA.Location<-new Point(170,25)
    txtInputA.Width<-100
    txtInputA.Height<-25
    txtInputA.Text<-""

    //Создание текстового поля для вывода информации
    let txtOutputA = new TextBox()
    txtOutputA.Location<-new Point(170,70)
    txtOutputA.Width<-100
    txtOutputA.Height<-25
    txtOutputA.Text<-""

    //Read array 
    let getArrayFromTextBox (txt: TextBox) =
        let str = txt.Text.Trim()
        if String.IsNullOrEmpty str then 
            [||]
        else
            let parts = str.Split(' ')
            Array.map (fun str ->   Int32.Parse str) parts
    
    // 360 degree
    let button1 = new Button(Text="Вывод")
    button1.Location<-new Point(15,110)
    button1.Click.AddHandler(fun _ _ ->
           let array1 = getArrayFromTextBox txtInputA
           let array2 = Array.rev array1
           txtOutputA.Text <- (array2 |> sprintf "%A")
           array2|> ignore)

   
    let button2 = new Button(Text="Выход.")
    button2.Location<-new Point(200,235)
    button2.Click.AddHandler(fun _ _ ->
           let cl = form.Close()
           cl
           |> ignore)


    form.Controls.Add(button1)
    form.Controls.Add(button2)
    form.Controls.Add(label1)
    form.Controls.Add(label2)
    form.Controls.Add(txtInputA)
    form.Controls.Add(txtOutputA)
    Application.Run(form)
    0