men(ptr).
men(alex).
women(kris).
parent(ptr,alex).
parent(kris,alex).
mother(X,Y):- parent(X,Y),women(X).
father(X,Y):- parent(X,Y),men(X).
monster(artur).
monster(chubaka).
hunter(monster(artur)).
hunter(thief(maks)).
thief(maks).
%hunter(thief(maks)). - don't work
%factorial UP---------------------
fact(0,1):- !.
fact(N,X):- N1 is N-1,fact(N1,X1), X is X1*N.
%--------------------------------------------
%max
max(X,Y,Z):- Z>X,Z>Y.
max(X,Y,U,Z):- Z>X,Z>Y,U>Z.
%-----------------------------------
%����� ����
summaDigit(0,0):- !.
summaDigit(X,Y):- X1 is X div 10, P is X mod 10,
    summaDigit(X1,Y1), Y is Y1 + P.
%------------------------------------------
%Factorial down
factDown(N,X):- fact(N,X,1,1).
fact(N,X,Count,Z):- Count =<N,!,
    Z1 is Z * Count,
    Count1 is Count + 1,
    fact(N,X,Count1,Z1).
fact(_,X,_,Z):- X is Z. %���� ������ is ��������� = , ��
%������ �� ���������, � ������� �.� 3!=1*1*(1+1)*(1+1+1)
