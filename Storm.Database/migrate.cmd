migrate.exe -c "data source=.;database=Storm;integrated security=true;" --dbType=sqlserver2008 --assembly=Storm.Database.dll --task=rollback:all
migrate.exe -c "data source=.;database=Storm;integrated security=true;" --dbType=sqlserver2008 --assembly=Storm.Database.dll --profile=TestData