begin transaction

SET DATEFORMAT dmy
bulk insert Customers
from 'f:\projects\gopher-project\data\output.csv'
with  (
	FIELDTERMINATOR=',',
	DATAFILETYPE = 'widechar'
);
select * from Customers
delete from Customers

commit