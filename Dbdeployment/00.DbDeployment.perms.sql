/*
SQL Server (Internal)     cnm-dc01\imis
SQL Server (External)     66.162.219.157
*/
go
use iMisDev
go
declare @Spid int
declare @Cmd nvarchar(max)
while (1=1)
begin

	select @spid = spid from master..sysprocesses where loginame = 'CNMDallasApp'
	if @@rowcount = 0 break
	
	set @Cmd = 'kill ' + convert(varchar (50), @Spid)
	exec (@Cmd)
	break
end

go
if exists (select * from sys.database_principals where  name = 'CNMDallasDbUser')
	drop user CNMDallasDbUser
go

go
if exists (select * from sys.SERVER_principals where  name = 'CNMDallasApp')
	drop login CNMDallasApp
go
create login CNMDallasApp
	with password = '&32kjfdA&$Kaw(', Check_expiration = off, check_policy = off
go
create user CNMDallasDbUser
	for login CNMDallasApp
go