

declare @BoardMemberId int

declare tCur insensitive cursor for
	select BoardMemberId from dbo.BoardMember
open tCur
while (1=1)
begin
	fetch next from tCur into @BoardMemberId if @@fetch_status != 0 break
	exec SyncBoardMemberSearch @BoardMemberId
end
close tCur
deallocate tCur	

go


