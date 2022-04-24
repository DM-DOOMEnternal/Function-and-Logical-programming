%Дан целочисленный массив. Необходимо найти количество элемен-
%тов, расположенных после последнего максимального
%
maxList([Max],Max):-!.
maxList([Head|Tail],Max):-
    maxList(Tail,Max1),
    Max1 > Head,!, Max = Max1;
    Max = Head.
reverseList(List,NewList):- rev(List,[],NewList).
rev([],Copy,Copy):- !.
rev([Head|Tail],Copy,NewList):-
    rev(Tail,[Head|Copy],NewList).

countAfterLastMax(List,Y):- maxList(List,Max),reverse(List,NewList),
    countAfterLastMax(NewList,Max,0,Y).
countAfterLastMax([Head|Tail],Max,Count,Y):-
    Head =\= Max,!,Count1 is Count+1,countAfterLastMax(Tail,Max,Count1,Y);
    Y is Count.


