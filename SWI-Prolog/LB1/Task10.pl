%������� 20 ����������� �������� fib(N,X), ��� X � ����� ��������� �
%������� N, ������ 1 � 2 ������� ����� 1 � ������� �������� ����.
fib(N,X):- fib(1,1,N,X,0),!.
fib(F1,F2,N,X,Count):- Count < N,!,
    F11 is F2,
    F21 is F1+F2,
    Count1 is Count+1,
    fib(F11,F21,N,X,Count1).
fib(_,F3,_,X,_):- X is F3.

