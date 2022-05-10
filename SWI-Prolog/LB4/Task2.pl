%Задание 2 Решить 5 задач.
%1 Дан файл. Прочитать из файла строки и вывести длину наибольшей
%строки.
%

readFileLMaxLenStr(X) :-
    open('C:/Users/Knight/Documents/F#/GitHub/LB6/LB6/SWI-Prolog/LB4/File.txt', read, Str),
    read_file(Str,[],L),
    close(Str),
    maxList(L,X).

read_file(Stream,L,L2) :-
    \+ at_end_of_stream(Stream),
    read_line_to_string(Stream,X),
    %read_line(Stream,X),reverse(Xs, X),
    %string_to_list(S, Xs),
    %write(S),nl,
    read_file(Stream,[X|L],L2).
read_file(_,L,L).

maxList([H],S):- string_length(H,C), S is C.
maxList([H|Tail],Max):-
    maxList(Tail,MaxElm),
    string_length(H,P),
    MaxElm > P,!, Max=MaxElm;
    string_length(H,P),Max = P.

%2 Дан файл. Определить, сколько в файле строк, не содержащих
%пробелы.

readString(A,N,Flag):- get0(X),
    concatSymbol(X,A,[],N,0,Flag).

concatSymbol(-1,A,A,N,N,1):-!.
concatSymbol(10,A,A,N,N,0):-!.
concatSymbol(X,A,B,N,K,Fl):-
    K1 is K+1,
    append(B,[X],B1),
    get0(X1),
    concatSymbol(X1,A,B1,N,K1,Fl).

readStringToList(List):-readString(A,_N,Flag),readStringToList([A],List,Flag).
readStringToList(List,List,1):-!.
readStringToList(Cur_list,List,0):-
	readString(A,_N,Fl),
        append(Cur_list,[A],C_l),
        readStringToList(C_l,List,Fl).

ss([]).
ss([H|T]):- char_code(H,X),X = 32,!, fail;ss(T).

searchSpace([],C,C).
searchSpace([H|T],C,C1):-
    string_chars(H,X),
    ss(X),!,S is C+1, searchSpace(T,S,C1);
    searchSpace(T,C,C1).

readFileStrNotSpace(X):-
    see('C:/Users/Knight/Documents/F#/GitHub/LB6/LB6/SWI-Prolog/LB4/File.txt'),!,
    readStringToList(List),
    seen, % закрывает для чтения
    searchSpace(List,0,X),
    write('Count string don"t space: '), write(X).

%3 Дан файл, найти и вывести на экран только те строки, в которых букв
%А больше, чем в среднем на строку.


countA([],C,C).
countA([H|T],C,C1):- char_code(H,X),X = 65,!, S is C+1,countA(T,S,C1);countA(T,C,C1).

outString([]).
outString([H|T]):-write(H),outString(T).

searchString([]).
searchString([H|T]):-
    string_chars(H,X),
    length(X,Len),
    countA(X,0,CA),
    Mid is Len/CA,
    CA > Mid,!,outString(X),nl, searchString(T);
    searchString(T).


readFile_AMoreMiddleArifStr:-
    see('C:/Users/Knight/Documents/F#/GitHub/LB6/LB6/SWI-Prolog/LB4/File.txt'),!,
    readStringToList(List),
    seen, % закрывает для чтения
    searchString(List).

%4 Дан файл, вывести самое частое слово.




%5 Дан файл, вывести в отдельный файл строки, состоящие из слов, не
%повторяющихся в исходном файле.
