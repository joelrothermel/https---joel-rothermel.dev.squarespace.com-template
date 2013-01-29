/*
SQL Server (Internal)     cnm-dc01\imis
SQL Server (External)     66.162.219.157
*/
go

use iMisDev
go

if object_id('dbo.CharityMatchUser') is not null
drop table dbo.CharityMatchUser
go


if object_id('dbo.BoardMemberServiceArea') is not null
	drop table dbo.BoardMemberServiceArea
go
if object_id('dbo.CharityServiceArea') is not null
	drop table dbo.CharityServiceArea
go


if object_id('dbo.CharitySkill') is not null
	drop table dbo.CharitySkill

go

if object_id('dbo.BoardMemberSkill') is not null
	drop table dbo.BoardMemberSkill
go
if object_id('dbo.Skill') is not null
	drop table dbo.Skill
go
if object_id('dbo.ServiceArea') is not null
	drop table dbo.ServiceArea
go


--create table dbo.CharityMatchUser
--(
--	CharityMatchUserId int identity (100, 1),
--	Username varchar(30) not null,
--)
--go
--alter table dbo.CharityMatchUser
--	add constraint PK_CharityMatchUser primary key clustered (CharityMatchUserId)
--go
--alter table dbo.CharityMatchUser
--	add constraint unq_UserName  unique (UserName)




if object_id('dbo.BoardMember') is not null
	drop table dbo.BoardMember
go
create table dbo.BoardMember (
	BoardMemberId int not null identity (1000, 1),
	FirstName nvarchar(100) not null,
	LastName nvarchar(100) not null,
	Employer nvarchar (150) not null,
	Title nvarchar(150) not null,
	Phone nvarchar(50) not null,
	Email nvarchar(150) not null,
	Password nvarchar(50) not null,
	Address1 nvarchar(150) not null,
	Address2 nvarchar(150) null,
	City nvarchar(150) not null,
	[State] nchar(2) not null,
	PostalCode nvarchar(25) not null,
	Ethnicity varchar(30) null,
	Gender varchar(10) null,
	YearsService smallint null,
	MissionStatement nvarchar(max) not null,
	BirthDay smalldatetime not null,
	IsSearchable bit not null
)
go
alter table dbo.BoardMember
	add constraint PK_BoardMember primary key clustered (BoardMemberId)
go

alter table dbo.BoardMember
	add constraint unq_Email unique (Email)



if object_id('dbo.Charity') is not null
	drop table dbo.Charity
go
create table dbo.Charity (
	CharityId varchar(12) not null,
	OrganizationName nvarchar (150) not null,
	FirstName nvarchar(100) not null,
	LastName nvarchar(100) not null,
	Phone nvarchar(50) not null,
	Email nvarchar(150) not null,
	Website nvarchar(250) not null,
	Address1 nvarchar(150) not null,
	Address2 nvarchar(150) null,
	City nvarchar(150) not null,
	[State] nchar(2) not null,
	PostalCode nvarchar(25) not null,
	YearsService smallint null,
	Essay nvarchar(max) not null,
	IsSearchable bit not null
	
)
go
alter table dbo.Charity 
	add constraint PK_Charity  primary key clustered (CharityId)
go
alter table dbo.Charity
	add constraint unq_OrganizationName unique (OrganizationName)
go
create table dbo.Skill (
	SkillId int not null ,
	SkillName nvarchar(150) not null
) 
go
alter table dbo.Skill
	add constraint Pk_Skill primary key clustered (SkillId)
go
create table dbo.CharitySkill (
	CharityId varchar(12) not null,
	SkillId int not null
)
go
alter table dbo.CharitySkill
	add constraint PK_CharitySkill primary key clustered (CharityId, SkillId)
go
alter table dbo.CharitySkill
	add constraint FK_CharitySkill_Skill foreign key  (SkillId)
	references dbo.Skill(SkillId)
go
alter table dbo.CharitySkill
	add constraint FK_CharitySkill_Charity foreign key  (CharityId)
	references dbo.Charity(CharityId)
go



create table dbo.BoardMemberSkill (
	BoardMemberId int not null,
	SkillId int not null
)
go
alter table dbo.BoardMemberSkill
	add constraint PK_BoardMemberSkill primary key clustered (BoardMemberId, SkillId)
go

alter table dbo.BoardMemberSkill
	add constraint FK_BoardMemberSkill_Skill foreign key  (SkillId)
	references dbo.Skill(SkillId)
go
alter table dbo.BoardMemberSkill
	add constraint FK_BoardMemberSkill_BoardMember foreign key  (BoardMemberId)
	references dbo.BoardMember(BoardMemberId)
go

go


create table dbo.ServiceArea (
	ServiceAreaId int not null ,
	ServiceAreaName nvarchar(150) not null
) 
go
alter table dbo.ServiceArea
	add constraint Pk_ServiceArea primary key clustered (ServiceAreaId)
go
create table dbo.BoardMemberServiceArea (
	BoardMemberId int not null,
	ServiceAreaId int not null
)
go
alter table dbo.BoardMemberServiceArea
	add constraint PK_BoardMemberServiceArea primary key clustered (BoardMemberId, ServiceAreaId)
go
alter table dbo.BoardMemberServiceArea
	add constraint FK_BoardMemberServiceArea_ServiceArea foreign key  (ServiceAreaId)
	references dbo.ServiceArea(ServiceAreaId)
go
alter table dbo.BoardMemberServiceArea
	add constraint FK_BoardMemberServiceArea_BoardMember foreign key  (BoardMemberId)
	references dbo.BoardMember(BoardMemberId)
go
go
create table dbo.CharityServiceArea (
	CharityId varchar(12) not null,
	ServiceAreaId int not null
)
go
alter table dbo.CharityServiceArea
	add constraint PK_CharityServiceArea primary key clustered (CharityId, ServiceAreaId)
go
alter table dbo.CharityServiceArea
	add constraint FK_CharityServiceArea_ServiceArea foreign key  (ServiceAreaId)
	references dbo.ServiceArea(ServiceAreaId)
go
alter table dbo.CharityServiceArea
	add constraint FK_CharityServiceArea_Charity foreign key  (CharityId)
	references dbo.Charity(CharityId)
go
alter table dbo.Charity
	add [Password] varchar(100)
go




create index ix_Skill on dbo.CharitySkill (SkillId)
create index ix_Skill on dbo.BoardMemberSkill (SkillId)
create index ix_Service on dbo.BoardMemberServiceArea (ServiceAreaId)
create index ix_Service on dbo.CharityServiceArea (ServiceAreaId)

if not exists (select * from sys.indexes where object_name(object_id) = 'Zip_Code' and Name = 'ix_state')
	create index ix_state on dbo.Zip_Code (State, City)
	


go

grant update, insert, delete, select on dbo.BoardMember to CNMDallasDbUser
grant update, insert, delete, select on dbo.Charity to CNMDallasDbUser
grant update, insert, delete, select on dbo.Skill to CNMDallasDbUser
grant update, insert, delete, select on dbo.ServiceArea to CNMDallasDbUser
grant update, insert, delete, select on dbo.CharityServiceArea to CNMDallasDbUser
grant update, insert, delete, select on dbo.CharitySkill to CNMDallasDbUser
grant update, insert, delete, select on dbo.BoardMemberSkill to CNMDallasDbUser
grant update, insert, delete, select on dbo.BoardMemberServiceArea to CNMDallasDbUser
grant update, insert, delete, select on dbo.Name to CNMDallasDbUser
grant update, insert, delete, select on dbo.Name_Security to CNMDallasDbUser
grant update, insert, delete, select on dbo.Zip_Code to CNMDallasDbUser

go








go
if object_id('dbo.LookupCharityId') is not null
	drop proc dbo.LookupCharityId
go
create proc dbo.LookupCharityId
	@WebLogin varchar(60)
as	
select 
	CharityId = .N.CO_ID, n.Company, addy.Address_1, addy.Address_2, addy.City, addy.State_province, addy.City, addy.Zip
from dbo.Name_Security ns
join dbo.name n
	on ns.ID = n.id
outer apply (
	select top 1 * from dbo.Name_Address  na where na.id = n.ID and na.address_num =  n.Bill_Address_Num
) addy	
where len(ltrim(rtrim(n.CO_ID))) > 0
and exists (
	select * from dbo.Name_Security_Groups ngs where ngs.ID = n.ID and ngs.security_group = 'Primary'
)
and Web_Login = @WebLogin
go
grant exec on dbo.LookupCharityId to CNMDallasDbUser
go
