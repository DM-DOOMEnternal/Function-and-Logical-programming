%����� ����� ������� ��������� �����.
%�������� �����

isDiv(Num,Div):- Num mod Div =:= 0,!.
isDiv(Num,Div):-Num >= Div*Div,
    NextDiv = Div + 1,
    isDiv(Num,NextDiv).
isPrime(1):-!.
isPrime(2):-!.
isPrime(Num):- Num>0, not(isDiv(Num,2)).

sumSimpleDiv(X,Y):- sumSimpleDiv(X,X,Y).
sumSimpleDiv(0,_,0):-!.
sumSimpleDiv(X,Y,S):- Y mod X =:= 0 -> X1 is X-1,
    sumSimpleDiv(X1,Y,S1),(isPrime(X) -> S is S1+X; S is S1);
    Y mod X =\=0 -> X1 is X-1, sumSimpleDiv(X1,Y,S1), S is S1.
%Rekurs down
sumSimpleDivDown(X,Y):-X>0,!, sumSimpleDivDown(X,X,Y,0),!.
sumSimpleDivDown(X,Y,S,Z):-
    X > 0,!,
    (   Y mod X =:= 0, isPrime(X) -> Z1 is Z+X, X1 is X - 1, sumSimpleDivDown(X1,Y,S,Z1);
    Z1 is Z, X1 is X-1, sumSimpleDivDown(X1,Y,S,Z1)).
sumSimpleDivDown(_,_,S,Z):- S is Z.
