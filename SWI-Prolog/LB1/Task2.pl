man(petr).
man(alex).
man(misha).
woman(kris).
woman(katya).
woman(anna).
sister(kris).
sister(katya).
family(kris,alex).
family(kris,katya).
family(misha,kris).
sister(X,Y):- family(X,Y),woman(X).
