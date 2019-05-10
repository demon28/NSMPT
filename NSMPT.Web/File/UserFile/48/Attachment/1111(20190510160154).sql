select * from tnsmtp_account;

reg



-- Create sequence 
create sequence seq_tnsmtp_account
minvalue 1
maxvalue 9999999999999
start with 1
increment by 1
nocache;

-- Create sequence 
create sequence seq_tnsmtp_attachment
minvalue 1
maxvalue 9999999999999
start with 1
increment by 1
nocache;

-- Create sequence 
create sequence seq_tnsmtp_contact
minvalue 1
maxvalue 9999999999999
start with 1
increment by 1
nocache;

-- Create sequence 
create sequence seq_tnsmtp_mailtype
minvalue 1
maxvalue 9999999999999
start with 1
increment by 1
nocache;
