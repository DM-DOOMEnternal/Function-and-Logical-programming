
summaDigit(X):- summaDigit(X,0),!.
summaDigit(0,0):- !.
summaDigit(X,Y):- X1 is X div 10, P is X mod 10,
    summaDigit(X1,Y1), Y is Y1 + P.

multDiv(X,Y):- summaDigit(X,H), X1 is H, multDiv(X,X,Y,X1),!.
multDiv(1,_,1,_):-!.
multDiv(X,Y,S,SD):- Y mod X =:= 0 -> X1 is X-1,
    multDiv(X1,Y,S1,SD),summaDigit(X,H),(H<SD -> S is S1*X; S is S1);
    Y mod X =\=0 -> X1 is X-1, multDiv(X1,Y,S1,SD), S is S1.
