SELECT
  tt.name 'UserDefinedTypeName',
  c.column_id 'ColumnId',
  c.name 'ColumnName',
  t.name 'ColumnType',
  s.name 'SchemaName'
FROM sys.table_types as tt
INNER JOIN sys.columns as c
  ON tt.type_table_object_id = c.object_id
INNER JOIN sys.types t
  ON c.system_type_id = t.system_type_id
INNER JOIN sys.schemas s
  ON tt.schema_id = s.schema_id
WHERE t.name <> 'sysname'