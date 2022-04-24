%Дан Z массив и интервал a..b. Необходимо найти макс из элем в этом
% интервале.

lengthL(List,L):- lengthL(List,0,L).
lengthL([],C,L):- L is C,!.
lengthL([_Head|Tail],Count,L):-
    Count1 is Count +1,
    lengthL(Tail,Count1,L).

maxList([Max],Max):-!.
maxList([Head|Tail],Max):-
    maxList(Tail,Max1),
    Max1 > Head,!, Max = Max1;
    Max = Head.

maxElmInterval_ab(List,A,B,Y):-
    lengthL(List,I),
    B<I,!,maxElmInterval(List,A,B,0,Y);false,!.
maxElmInterval([_Head|Tail],A,B,CurInd,Y):-
    CurInd<(A-1),!,CurInd1 is CurInd + 1,maxElmInterval(Tail,A,B,CurInd1,Y);
    maxElm(Tail,A,B,CurInd,Y,[]).
maxElm([Head|Tail],A,B,CurInd,Y,L):-
    CurInd<B,!,CurInd1 is CurInd + 1, maxElm(Tail,A,B,CurInd1,Y,[Head|L]);
    maxList(L,H),Y is H.
