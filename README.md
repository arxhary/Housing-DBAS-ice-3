# Housing-DBAS-ice-3

Add Housing schematics into ssms

Open project and go on the nuget package manager console and copy the following :

Scaffold-DbContext "Data Source=(local)\SQLEXPRESS;Initial Catalog=Housing;Integrated Security=True " Microsoft.EntityFrameWorkCore.SqlServer -outputdir "Models" -context HousingDbContext -contextdir "Data" -DataAnnotations -Force

then hit enter 
press alt + esc to exit 

run apllication
