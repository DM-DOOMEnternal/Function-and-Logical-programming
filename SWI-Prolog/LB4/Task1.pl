%���� ������. ������� �� ��� ���� ����� ������� � ��������
%���������� �������� � ���.
%
showStrThree(S,Count):-
    string_length(S,Count),
    write(S),
    write(','),
    write(S),
    write(','),
    write(S),nl,
    write('count:'),write(Count).
%���� ������. ����� ���������� ����.
lengthL([],0).
lengthL([_H|T],C):-
    lengthL(T,C1),
    C is C1 +1.

countWord(S,Count):- split_string(S," ","",L), lengthL(L,Count).


