
use iMisdev
go
if object_id('dbo.BoardMemberSearch') is not null
	drop table dbo.BoardMemberSearch
go	


declare @Skills nvarchar(max)
declare @SkillsDefaults nvarchar(max)
declare @SkillsCheck nvarchar(max)
declare @AreasDefaults nvarchar(max)
declare @Areas nvarchar(max)
declare @AreasCheck nvarchar(max)
declare @TableTemplate nvarchar(max)

set @Skills = ''
set @SkillsDefaults = ''

set @SkillsCheck = ''
select 
	@Skills = @skills + ',SK' + convert(varchar(12), SkillId) + ' tinyint not null',
	@SkillsDefaults = @SkillsDefaults + 'alter table dbo.BoardMemberSearch add constraint BMDF_SK' 
	+ convert(varchar(12), SkillId) 
	+ ' default(0) for SK' + convert(varchar(12), SkillId)  + char(10),
	@SkillsCheck = @SkillsCheck + 'alter table dbo.BoardMemberSearch add constraint BMCHECK_SK'
		 + convert(varchar(12), SkillId) + ' check (SK' + convert(varchar(12), SkillId) + ' in (0,1))' + char(10)
from dbo.Skill







set @Areas = ''
set @AreasDefaults = ''
set @AreasCheck = ''
select 
	@Areas = @Areas + ',AR' + convert(varchar(12), ServiceAreaId) + ' tinyint not null',
		@AreasDefaults = @AreasDefaults + 'alter table dbo.BoardMemberSearch add constraint MBDF_AR' 
	+ convert(varchar(12), ServiceAreaId) 
	+ ' default(0) for AR' + convert(varchar(12), ServiceAreaId)  + char(10),
	@AreasCheck = @AreasCheck + 'alter table dbo.BoardMemberSearch add constraint BMCHECK_AR'
		 + convert(varchar(12), ServiceAreaId) + ' check (AR' + convert(varchar(12), ServiceAreaId) + ' in (0,1))' + char(10)
from dbo.ServiceArea






set @TableTemplate = '
create table dbo.BoardMemberSearch (
	BoardMemberId int not null
	,Zip nvarchar(5) not null
	,City nvarchar(150) not null
	,State nvarchar(2) not null
	{skills}
	{areas}
)'


set @TableTemplate = replace(@TableTemplate, '{skills}', @Skills)
set @TableTemplate = replace(@TableTemplate, '{areas}', @Areas)


exec ( @tabletemplate )
exec ( @SkillsDefaults )
exec (@SkillsCheck)
exec ( @AreasDefaults)
exec (@AreasCheck)
go
create clustered index CX_Charity_Search_Zip on dbo.BoardMemberSearch (Zip)
go
alter table dbo.BoardMemberSearch
	add constraint PK_BoardMemberSearch primary key nonclustered (BoardMemberId)
go
create nonclustered index CX_Charity_Search_State on dbo.BoardMemberSearch(State, City)
go


go
grant update, insert, delete, select on dbo.BoardMemberSearch to CNMDallasDbUser
go


