SELECT
  tt.name 'UserDefinedTypeName',
  s.name 'SchemaName'
FROM sys.table_types as tt
INNER JOIN sys.schemas s
  ON tt.schema_id = s.schema_id