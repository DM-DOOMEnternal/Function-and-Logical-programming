%Дана строка. Вывести ее три раза через запятую и показать
%количество символов в ней.
%
showStrThree(S,Count):-
    string_length(S,Count),
    write(S),
    write(','),
    write(S),
    write(','),
    write(S),nl,
    write('count:'),write(Count).
