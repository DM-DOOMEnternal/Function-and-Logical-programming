%��� ������������� ������ � ����������� ������ (�����, �������
%������� �������). ���������� ���������� �������� �� �������
%�� ���������� ������� ��������� ���������.
%

lengthList(List,L):- lengthList(List,0,L).
lengthList([],C,L):- L is C,!.
lengthList([_Head|Tail],Count,L):-
    Count1 is Count +1,
    lengthList(Tail,Count1,L).

localMin(List,Ind):-
    lengthList(List,I), Ind<I,!,localMin(List,Ind,0);false,!.
localMin([Head|Tail],Ind,CurInd):-
    CurInd<(Ind-1),!, CurInd1 is CurInd + 1,localMin(Tail,Ind,CurInd1);
    local(Tail,Head,0).
local([Head|Tail],MinL,Count):-
    Count<2,MinL<Head,!,Count1 is Count + 1,local(Tail,Head,Count1);
    Count=:=2,!,true;
    MinL>Head,false.
local([],_MinL,Count):- Count=:=2,true,!.