﻿--if not exists (select 1 from dbo.[Account])
--begin
--	insert into dbo.[Account] (Email, UserName, Password, AccountName)
--	values ('joshbirnbaum107@gmail.com', 'joshbirnbaum107@gmail.com', 'password123', 'Google'),
--	('jtbirnbaum@bsu.edu', 'jtbirnbaum', 'test1234', 'Ball State'),
--	('joshbirnbaum107@gmail.com', 'jtbirnbaum', 'instatest1234', 'Instagram');
--end