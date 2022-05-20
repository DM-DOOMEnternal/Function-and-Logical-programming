open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
//Главная форма
let mwXaml = "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
    xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
    Title='New Window' Height='221' Width='400'>
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width='156*' />
        <ColumnDefinition Width='163' />
    </Grid.ColumnDefinitions>
    <Button Content='Найти площадь' Grid.Column='1' Height='50' HorizontalAlignment='
Left' Margin='40,10,0,0' Name='button1' VerticalAlignment='Top'
Width='100' IsEnabled='True' />
    <Label Content='а = ' Grid.Column='1' Height='28' HorizontalAlignment='
Left' Margin='-200,6,0,0' Name='labelA' VerticalAlignment='Top' />
    <Label Content='b = ' Grid.Column='1' Height='28' HorizontalAlignment='
Left' Margin='-200,36,0,0' Name='labelB' VerticalAlignment='Top' />
    <TextBox Height='23' HorizontalAlignment='Left' Margin='50,10,0,0'
Name='textBox1' VerticalAlignment='Top' Width='180' Grid.ColumnSpan='2'
IsEnabled='True' Text = '1'/>
    <TextBox Height='23' HorizontalAlignment='Left' Margin='50,40,0,0'
Name='textBox2' VerticalAlignment='Top' Width='180' Grid.ColumnSpan='2'
IsEnabled='True' Text = '1'/>
    <Button Content='Close' Height='23' HorizontalAlignment='Left' Margin='
12,153,0,0' Name='button2' VerticalAlignment='Top' Width='305'
Grid.ColumnSpan='2' />
    <Label Content=' ' Grid.Column='1' Height='28' HorizontalAlignment='
Left' Margin='-200,90,0,0' Name='label1' VerticalAlignment='Top' />
    </Grid>
</Window>
"
// загрузка разметки XAML
let getWindow(mwXaml) = 
    let xamlObj=XamlReader.Parse(mwXaml)
    xamlObj :?> Window
let win = getWindow(mwXaml)
let nb1 = win.FindName("button1") :?> Button
let nb2 = win.FindName("button2") :?> Button
let nl = win.FindName("label1") :?> Label
let ntb0 = win.FindName("text") :?> TextBox
let ntb1 = win.FindName("textBox1") :?> TextBox
let ntb2 = win.FindName("textBox2") :?> TextBox
//обработка событий
nb1.Click.AddHandler(fun _ _ -> nl.Content<- "S = " + Convert.ToString((ntb1.GetLineText(0) |> Int32.Parse) * (ntb2.GetLineText(0) |> Int32.Parse)))
nb2.Click.AddHandler(fun _ _ -> win.Hide())
// запуск приложения
[<STAThread>] ignore <| (new Application()).Run win 

(*Разработать программу, состоящую из трех форм. На
главной форме находится меню через которое осуществляется
переход на другие формы.
2. Разработать программу решающую квадратное уравне-
ние, состоящую из одной формы. Ответ выводится в TextBox.
3. Разработать программу, реализующую простые вычис-
ление над двумя действительными числами (сложения, вычита-
ния, деления, умножения). Учесть все возможные ошибки.
4Разработать программу, состоящую из главной формы,
рисунка и одной кнопки. По нажатию на кнопку меняется ри-
сунок.
5. Разработать программу, которая по выбору месяца выда-
вала сообщение со временем года. Главная форма, а на ней вы-
падающий список с месяцами, сообщение появляется при
нажатии на кнопку.
6. Разработать приложение, состоящее из одной формы,
на которой размещены кнопка и ползунок. При изменении по-
ложения ползунка меняется ширина кнопки.
7. Разработать программу, состоящую из главной формы
на которой размещены два флажка и одна кнопка. По нажатию
на кнопку появляется сообщение «установлен первый флажок»,
«установлен второй флажок», «установлены оба флажка».
8. Разработать программу, состоящую из одной формы, на
которой размещены: поле для ввода, кнопка и список элемен-
тов. После того как ввели текст в поле ввода нажатием на кноп-
ку, он добавляет в список.
9. Разработать программу, на главной форме разместить
поле для ввода и индикатор хода загрузки. По мере ввода текста
в поле ввода заполняется индикатор.
10. Разработать приложение, вычисляющее площадь пря-
моугольника.*)