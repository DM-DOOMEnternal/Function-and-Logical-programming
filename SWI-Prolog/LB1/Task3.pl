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
grand_ma(X,Y):-  grandparent(X,U),woman(X),parent(U,Y).
grand_mas(X):- grandparent(X,_),woman(X).
