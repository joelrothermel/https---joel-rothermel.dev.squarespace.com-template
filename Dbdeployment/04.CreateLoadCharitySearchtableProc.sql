
use iMisdev
go


declare @SkillsVar nvarchar(max)
declare @SkillsLookup nvarchar(max)
declare @SkillsSelect nvarchar(max)
declare @SkillsInsert nvarchar(max)
declare @AreasVar nvarchar(max)
declare @AreasLookup nvarchar(max)
declare @AreasSelect nvarchar(max)
declare @AreasInsert nvarchar(max)
declare @ProcTemplate nvarchar(max)

set @SkillsVar = ''
set @SkillsLookup = ''
set @SkillsSelect = ''
set @SkillsInsert = ''



select 
	@SkillsVar = @SkillsVar + 'declare @SK' + convert(varchar(12), SkillId) + ' tinyint' + char(10),
	@SkillsLookup = @SkillsLookup + ',@SK' + convert(varchar(12), SkillId) + ' = isnull((select 1 from dbo.CharitySkill where CharityId = @CharityId and Skillid =  ' + convert(varchar(12), SkillId) + ' ), 0)' + char(10),
	@SkillsSelect = @SkillsSelect + ',@SK' + convert(varchar(12), SkillId),
	@SkillsInsert = @SkillsInsert + ',SK' + convert(varchar(12), SkillId)
from dbo.Skill




set @AreasVar = ''
set @AreasLookup = ''
set @areasSelect = ''
set @areasInsert = ''
select 
	@AreasVar = @AreasVar + ' declare @AR' + convert(varchar(12), ServiceAreaId) + ' tinyint' + char(10),
	@AreasLookup = @AreasLookup + ',@AR' + convert(varchar(12), ServiceAreaId) + ' = isnull((select 1 from dbo.CharityServiceArea where CharityId = @CharityId and ServiceAreaId =  ' + convert(varchar(12), ServiceAreaId) + ' ), 0)' + char(10),
	@areasSelect = @AreasSelect + ',@AR' + convert(varchar(12), ServiceAreaId),
	@areasInsert = @AreasInsert + ',AR' + convert(varchar(12), ServiceAreaId)
from dbo.ServiceArea







set @ProcTemplate = '
create proc dbo.SyncCharitySearch
	@CharityId varchar(12) = ''''
as	

set transaction isolation level read uncommitted
set nocount on

declare @Zip nvarchar(5)
declare @State nvarchar(2)
declare @City nvarchar(150)



{skillsvar}

{areasvar}



delete dbo.CharitySearch where CharityId = @CharityId

/* assign stuff */
select 
	@Zip = PostalCode,
	@City = City,
	@State = State
	{skillslookup}	
	{areasslookup}	
from dbo.Charity
where CharityId = @CharityId	
and IsSearchAble = 1

if @@rowcount = 0 return

insert dbo.CharitySearch (CharityId, Zip, City, State {skillsInsert} {areasInsert})
select @CharityId, @Zip, @City, @State {skillsSelect} {areasSelect}

'


set @ProcTemplate = replace(@ProcTemplate, '{skillsvar}', @SkillsVar)
set @ProcTemplate = replace(@ProcTemplate, '{areasvar}', @AreasVar)
set @ProcTemplate = replace(@ProcTemplate, '{skillslookup}', @SkillsLookup)
set @ProcTemplate = replace(@ProcTemplate, '{areasslookup}', @AreasLookup)
set @ProcTemplate = replace(@ProcTemplate, '{skillsinsert}', @skillsInsert)
set @ProcTemplate = replace(@ProcTemplate, '{areasinsert}', @AreasInsert)
set @ProcTemplate = replace(@ProcTemplate, '{skillsSelect}', @skillsSelect)
set @ProcTemplate = replace(@ProcTemplate, '{areasSelect}', @AreasSelect)



if object_id('dbo.SyncCharitySearch') is not null exec ('drop proc dbo.SyncCharitySearch')
exec (@procTemplate)
go
grant exec on SyncCharitySearch to CNMDallasDbUser
go
--exec sp_helptext SyncCharitySearch
go
--exec SyncCharitySearch ''
