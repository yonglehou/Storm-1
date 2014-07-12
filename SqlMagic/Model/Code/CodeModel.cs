using SqlMagic.Model.Database;
using SqlMagic.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Code
{
    public class CodeModel
    {
        public DatabaseModel DatabaseModel { get; private set; }
        public List<NamespaceInfo> Namespaces { get; private set; }

        public CodeModel(DatabaseModel model)
        {
            DatabaseModel = model;
            Namespaces = new List<NamespaceInfo>();
        }

        public void Initialize()
        {
            var rootNamespace = new NamespaceInfo("Database");
            Namespaces.Add(rootNamespace);

            // Schemas
            DatabaseModel.Schemas.ForEach(s =>
            {
                var schemaClass = new ClassInfo(rootNamespace, s.Name);
                rootNamespace.Classes.Add(schemaClass);
                schemaClass.Properties.Add(new PropertyInfo(schemaClass, new ClassInfo(NamespaceInfo.None, "SqlMagic.Lib.ISqlExecutor"), "SqlExecutor"));
                var constructor = new MethodInfo(schemaClass, s.Name, null)
                {
                    MethodBody = "SqlExecutor = sqlExecutor;"
                };
                constructor.Parameters.Add(new ParameterInfo(constructor, "sqlExecutor", new ClassInfo(NamespaceInfo.None, "SqlMagic.Lib.ISqlExecutor"), false));
                schemaClass.Methods.Add(constructor);

                // User defined types
                s.UserDefinedTypes.ForEach(udt =>
                {
                    var udtClass = new ClassInfo(schemaClass, udt.Name);
                    schemaClass.Classes.Add(udtClass);

                    var udtItemClass = new ClassInfo(udtClass, udt.Name + "Item");
                    udtClass.Classes.Add(udtItemClass);

                    udtClass.Inheritence = "System.Collections.Generic.List<" + udtItemClass.ToString() + ">";

                    udt.Columns.ForEach(c =>
                    {
                        var columnProperty = new PropertyInfo(udtItemClass, SqlConverter.ConvertSqlTypeToClrType(this, c.Type), c.Name);
                        udtItemClass.Properties.Add(columnProperty);
                    });
                });
            });

            DatabaseModel.Schemas.ForEach(s =>
            {
                var schemaClass = rootNamespace.Classes.Single(c => c.Name == s.Name);

                // Stored procedures
                s.StoredProcedures.ForEach(sp =>
                {
                    var spMethod = new MethodInfo(schemaClass, sp.Name + "<T>", new ClassInfo(NamespaceInfo.None, "SqlMagic.Lib.SqlResponse<T>"));
                    schemaClass.Methods.Add(spMethod);
                    
                    var methodBody = new StringBuilder();
                    methodBody.AppendLine(@"var sqlRequest = new SqlMagic.Lib.SqlRequest()");
                    methodBody.AppendLine(@"{");
                    methodBody.AppendLine(string.Format(@"StoredProcedureName = ""{0}"",", sp.Name));
                    methodBody.AppendLine(@"Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()");
                    methodBody.AppendLine(@"{");
                    
                    sp.Parameters.ForEach(p =>
                    {
                        var clrName = p.Name.Substring(1);
                        var isOut = p.ParameterModeEnum == Database.ParameterInfo.ParameterMode.InOut || p.ParameterModeEnum == Database.ParameterInfo.ParameterMode.Out;
                        var parameter = new ParameterInfo(spMethod, clrName, SqlConverter.ConvertSqlTypeToClrType(this, p), isOut);
                        spMethod.Parameters.Add(parameter);

                        if (p.UserDefinedType == null)
                        {
                            methodBody.AppendLine(@"new SqlMagic.Lib.StoredProcedureSimpleParameter()");
                            methodBody.AppendLine(@"{");
                            methodBody.AppendLine(string.Format(@"Name = ""{0}"",", p.Name));
                            methodBody.AppendLine(string.Format(@"Value = {0}", clrName));
                            methodBody.AppendLine(@"},");
                        }
                        else
                        {
                            methodBody.AppendLine(@"new SqlMagic.Lib.StoredProcedureTableTypeParameter()");
                            methodBody.AppendLine(@"{");
                            methodBody.AppendLine(string.Format(@"Name = ""{0}"",", p.Name));
                            methodBody.AppendLine(string.Format(@"Table = {0}", clrName));
                            methodBody.AppendLine(@"},");
                        }
                    });

                    methodBody.AppendLine(@"}");
                    methodBody.AppendLine(@"};");

                    spMethod.MethodBody = methodBody.ToString();
                    spMethod.ReturnCode = "SqlExecutor.Execute<T>(sqlRequest);";
                });
            });
        }
    }
}
