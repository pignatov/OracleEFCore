# OracleEFCore
Oracle EF Core Demo with Oracle 11.2
This demo does not work, it is only for a demonstration of a problem when adding entities!

## DB Creation
```sql
CREATE TABLE EHIC (
  "Id" NUMBER(10) not null,
  "FullName"  NVARCHAR2(200) not null,
  "PIN" NVARCHAR2(10) not null,
  "IDCardNo" NVARCHAR2(100) not null,
  "IDCardIssueDate" DATE not null  
);

alter table EHIC ADD (CONSTRAINT PK_EHIC PRIMARY KEY("Id"));

CREATE SEQUENCE EHIC_SEQ START WITH 1;

create or replace trigger TRI_BI_EHIC  
   before insert on "NHIFEESSI"."EHIC" 
   for each row 
begin  
   if inserting then 
      if ((:NEW."Id" is null) or (:NEW."Id" <= 0)) then 
         select EHIC_SEQ.nextval into :NEW."Id" from dual; 
      end if; 
   end if; 
end;
```
