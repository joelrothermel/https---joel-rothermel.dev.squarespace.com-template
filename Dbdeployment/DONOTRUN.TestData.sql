
use iMisdev
go
set nocount on


declare @i int 
set @i = 0


with Ids as (Select i = 1
union all
select i = i+ 1 from Ids
)
insert dbo.BoardMember (FirstName,LastName,Employer,Title,Phone,Email,Address1,
						Address2,City,State,PostalCode,Ethnicity,Gender,YearsService,MissionStatement,BirthDay, Password, IsSearchAble)
select top 5000 'FN ' + right(convert(varchar(50), newid()), 8), 
	   'LN ' + right(convert(varchar(50), newid()), 8), 
	   'EMP ' + right(convert(varchar(50), newid()), 8), 
	   'TITLE ' + right(convert(varchar(50), newid()), 8), 
	   'PHONE ' + right(convert(varchar(50), newid()), 8), 
	   'EMAIL ' + right(convert(varchar(50), newid()), 8), 
	   'ADDRESS1 ' + right(convert(varchar(50), newid()), 8), 
	   'ADDRESS2 ' + right(convert(varchar(50), newid()), 8), 
	   geo.City,
	   geo.State,
	   '75974' + right(convert(varchar(50), newid()), 8),
	   'ETH',
	   case when @i % 2 = 0 then 'MALE' else 'FEMALE' end,
	   abs(convert(int, substring(convert(varbinary(50), newid()), 1, 4))) % 5,
	   'MISSION ' + replicate (right(convert(varchar(50), newid()), 8), 100),
	   '1/1/1975',
	   geo.Zip,
	   1
from Ids
cross join (
	select top 1 * from dbo.zip_Code order by newid()
) geo
option (maxrecursion 32000)	   



with Ids as (Select i = 1
union all
select i = i+ 1 from Ids
)

insert dbo.Charity (CharityId, OrganizationName,FirstName,LastName,
			Phone,Email,Website,Address1,Address2,City,State,PostalCode,YearsService,Essay,IsSearchable)
			
select top 5000
		right(convert(varchar(50), newid()), 8),
		'ORG ' + right(convert(varchar(50), newid()), 8), 
	   'FN ' + right(convert(varchar(50), newid()), 8), 
	   'LN ' + right(convert(varchar(50), newid()), 8), 
	   'PHONE ' + right(convert(varchar(50), newid()), 8), 
	   'EMAIL ' + right(convert(varchar(50), newid()), 8), 
	   'http://' + right(convert(varchar(50), newid()), 8), 
	   'ADDRESS1 ' + right(convert(varchar(50), newid()), 8), 
	   'ADDRESS2 ' + right(convert(varchar(50), newid()), 8), 
	   geo.City,
	   geo.State,
	   geo.Zip,
	   abs(convert(int, substring(convert(varbinary(50), newid()), 1, 4))) % 15,
	   'MISSION ' + replicate (right(convert(varchar(50), newid()), 8), 100),
	   1
from Ids	
cross join (
	select top 1 * from dbo.zip_Code order by newid()
) geo

option (maxrecursion 32000)	   	



delete dbo.CharitySkill
delete dbo.CharityServiceArea
declare @CharityId varchar(12)

declare tCur insensitive cursor for
	select CharityId from dbo.Charity
open tCur
while (1=1)
begin
	fetch next from tCur into @CharityId if @@fetch_status != 0 break
	insert dbo.CharitySkill (CharityId, SkillId)
	select top (abs(convert(int, substring(convert(varbinary(50), newid()), 1, 4))) % 13 + 1) @CharityId, Skillid from dbo.Skill order by newid()
	
		insert dbo.CharityServiceArea (CharityId, ServiceAreaId)
		select top (abs(convert(int, substring(convert(varbinary(50), newid()), 1, 4))) % 13 + 1) @CharityId, ServiceAreaId from dbo.ServiceArea order by newid()

end
close tCur
deallocate tCur	

go



delete dbo.BoardMemberSkill
delete dbo.BoardMemberServiceArea
declare @BoardMemberId int

declare tCur insensitive cursor for
	select BoardMemberid from dbo.BoardMember
open tCur
while (1=1)
begin
	fetch next from tCur into @BoardMemberId if @@fetch_status != 0 break
	insert dbo.BoardMemberSkill (BoardMemberid, SkillId)
	select top (abs(convert(int, substring(convert(varbinary(50), newid()), 1, 4))) % 13 + 1) @BoardMemberId, Skillid from dbo.Skill order by newid()

		insert dbo.BoardMemberServiceArea (BoardMemberid, ServiceAreaId)
		select top (abs(convert(int, substring(convert(varbinary(50), newid()), 1, 4))) % 13 + 1) @BoardMemberId, ServiceAreaId from dbo.ServiceArea order by newid()

end
close tCur
deallocate tCur
	




update dbo.BoardMember
	set email = 'test@test.com'
where boardmemberid = 1000	

update dbo.BoardMember
	set Password = 'E7cTpTAbZQvsrl0PGVb8aB2Use27WCqA9pNYx/TTdsQ='