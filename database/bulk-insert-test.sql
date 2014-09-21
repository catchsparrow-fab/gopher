begin transaction

create table #temp(id int, name nvarchar(50), email nvarchar(50))
bulk insert #temp
from 'f:\projects\gopher-project\data\test.csv'
with  (
	FIELDTERMINATOR=';',
	DATAFILETYPE = 'widechar'
);
select * from #temp
drop table #temp

commit