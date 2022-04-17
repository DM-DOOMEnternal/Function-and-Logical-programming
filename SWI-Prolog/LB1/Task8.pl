%Вариант № 1 Найти количество нечетных цифр числа, больших 3
countDig(X,Y):-  countDig(X,Y,0),!.
countDig(X,Y,Count):- X>0,!,
    X1 is X div 10,
    P is X mod 10,
    (P>3,P mod 2 =\= 0 -> Count1 is Count + 1; Count1 is Count),
    countDig(X1,Y,Count1).
countDig(_,Y,Z):- Y is Z.

