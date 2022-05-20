open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

//Разработать программу, состоящую из трех форм. 
//На главной форме находится меню, через которое осуществляется переход на другие формы.

//Главная форма с меню
let mwXaml = "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
Title='MainForm' Height='285' Width='320'>
<Grid>
<Grid.ColumnDefinitions>
<ColumnDefinition Width='156*' />
<ColumnDefinition Width='163' />
</Grid.ColumnDefinitions>
<Button Content='Сегодня ПНД' Height='75' HorizontalAlignment='Left' Margin='
12,10,0,0' Name='button9' VerticalAlignment='Top' Width='286' 
Grid.ColumnSpan='2' />
<Button Content='Что то на эврите' Height='75' HorizontalAlignment='Left' Margin='
12,86,0,0' Name='button10' VerticalAlignment='Top' Width='286'
Grid.ColumnSpan='2' />
<Button Content='Выход!' Height='25' HorizontalAlignment='Left' Margin='
12,160,0,0' Name='button11' VerticalAlignment='Top' Width='286'
Grid.ColumnSpan='2' Background = 'LightGreen'/>
<Button Content='Формы Ф шарп' Height='55' HorizontalAlignment='
Left' Margin='12,160,0,0' Name='button12' VerticalAlignment='Top'
Width='286' Grid.ColumnSpan='2' />
</Grid>
</Window>
"
// загрузка разметки XAML
let getWindow(mwXaml) = let xamlObj=XamlReader.Parse(mwXaml)
                        xamlObj :?> Window
let win = getWindow(mwXaml)
//получение экземпляров элементов управления
//главная форма:
let button9 = win.FindName("button9") :?> Button  // ф 1 
let button10 = win.FindName("button10") :?> Button // ф 2
let button11 = win.FindName("button11") :?> Button // ф 3
let button12 = win.FindName("button12") :?> Button // ф 4-выход
//обработка событий
button12.Click.AddHandler(fun _ _ -> win.Close())//выход

//Форма 3
let form3= "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
    xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
    Title='New Window' Height='221' Width='351'>
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width='156*' />
        <ColumnDefinition Width='163' />
    </Grid.ColumnDefinitions>
 <Button Content='СДАЕМ ЛАБЫ!' Height='75' HorizontalAlignment='Left' Margin='
12,10,0,0' Name='button1' VerticalAlignment='Top' Width='286' 
Grid.ColumnSpan='2' />
    <Button Content='Выход' Height='23' HorizontalAlignment='Left' Margin='
12,153,0,0' Name='button2' VerticalAlignment='Top' Width='305'
Grid.ColumnSpan='2' />
    <Label Content=' ' Grid.Column='1' Height='28' HorizontalAlignment='
Left' Margin='65,50,0,0' Name='label1' VerticalAlignment='Top' />
    </Grid>
</Window>
"
let getWindow3(form3) = 
    let xamlObj=XamlReader.Parse(form3) 
    xamlObj :?> Window
let wind3 = getWindow3(form3)
let nb13 = wind3.FindName("button1") :?> Button
let nb23 = wind3.FindName("button2") :?> Button
button12.Click.AddHandler(fun _ _ -> wind3.Show()|>ignore)
nb23.Click.AddHandler(fun _ _ -> wind3.Hide())

//Форма 2
let form2= "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
    xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
    Title='New Window' Height='221' Width='351'>
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width='156*' />
        <ColumnDefinition Width='163' />
    </Grid.ColumnDefinitions>
 <Button Content=' Что то новое' Height='75' HorizontalAlignment='Left' Margin='
12,10,0,0' Name='button1' VerticalAlignment='Top' Width='286' 
Grid.ColumnSpan='2' />
    <Button Content='Выход' Height='23' HorizontalAlignment='Left' Margin='
12,153,0,0' Name='button2' VerticalAlignment='Top' Width='305'
Grid.ColumnSpan='2' />
    <Label Content=' ' Grid.Column='1' Height='28' HorizontalAlignment='
Left' Margin='65,50,0,0' Name='label1' VerticalAlignment='Top' />
    </Grid>
</Window>
"
let getWindow2(form2) = 
    let xamlObj=XamlReader.Parse(form2) 
    xamlObj :?> Window
let wind2 = getWindow2(form2)
let nb12 = wind2.FindName("button1") :?> Button
let nb22 = wind2.FindName("button2") :?> Button
button10.Click.AddHandler(fun _ _ -> wind2.Show()|>ignore)
nb12.Click.AddHandler(fun _ _ -> wind3.Show()|>ignore)
nb22.Click.AddHandler(fun _ _ -> wind2.Hide())

//Форма 1
let form1= "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
    xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
    Title='New Window' Height='221' Width='351'>
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width='156*' />
        <ColumnDefinition Width='163' />
    </Grid.ColumnDefinitions>
 <Button Content=' Новая формочка!' Height='75' HorizontalAlignment='Left' Margin='
12,10,0,0' Name='button1' VerticalAlignment='Top' Width='286' 
Grid.ColumnSpan='2' />
    <Button Content='Выход' Height='23' HorizontalAlignment='Left' Margin='
12,153,0,0' Name='button2' VerticalAlignment='Top' Width='305'
Grid.ColumnSpan='2' />
    <Label Content=' ' Grid.Column='1' Height='28' HorizontalAlignment='
Left' Margin='65,50,0,0' Name='label1' VerticalAlignment='Top' />
    </Grid>
</Window>
"
let getWindow1(form1) = 
    let xamlObj=XamlReader.Parse(form1) 
    xamlObj :?> Window
let wind = getWindow1(form1)
let nb1 = wind.FindName("button1") :?> Button
let nb2 = wind.FindName("button2") :?> Button
button9.Click.AddHandler(fun _ _ -> wind.Show()|>ignore)
nb1.Click.AddHandler(fun _ _ -> wind2.Show()|>ignore)
nb2.Click.AddHandler(fun _ _ -> wind.Hide())


[<STAThread>] 
[<EntryPoint>]
let main argv =
    ignore <| (new Application()).Run win
    0
	
	(*Разработать программу, состоящую из трех форм. На
главной форме находится меню через которое осуществляется
переход на другие формы.*)