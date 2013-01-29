


--select 
--	replace(replace(replace(replace(ServiceAreaname, ' ', ''), '/', ''), '-', ''), '''', '')
--	+ ' = ' + convert(varchar(12), ServiceAreaId) + ','
--from dbo.ServiceArea




select 
	'[SearchIndexSkillMapping(Skill.' + Att.Atty + ')]' + char(10)
	
  +'public byte ' + column_name + ' {get; set;}'
from information_schema.columns 
cross apply (
	select SkillId = convert(int, replace(column_name, 'SK', ''))
) sklz
cross apply (
	select Atty = replace(replace(replace(replace(SkillName, ' ', ''), '/', ''), '-', ''), '''', '') from dbo.Skill k where k.Skillid = sklz.SkillId
) att
where table_name = 'charitysearch'
and (column_name like 'SK%')


select 
	'[SearchIndexServiceAreaMapping(ServiceArea.' + Att.Atty + ')]' + char(10)
	
  +'public byte ' + column_name + ' {get; set;}'
from information_schema.columns 
cross apply (
	select ServiceAreaId = convert(int, replace(column_name, 'AR', ''))
) sklz
cross apply (
	select Atty = replace(replace(replace(replace(replace(ServiceAreaName, ' ', ''), '/', ''), '-', ''), '''', ''), '\', '') from dbo.ServiceArea k where k.ServiceAreaId = sklz.ServiceAreaId
) att
where table_name = 'charitysearch'
and (column_name like 'AR%')