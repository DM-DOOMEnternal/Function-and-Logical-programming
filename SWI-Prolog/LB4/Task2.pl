%������� 2 ������ 5 �����.
%1 ��� ����. ��������� �� ����� ������ � ������� ����� ����������
%������.
%

readFileLStr(X) :-
    open('C:/Users/Knight/Documents/F#/GitHub/LB6/LB6/SWI-Prolog/LB4/File.txt', read, Str),
    read_file(Str,[],L),
    close(Str),
    maxList(L,X).

read_file(Stream,L,L2) :-
    \+ at_end_of_stream(Stream),
    read_line_to_string(Stream,X),
    %read_line(Stream,X),reverse(Xs, X),
    %string_to_list(S, Xs),
    %write(S),nl,
    read_file(Stream,[X|L],L2).
read_file(_,L,L).

maxList([H],S):- string_length(H,C), S is C.
maxList([H|Tail],Max):-
    maxList(Tail,MaxElm),
    string_length(H,P),
    MaxElm > P,!, Max=MaxElm;
    string_length(H,P),Max = P.

%2 ��� ����. ����������, ������� � ����� �����, �� ����������
%�������.







%3 ��� ����, ����� � ������� �� ����� ������ �� ������, � ������� ����
%� ������, ��� � ������� �� ������.




%4 ��� ����, ������� ����� ������ �����.




%5 ��� ����, ������� � ��������� ���� ������, ��������� �� ����, ��
%������������� � �������� �����.