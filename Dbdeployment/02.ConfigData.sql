use iMisDev
go
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 1, 'Animal Welfare'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 2, 'Animal Rights'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 3, 'Arts'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 4, 'Legal'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 5, 'Senior Adult Services'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 6, 'Environmental'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 7, 'Women''s Issue'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 8, 'Domestic Violence'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 9, 'Children\Youth\Teen'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 10, 'Crime Prevention'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 11, 'Mental Health'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 12, 'Veterans\Military'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 13, 'Homelessness'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 14, 'Housing'
insert dbo.ServiceArea (ServiceAreaId, ServiceAreaName) select 15, 'Human Rights'



insert dbo.Skill (Skillid, Skillname) select 1, 'Management'
insert dbo.Skill (Skillid, Skillname) select 2, 'Education'
insert dbo.Skill (Skillid, Skillname) select 3, 'Program Development'
insert dbo.Skill (Skillid, Skillname) select 4, 'Finance'
insert dbo.Skill (Skillid, Skillname) select 5, 'Research'
insert dbo.Skill (Skillid, Skillname) select 6, 'Nonprofit Strategic Planning'
insert dbo.Skill (Skillid, Skillname) select 7, 'Government'
insert dbo.Skill (Skillid, Skillname) select 8, 'Volunteer Management'
insert dbo.Skill (Skillid, Skillname) select 9, 'Marketing / PR'
insert dbo.Skill (Skillid, Skillname) select 10, 'Technology'
insert dbo.Skill (Skillid, Skillname) select 11, 'Real Estate'
insert dbo.Skill (Skillid, Skillname) select 12, 'Human Resouces'
insert dbo.Skill (Skillid, Skillname) select 13,'Law - Bankruptcy'
insert dbo.Skill (Skillid, Skillname) select 14,'Law - Business Law'
insert dbo.Skill (Skillid, Skillname) select 15,'Law - Civi Rights'
insert dbo.Skill (Skillid, Skillname) select 16,'Law - Consumer Law'
insert dbo.Skill (Skillid, Skillname) select 17,'Law - Contracts'
insert dbo.Skill (Skillid, Skillname) select 18,'Law - Criminal Law'
insert dbo.Skill (Skillid, Skillname) select 19,'Law - Education Law'
insert dbo.Skill (Skillid, Skillname) select 20,'Law - Elder Law'
insert dbo.Skill (Skillid, Skillname) select 21,'Law - Estate Planning'
insert dbo.Skill (Skillid, Skillname) select 22,'Law - Family Law'
insert dbo.Skill (Skillid, Skillname) select 23,'Law - General Practice'
insert dbo.Skill (Skillid, Skillname) select 24,'Law - Immigration'
insert dbo.Skill (Skillid, Skillname) select 25,'Law - Intellectual Property'
insert dbo.Skill (Skillid, Skillname) select 26,'Law - Labor and Employment'
insert dbo.Skill (Skillid, Skillname) select 27,'Law - Legal Malpractice'
insert dbo.Skill (Skillid, Skillname) select 28,'Law - Medical Malpractive'
insert dbo.Skill (Skillid, Skillname) select 29,'Law - Militay Law'
insert dbo.Skill (Skillid, Skillname) select 30,'Law - Personal Injury'
insert dbo.Skill (Skillid, Skillname) select 31,'Law - Products Liability'
insert dbo.Skill (Skillid, Skillname) select 32,'Law - Real Estate'
insert dbo.Skill (Skillid, Skillname) select 33,'Law - Securities'
insert dbo.Skill (Skillid, Skillname) select 34,'Law - Social Seurity'
insert dbo.Skill (Skillid, Skillname) select 35,'Law - Taxation'
insert dbo.Skill (Skillid, Skillname) select 36,'Law - Trusts and Estates'
insert dbo.Skill (Skillid, Skillname) select 37,'Law - Veterans'' Benefits'
insert dbo.Skill (Skillid, Skillname) select 38,'Law - Wills and Probat'
insert dbo.Skill (Skillid, Skillname) select 39,'Law - Workers Compensation'








go
INSERT INTO dbo.Charity (CharityId, OrganizationName, FirstName, LastName, Phone, Address1, City, State, PostalCode, Email, Website, Essay, IsSearchable, Password)

SELECT '55768', 'Joel', 'Joel', 'Joel', 'Phone', 'Address', 'City', 'TX', '77777', 'email', 'website', 'essay', 0, 'E7cTpTAbZQvsrl0PGVb8aB2Use27WCqA9pNYx/TTdsQ='
go