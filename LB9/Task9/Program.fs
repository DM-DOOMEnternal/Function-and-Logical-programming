open System
open System.Windows.Forms
open System.Drawing
Application.EnableVisualStyles()

(*Разработать программу, 
которая будет выводить первый элемент списка, делящейся на 5.*)

[<EntryPoint>]
let main argv =
     let form = new Form(Width=302, Height=250,Text = "Списки.")
     let button1 = new Button(Left=21, Top=38, Text="Начальный список", Width=96,Height=46)
     let button2 = new Button(Left=21, Top=90, Text="Поработать со списком", Width=96, Height=46)
     let textBox1 = new TextBox(Left=156, Top=38, Width=114, Height=20)
     let textBox2 = new TextBox(Left=156, Top=107, Width=114, Height=20)
     
     //cчитать список
     let getListFromTextBox (txt: TextBox) =
         let str = txt.Text.Trim()
         if String.IsNullOrEmpty str then 
             []
         else
             let parts = str.Split(' ')
             List.ofArray parts |> List.map (fun x -> Int32.Parse x)
     

     
     button2.Click.AddHandler(fun _ _ ->
                    let list1  = getListFromTextBox textBox1
                    let resInd = List.findIndex(fun x-> x%5=0)list1
                    let res = list1.[resInd]
                    let run = textBox2.Text<- (res |>  string)
                    run
                    |> ignore)
     
     form.AutoScaleMode <- System.Windows.Forms.AutoScaleMode.Font;
     form.ClientSize <- new System.Drawing.Size(302, 250);
     form.Controls.Add(textBox2);
     form.Controls.Add(textBox1);
     form.Controls.Add(button1);
     form.Controls.Add(button2);
     form.Text <- "Списки";
     form.ResumeLayout(false);
     form.PerformLayout();
     Application.Run(form)
     0