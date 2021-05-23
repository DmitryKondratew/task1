create table Contract(
id number not null,
contract_number varchar2(75 char) not null,
date_time date not null,
date_update date,
primary key(id, contract_number));
commit;

create sequence Contract_ID_SEQ
start with 1
increment by 1
maxvalue 1000000000
minvalue 1
nocycle
cache 10000000;
commit;

insert into Contract (id, contract_number, date_time, date_update) values (Contract_ID_SEQ.NEXTVAL, '15-14-376', DATE '2018-07-17', DATE '2021-05-22');

insert into Contract (id, contract_number, date_time, date_update) values (Contract_ID_SEQ.NEXTVAL, ' œ15-14-376', DATE '2019-07-17', DATE '2021-05-22');

insert into Contract (id, contract_number, date_time, date_update) values (Contract_ID_SEQ.NEXTVAL, '85-74-3765', DATE '2021-02-25', DATE '2021-05-05');

insert into Contract (id, contract_number, date_time, date_update) values (Contract_ID_SEQ.NEXTVAL, '147/05-05-2017', DATE '2018-07-17', DATE '2019-05-22');

insert into Contract (id, contract_number, date_time, date_update) values (Contract_ID_SEQ.NEXTVAL, '56/07-07-2017', DATE '2017-07-07', DATE '2018-05-22');
commit;

select * from Contract;

select * from Contract where trunc(to_date(sysdate,'dd-mm-yy') - to_date(date_update, 'dd-mm-yy')) < 60;

select id, contract_number, date_time, date_update, trunc(to_date(sysdate,'dd-mm-yy') - to_date(date_update, 'dd-mm-yy')) as days from Contract;