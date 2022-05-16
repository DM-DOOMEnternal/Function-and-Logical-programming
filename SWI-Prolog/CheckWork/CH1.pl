
gcd(X,0,X):-!.
gcd(_,0,_):- !,fail.
gcd(X,Y,Z):- M is  X mod Y, gcd(Y,M,Z).

mutuallySimple(X,Y):-
    gcd(X,Y,1),!, true;false.



max_list(List):-indList(List,0,0,0,IndMax),write("Index"),write(IndMax).


indList([],_,IndMax,_,CurInd):- CurInd is IndMax.
indList([H|T],Ind,IndMax,Max,CurInd):-
     sumDig(H,0,S),
     maxSumDig(S,Max,NMax),S = NMax, S < H,
     mutuallySimple(S,H),!,IndMax1 is Ind,Ind1 is Ind + 1,
     indList(T,Ind1,IndMax1,NMax,CurInd);
     Ind1 is Ind + 1,indList(T,Ind1,IndMax,Max,CurInd).


maxSumDig(X,Max,NMax):- X>Max,!,NMax is X; NMax is Max.

sumDig(0,C,C):-!.
sumDig(X,C,S):- X1 is X mod 10, C1 is C + X1, X2 is X div 10,
    sumDig(X2,C1,S).
%суммма цифр элемента меньше самого элемента'
%
listTostring([],"").
listTOstring([H|T],S):-
        listTOstring(T,SS),
        number_codes(Y,H),
        concat(Y,SS,S).


allCombinationR(List,K,L):-
     (   allCombinationRep(List,K) -> nl;true),
     open('Ch.txt', read, Str),
     read_file(Str,[],L),
     close(Str),
     write(L),!.

read_file(Stream,L,L2) :-
    \+ at_end_of_stream(Stream),
    read_line_to_string(Stream,X),
    read_file(Stream,[X|L],L2).
read_file(_,L,L).

%Все перестановки в файл-----------------
allCombinationRep(List,K):-
    tell('Ch.txt'),told,
    translateNumToCode(List,[],NL),
    reverse(NL,RNL),
    aCR(RNL,K,Comb),
    outFile(Comb),fail.


aCR(_,0,[]):-!.
aCR([H|T],K,[H|L]):- K1 is K - 1,aCR([H|T],K1,L).
aCR([_|T],K,L):-aCR(T,K,L).


translateNumToCode([],L,L).
translateNumToCode([H|T],L,L2):-
    number_codes(H,Y),
    translateNumToCode(T,[Y|L],L2).

outputStr_symb([],_Out):-!.
outputStr_symb([H|Tail],Out):- put(Out,H),outputStr_symb(Tail,Out).

outFile(L):-
    open('Ch.txt',append,Out),
    outputStr_symb(L,Out),put(Out,10),close(Out).
%++++++++++++++++++++++++++++++++++++++++++++++++++++++++
