%Задание 20 Реализовать предикат fib(N,X), где X – число Фибоначчи с
%номером N, причем 1 и 2 элемент равны 1 с помощью рекурсии вниз.
fib(N,X):- fib(1,1,N,X,0),!.
fib(F1,F2,N,X,Count):- Count < N,!,
    F11 is F2,
    F21 is F1+F2,
    Count1 is Count+1,
    fib(F11,F21,N,X,Count1).
fib(_,F3,_,X,_):- X is F3.

