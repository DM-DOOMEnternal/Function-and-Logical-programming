%Вариант 1 Найти произведение цифр числа.
mult(X,Y):- X>0,!,mult_digit(X,Y,1),!.
mult_digit(X,Y,Z):- X > 0,!,
    X1 is X div 10, Z1 is Z*(X mod 10),
    mult_digit(X1,Y,Z1).
mult_digit(_,Y,Z):- Y is Z.

%Максимальная цифра
maxD(0,0):-!.
maxD(X,Y):- X1 is X div 10, P is X mod 10,
    maxD(X1,Y1), (P<Y1 -> Y = Y1; Y=P).
