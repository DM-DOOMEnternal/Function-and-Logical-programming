%������� 1 ����� ������������ ���� �����.
mult(X):- X>0,mult_digit(X,1),!.
mult_digit(0,1):-!.
mult_digit(X,Y):- X1 is X div 10, P is X mod 10,
    mult_digit(X1,Y1), Y is Y1*P.
