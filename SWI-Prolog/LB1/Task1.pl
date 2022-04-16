man(petr).
man(alex).
man(chester).
father(X,Y):- parent(X,Y), man(X).
parent(petr,alex).
parent(alex,chester).
