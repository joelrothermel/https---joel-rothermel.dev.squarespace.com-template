

declare @CharityId varchar(12)

declare tCur insensitive cursor for
	select CharityId from dbo.Charity
open tCur
while (1=1)
begin
	fetch next from tCur into @CharityId if @@fetch_status != 0 break
	exec SyncCharitySearch @CharityId
end
close tCur
deallocate tCur	

go
