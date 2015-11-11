SELECT
  s.schema_id  AS SchemaId,
  s.name       AS SchemaName
FROM sys.schemas s
INNER JOIN INFORMATION_SCHEMA.ROUTINES r ON s.name = r.SPECIFIC_SCHEMA
WHERE
  r.ROUTINE_TYPE = 'PROCEDURE'
GROUP BY
  s.schema_id,
  s.name