%Дан целочисленный массив. Необходимо найти элементы, расположенные между первым и последним максимальным.
%


indexMaxList(List,Y):- maxList(List,Max), indexMaxList(List,Max,0,0,Y).
indexMaxList([],_Max,Count1,_,Count1):-!.
indexMaxList([Head|Tail],Max,Count1,Count2,Index):-
    Head=:=Max,!,Count is Count1+Count2,indexMaxList(Tail,Max,Count,1,Index);
    Count is Count2+1,indexMaxList(Tail,Max,Count1,Count,Index).

indexFirstMaxList(List,Y):- maxList(List,Max),indexFirstMaxList(List,Max,0,Y).
indexFirstMaxList([Head|Tail],Max,IndMax,Y):-
    Head=\=Max,!,I is IndMax + 1,indexFirstMaxList(Tail,Max,I,Y);
    Y is IndMax.

unionList([],L1,L1):-!.
unionList([Head|Tail],L1,L2):-
    unionList(Tail,[Head|L1],L2).

newList_ElmBetweenFirstLastMax(List,List2):-
    indexMaxList(List,IMaxLast),
    indexFirstMaxList(List,IMaxFirst),
    nL_EBetweenFLM(List,IMaxFirst,IMaxLast,0,[],List2),!.
nL_EBetweenFLM([_Head|Tail],A,B,CurInd,NewList,List2):-
    CurInd<A,!,CurInd1 is CurInd + 1,nL_EBetweenFLM(Tail,A,B,CurInd1,NewList,List2);
    elmBetween(Tail,CurInd,B,NewList,List2).
elmBetween([Head|Tail],CurInd,B,NewList,List2):-
    CurInd<(B-1),!,CurInd1 is CurInd + 1,elmBetween(Tail,CurInd1,B,[Head|NewList],List2);
    unionList(NewList,[],List2).
