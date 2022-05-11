
outputStr_symb([],_Out):-!.
outputStr_symb([H|Tail],Out):- put(Out,H),outputStr_symb(Tail,Out).

outFile(L):-
    open('C:/Users/Knight/Documents/F#/GitHub/LB6/LB6/SWI-Prolog/LB4/PlacRep.txt',append,Out),
    outputStr_symb(L,Out),put(Out,10),close(Out).
elmInlist([El|_],El).
elmInlist([_|T],El):-elmInlist(T,El).

inputStr(A,N):-get0(X),recordList(X,A,[],N,0).
recordList(10,A,A,N,N):-!.
recordList(Symb,A,B,N,K):-K1 is K+1,
    %append(B,[Symb],B1),
    get0(NextSymb),
    recordList(NextSymb,A,[Symb|B],N,K1).

translateNumToCode([],L,L).
translateNumToCode([H|T],L,L2):-
    number_codes(H,Y),
    translateNumToCode(T,[Y|L],L2).

aPR(_A,0,ListPerm):-outFile(ListPerm),!,fail.
aPR(A,N,ListPerm):-elmInlist(A,El),N1 is N-1,aPR(A,N1,[El|ListPerm]).

allPlacementRepeat:-
    tell('C:/Users/Knight/Documents/F#/GitHub/LB6/LB6/SWI-Prolog/LB4/PlacRep.txt'),
    told,
    inputStr(A,_N),
    read(K),
    aAPR(A,K,[]),!.


allPlacementRepeat(List,K):-
    tell('C:/Users/Knight/Documents/F#/GitHub/LB6/LB6/SWI-Prolog/LB4/PlacRep.txt'),
    told,
    translateNumToCode(List,[],NL),
    reverse(NL,RNL),
    aAPR(RNL,K,[]).

allpermutat(List,K):-
    tell('C:/Users/Knight/Documents/F#/GitHub/LB6/LB6/SWI-Prolog/LB4/PlacRep.txt'),
    told,
    translateNumToCode(List,[],NL),
    reverse(NL,RNL),
    permutat(RNL,K,[]).


permutat(_List, 0, Perm):-
    open('C:/Users/Knight/Documents/F#/GitHub/LB6/LB6/SWI-Prolog/LB4/PlacRep.txt',append,Out),
    outputStr_symb(Perm,Out)
    ,put(Out,10)
    ,close(Out)
    ,fail.

permutat(List, K, Permut):-
  member(H, List),
  delete(List, H, Tail),
  K1 is K - 1,
  permutat(Tail, K1, [H|Permut]).
