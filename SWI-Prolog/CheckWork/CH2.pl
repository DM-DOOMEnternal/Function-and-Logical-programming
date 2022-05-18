fib(+N,X):-X=:=0,!,N is 0;fibN(1,1,N,X,0),!.
fib(N,+X):- fib(1,1,N,X,0),!.
fib(F1,F2,N,X,Count):- Count < N,
    F11 is F2,
    F21 is F1+F2,
    Count1 is Count+1,
    fib(F11,F21,N,X,Count1).

fib(_,F3,_,X,_):- X is F3.

fibN(F1,F2,N,X,Count):-
    F2 < X,!,
    F11 is F2,
    F21 is F1+F2,
    Count1 is Count + 1,
    fibN(F11,F21,N,X,Count1);
    F2 = X,!,fibN2(N,X,Count);N is -1.
fibN2(N,_X,C):- N is C.

fib_list(List,Count):-
    countP(List,List,0,Count),!.

countP(List,[_H|T],C,C1):-
    cP(List,T,C,C1).

cP(_,[],C,C).
cP([H|T],[H2|T2],C,C1):-
    fib(Num,H2),Num = +H,!,C2 is C + 1, cP(T,T2,C2,C1);
    cP(T,T2,C,C1).

razm(List,K,Razm):-
    (   allPlacement(List,K)->nl;true),
    open('Ch.txt',read,Str),
    read_file(Str,[],R),
    close(Str),
    sort(R,Razm),
    write(Razm),!.

read_file(Stream,L2,L):-
    \+ at_end_of_stream(Stream),
    read_line_to_string(Stream,String),
    read_file(Stream,[String|L2],L).
read_file(_,L,L).

in_list_exlude([El|T],El,T).
in_list_exlude([H|T],El,[H|Tail]):-in_list_exlude(T,El,Tail).

allPlacement(List,K):-
    tell('Ch.txt'),
    told,
    translateNumToCode(List,[],NL),
    reverse(NL,RNL),
    aP(RNL,K,[]).

aP(_P,0,P1):-reverse(P1,L1),outFile(L1),!,fail.
aP(A,N,P):-in_list_exlude(A,El,A1),N1 is N - 1,aP(A1,N1,[El|P]).


translateNumToCode([],L,L).
translateNumToCode([H|T],L,L2):-
    number_codes(H,Y),
    translateNumToCode(T,[Y|L],L2).

outputStr_symb([],_Out):-!.
outputStr_symb([H|Tail],Out):- put(Out,H),outputStr_symb(Tail,Out).

outFile(L):-
    %outputStr_symb(L,Out),
    listTostring(L,S),
    atom_number(S,Num),
    fib(X,Num),X > -1,!,
    open('Ch.txt',append,Out),
    outputStr_symb(L,Out), put(Out,10),close(Out).

listTostring([],"").
listTostring([H|T],S):-
        listTostring(T,SS),
        number_codes(Y,H),
        concat(Y,SS,S).

%4
%
