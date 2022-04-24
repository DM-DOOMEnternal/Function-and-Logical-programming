%Дан целочисленный массив. Необходимо найти индекс минимального элемента.
%
minList([H],H):-!.
minList([Head|Tail],Min):-
    minList(Tail,MinElm),
    MinElm < Head,!, Min=MinElm;
    Min = Head.

indexMinList(List,Y):- minList(List,Min), indexMinList(List,Min,0,0,Y).
indexMinList([],_Min,Count1,_,Count1):-!.
indexMinList([Head|Tail],Min,Count1,Count2,Index):-
    Head=:=Min,!,Count is Count1+Count2,indexMinList(Tail,Min,Count,1,Index);
    Count is Count2+1,indexMinList(Tail,Min,Count1,Count,Index).


