man(petr).
man(alex).
man(misha).
woman(kris).
woman(katya).
woman(anna).
woman(alisa).
parent(petr,kris).
parent(anna,kris).
parent(petr,alex).
parent(anna,alex).
grandparent(misha,anna).
grandparent(katya,anna).
grandparent(alisa,petr).
grand_ma_and_son(X,Y):- (grandparent(X,U),woman(X),parent(U,Y),man(Y));
(parent(U,X),man(X),grandparent(Y,U),woman(Y)).
grand_mas(X):- grandparent(X,_),woman(X).
%������� 1 ��������� �������� grand_ma_and_son(X,Y),
% ������� ���������, �������� �� X � Y �������� � ������ ��� ������ �
% ��������