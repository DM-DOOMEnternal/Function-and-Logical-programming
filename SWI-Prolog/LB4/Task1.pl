%Дана строка. Вывести ее три раза через запятую и показать
%количество символов в ней.
%
showStrThree(S,Count):-
    string_length(S,Count),
    write(S),
    write(','),
    write(S),
    write(','),
    write(S),nl,
    write('count:'),write(Count).
%Дана строка. Найти количество слов.
lengthL([],0).
lengthL([_H|T],C):-
    lengthL(T,C1),
    C is C1 +1.

countWord(S,Count):- split_string(S," ","",L), lengthL(L,Count).

%Дана строка, определить самое частое слово
in_list([El|_],El).
in_list([_|T],El):-in_list(T,El).

cmw(_H,[],C,C):-!.
cmw(H,[H|T],C,C2):-C1 is C+1,cmw(H,T,C1,C2).
cmw(H,[_|T],C,C2):-cmw(H,T,C,C2).

member1([H,_],[[H,_]|_]).
member1([H,_],[[_,_]|T]):-member1([H,_],T).

no_duble([H|T],T1):-member1(H,T),no_duble(T,T1).
no_duble([H|T],[H|T1]):-not(member1(H,T)),no_duble(T,T1).
no_duble([],[]):-!.


countMeetW([],L1,L1).
countMeetW([H|T],L1,L):- cmw(H,T,1,Count),
    countMeetW(T,[[H,Count]|L1],L).

reverseList(List,NewList):- rev(List,[],NewList).
rev([],Copy,Copy):- !.
rev([Head|Tail],Copy,NewList):-
    rev(Tail,[Head|Copy],NewList).

maxList([[H,C]],C,H):-!.
maxList([[H,C]|Tail],Max,W):-
    maxList(Tail,MaxElm,Y),
    MaxElm > C,!, Max=MaxElm,W = Y;
    Max = C, W = H.

mostOftenWord(S,W):- split_string(S," ","",L),
    countMeetW(L,[],L2),
   % reverse(L2,K),
    no_duble(L2,L1),
    maxList(L1,Max,W),
    write(Max),nl,write(W),!.
