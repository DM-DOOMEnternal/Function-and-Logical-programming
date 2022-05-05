in_list([El|_],El).
in_list([_|T],El):-in_list(T,El).

sprava_next(_A,_B,[_C]):-fail.
sprava_next(A,B,[A|[B|_Tail]]).
sprava_next(A,B,[_|List]):-sprava_next(A,B,List).

sleva_next(_A,_B,[_C]):-fail.
sleva_next(A,B,[B|[A|_Tail]]).
sleva_next(A,B,[_|List]):-sleva_next(A,B,List).


next_to(A,B,List):-sprava_next(A,B,List).
next_to(A,B,List):-sleva_next(A,B,List).

el_no(List,Num,El):-el_no(List,Num,1,El).
el_no([H|_],Num,Num,H):-!.
el_no([_|Tail],Num,Ind,El):-Ind1 is Ind+1,el_no(Tail,Num,Ind1,El).


%�������14
%�������� ���� ������: ���������, �����, ������.
%������ ������ ����������: ����������, ��� ���� �� ��� �������, ������ ������,
%������ - �����, �� �� � ���� ���� ����� �� ������������� �������. �����
%���� ����� � ������� �� ������?

pr_commun:- Friends=[_,_,_],

el_no(Friends,1,[blond,_]),
el_no(Friends,2,[brunt,_]),
el_no(Friends,3,[orange,_]),

in_list(Friends,[_,rishow]),
in_list(Friends,[_,below]),
in_list(Friends,[_,chernov]),
    (in_list(Friends,[blond,rishow]);
                in_list(Friends,[blond,chernov])),
    (in_list(Friends,[brunt,rishow]);
                in_list(Friends,[brunt,below])),
    (in_list(Friends,[orange,below]);
                in_list(Friends,[orange,chernov])),
write(Friends).



%������� �15
%��� ������� ����� � �����, ������� � ����� ������� �
%������. ��������, ��� ������ � ��� ����� ������ � ������ ���������. ��
%�����,�� ������ ���� �� ���� ������. ������ ���� � ������� ������. ����������
%����� ������ � ������ �� ������ �� ������.


��_����:- ������� =[_,_,_],
           in_list(�������,[������,_,����]),
            in_list(�������,[_,����,_]),
             in_list(�������,[_,����,_]),
              in_list(�������,[_,����,_]),
               in_list(�������,[_,_,����]),
                in_list(�������,[_,_,����]),
                 in_list(�������,[_,_,����]),
            (   in_list(�������,[���,����,����]);
                in_list(�������,[���,����,����])),
            (   in_list(�������,[������,����,_]);
                in_list(�������,[������,����,_])),
            (   in_list(�������,[������,_,����]);
                in_list(�������,[������,_,����])),
            write(�������).

%Misiion 16
% �� ������ �������� ��� �����: �������, ������ � �������. ��
% ������� �������, ������ � �������. � ������� ��� �� �������, �� ������.
% �� ����� ������� �� ������. �������, ������� �� ������ ��������,
% ������ ������. ������� ������� �������, ������ � ��������.
%
��_�����:- ������ =[_,_,_],
           in_list(������,[������,_,_,_]),
            in_list(������,[�������,_,_,_]),
             in_list(������,[�������,_,_,_]),
              in_list(������,[_,����,_,1]),
               in_list(������,[_,����,_,_]),
                in_list(������,[_,����,_,_]),
                in_list(������,[������,WHO1,2,1]),
in_list(������,[�������,WHO2,3,0]),
                in_list(������,[�������,WHO3,1,_]),
write(������),nl,

write(WHO1),nl,write(WHO2),nl,write(WHO3).
