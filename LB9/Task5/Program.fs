open System
open System.Drawing
open System.Windows.Forms
open System.IO

(*1. Разработать программу, состоящую из трех форм. 
На главной форме находится меню (MainMenu), через которое осуществляется переход на другие формы.*)
[<EntryPoint>]
let main argv =
    let form = new Form(Width = 815, Height = 452, Text = "Меню", Menu = new MainMenu())
    let button1 = new Button(Text = "начало", Top = 100, Left = 200, Width = 400, Height = 140,BackColor = System.Drawing.Color.Red,
    Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))

    //Ф 1 
    let form1 = new Form(Text = "Жизнь проста", Width = 450, Height = 300)
    let label1 = new Label(Text = "Ваш ненавидимый ЯП?", AutoSize = true, Location = new System.Drawing.Point(60, 50),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    form1.Controls.Add(label1)
    let opForm1 EventsArgs = do form1.ShowDialog()
    button1.Click.Add opForm1
    form.Controls.Add(button1)
    let button2 = new Button(Text = "F#1", Top=125, Left = 50, Width = 100, Height = 50)
    let button3 = new Button(Text = "Или все такие F#!.", Top = 125, Left = 250, Width = 100, Height = 50)
    form1.Controls.Add(button2)
    form1.Controls.Add(button3)

    //Ф 2 
    let form2 = new Form(Text= "Минус", Width = 300, Height = 160)
    let opForm2 EventsArgs = do form2.ShowDialog()
    button2.Click.Add(opForm2)
    let label2 = new Label(Text = "Такой минус",AutoSize = true, Location = new System.Drawing.Point(60, 50),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    form2.Controls.Add(label2)
    
    //Ф 3
    let  = new Form(Text= "Стоп", Width = 300, Height = 160)
    let opForm3 EventsArgs = do form3.ShowDialog()
    button3.Click.Add(opForm3)
    let label3 = new Label(Text = "Ты кто?",AutoSize = true, Location = new System.Drawing.Point(60, 50),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    form3.Controls.Add(label3)

    do Application.Run(form)
    0 
	
	