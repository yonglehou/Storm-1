<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:s="urn:storm-db">
  <xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes" />
  <xsl:template match="/">
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Flyingpie.Storm;
    using Flyingpie.Storm.Executors;

    namespace Database
    {
    <!-- User defined types -->
    #region User Defined Types

    namespace UserDefinedTypes
    {
    <xsl:for-each select="DatabaseModel/Schemas/SchemaInfo">
      namespace <xsl:value-of select="Name" />
      {
      <xsl:for-each select="UserDefinedTypes/UserDefinedTypeInfo">
        public class <xsl:value-of select="NameClr" />
        {
        <xsl:for-each select="Columns/UserDefinedTypeColumnInfo">
          <xsl:sort select="Id" />
          public <xsl:value-of select="TypeClr" /><xsl:text> </xsl:text><xsl:value-of select="NameClr" /> { get; set; }
        </xsl:for-each>
        }
      </xsl:for-each>
      }
    </xsl:for-each>
    }

    #endregion

    <!-- Interfaces -->
    #region Interfaces
    <xsl:for-each select="DatabaseModel/Schemas/SchemaInfo">
      public interface I<xsl:value-of select="Name" />
      {
      <xsl:for-each select="StoredProcedures/StoredProcedureInfo">
        T <xsl:value-of select="Name" /><xsl:text disable-output-escaping="yes">&lt;T&gt;</xsl:text>(<xsl:value-of disable-output-escaping="yes" select="ParameterString" />) where T : SqlResponse;
      </xsl:for-each>
      }
    </xsl:for-each>
    #endregion

    #region Classes
    <!-- Classes -->
    <xsl:for-each select="DatabaseModel/Schemas/SchemaInfo">
      public class <xsl:value-of select="Name" />
      {
      private ISqlExecutor _executor;

      public <xsl:value-of select="Name" />(ISqlExecutor executor)
      {
      _executor = executor;
      }

      <xsl:for-each select="StoredProcedures/StoredProcedureInfo">
        public T <xsl:value-of select="Name" /><xsl:text disable-output-escaping="yes">&lt;T&gt;</xsl:text>(<xsl:value-of disable-output-escaping="yes" select="ParameterString" />) where T : SqlResponse
        {
        var request = new SqlRequest("<xsl:value-of select="SchemaName" />", "<xsl:value-of select="Name" />");
        <xsl:for-each select="Parameters/ParameterInfo">
          <xsl:choose>
            <xsl:when test="HasUserDefinedType = 'true'">
              request.Parameters.Add(new StoredProcedureTableTypeParameter("<xsl:value-of select="Name" />", ParameterDirection.<xsl:value-of select="ParameterModeEnum" />, "<xsl:value-of select="UserDefinedTypeSchema" />", "<xsl:value-of select="UserDefinedTypeName" />", <xsl:value-of select="NameClr" />));
            </xsl:when>
            <xsl:when test="HasUserDefinedType = 'false'">
              request.Parameters.Add(new StoredProcedureSimpleParameter("<xsl:value-of select="Name" />", ParameterDirection.<xsl:value-of select="ParameterModeEnum" />, <xsl:value-of select="NameClr" />));
            </xsl:when>
          </xsl:choose>
        </xsl:for-each>

        var result = _executor.Execute<xsl:text disable-output-escaping="yes">&lt;T&gt;</xsl:text>(request);

        <xsl:for-each select="Parameters/ParameterInfo">
          <xsl:choose>
            <xsl:when test="HasUserDefinedType = 'false'">
              <xsl:if test="Mode = 'INOUT' or Mode = 'OUT'">
                <xsl:value-of select="NameClr" /><xsl:text> = </xsl:text>(<xsl:value-of select="TypeClr" />)request.GetParameterValue("<xsl:value-of select="Name" />");
              </xsl:if>
            </xsl:when>
          </xsl:choose>
        </xsl:for-each>

        return result;
        }
      </xsl:for-each>
      }
    </xsl:for-each>
    #endregion
    }
  </xsl:template>
</xsl:stylesheet>