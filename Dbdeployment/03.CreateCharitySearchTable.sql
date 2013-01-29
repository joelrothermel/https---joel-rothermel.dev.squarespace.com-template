
use iMisdev
go
if object_id('dbo.CharitySearch') is not null
	drop table dbo.CharitySearch
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
	@SkillsDefaults = @SkillsDefaults + 'alter table dbo.CharitySearch add constraint DF_SK' 
	+ convert(varchar(12), SkillId) 
	+ ' default(0) for SK' + convert(varchar(12), SkillId)  + char(10),
	@SkillsCheck = @SkillsCheck + 'alter table dbo.CharitySearch add constraint CHECK_SK'
		 + convert(varchar(12), SkillId) + ' check (SK' + convert(varchar(12), SkillId) + ' in (0,1))' + char(10)
from dbo.Skill







set @Areas = ''
set @AreasDefaults = ''
set @AreasCheck = ''
select 
	@Areas = @Areas + ',AR' + convert(varchar(12), ServiceAreaId) + ' tinyint not null',
		@AreasDefaults = @AreasDefaults + 'alter table dbo.CharitySearch add constraint DF_AR' 
	+ convert(varchar(12), ServiceAreaId) 
	+ ' default(0) for AR' + convert(varchar(12), ServiceAreaId)  + char(10),
	@AreasCheck = @AreasCheck + 'alter table dbo.CharitySearch add constraint CHECK_AR'
		 + convert(varchar(12), ServiceAreaId) + ' check (AR' + convert(varchar(12), ServiceAreaId) + ' in (0,1))' + char(10)
from dbo.ServiceArea






set @TableTemplate = '
create table dbo.CharitySearch (
	CharityId varchar(12) not null
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
create clustered index CX_Charity_Search_Zip on dbo.CharitySearch (Zip)
go
alter table dbo.CharitySearch
	add constraint PK_CharitySearch primary key nonclustered (CharityId)
go
create nonclustered index CX_Charity_Search_State on dbo.CharitySearch(State, City)
go
--select * from dbo.Charitysearch


go
grant update, insert, delete, select on dbo.CharitySearch to CNMDallasDbUser
go