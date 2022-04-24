%Length List

lengthList(List,L):- lengthList(List,0,L).
lengthList([],C,L):- L is C,!.
lengthList([_Head|Tail],Count,L):-
    Count1 is Count +1,
    lengthList(Tail,Count1,L).

%Rek Up
lengthL([],0):-!.
lengthL([_Head|Tail],Count):-
    lengthL(Tail,Count1),
    Count is Count1 + 1.
