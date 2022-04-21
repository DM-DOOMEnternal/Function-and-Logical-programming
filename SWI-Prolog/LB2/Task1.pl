%Найти сумму простых делителей числа.
%Рекурсия вверх

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

