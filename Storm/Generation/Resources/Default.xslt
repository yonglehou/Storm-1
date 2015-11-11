<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:s="urn:storm-db">
  <xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes" />
  <xsl:template match="/">
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Flyingpie.Storm;
    using Flyingpie.Storm.Execution;
    using Flyingpie.Storm.Execution.Parameters;

    namespace Database
    {
    <!-- User defined types -->
    #region User Defined Types

    namespace UserDefinedTypes
    {
    <xsl:for-each select="DatabaseModel/Schemas/SchemaInfo">
      namespace <xsl:value-of select="NamespaceName" />
      {
      <xsl:for-each select="UserDefinedTypes/UserDefinedTypeInfo">
        [GeneratedCode("<xsl:value-of select="/DatabaseModel/LibraryName" />", "<xsl:value-of select="/DatabaseModel/LibraryVersion" />")]
        public partial class <xsl:value-of select="NameClr" />
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
      [GeneratedCode("<xsl:value-of select="/DatabaseModel/LibraryName" />", "<xsl:value-of select="/DatabaseModel/LibraryVersion" />")]
      public interface <xsl:value-of select="InterfaceName" />
      {
      <xsl:for-each select="StoredProcedures/StoredProcedureInfo">
        ISqlRequest <xsl:value-of select="NameClr" />(<xsl:value-of disable-output-escaping="yes" select="ParameterString" />);
      </xsl:for-each>
      }
    </xsl:for-each>
    #endregion

    #region Classes
    <!-- Classes -->
    <xsl:for-each select="DatabaseModel/Schemas/SchemaInfo">
      [GeneratedCode("<xsl:value-of select="/DatabaseModel/LibraryName" />", "<xsl:value-of select="/DatabaseModel/LibraryVersion" />")]
      public partial class <xsl:value-of select="ClassName" /> : <xsl:value-of select="InterfaceName" />
      {
      private IQueryChain _queryChain;

      public <xsl:value-of select="ClassName" />(IQueryChain queryChain)
      {
      _queryChain = queryChain;
      }

      <xsl:for-each select="StoredProcedures/StoredProcedureInfo">
        public virtual ISqlRequest <xsl:value-of select="NameClr" />(<xsl:value-of disable-output-escaping="yes" select="ParameterString" />)
        {
        var request = new SqlRequest(_queryChain, "<xsl:value-of select="SchemaName" />", "<xsl:value-of select="Name" />");
        <xsl:for-each select="Parameters/ParameterInfo">
          <xsl:choose>
            <xsl:when test="HasUserDefinedType = 'true'">
              request.Parameters.Add(new StoredProcedureTableTypeParameter("<xsl:value-of select="Name" />", "<xsl:value-of select="Type" />", ParameterDirection.<xsl:value-of select="ParameterModeEnum" />, "<xsl:value-of select="UserDefinedTypeSchema" />", "<xsl:value-of select="UserDefinedTypeName" />", <xsl:value-of select="NameClr" />));
            </xsl:when>
            <xsl:when test="HasUserDefinedType = 'false'">
              request.Parameters.Add(new StoredProcedureSimpleParameter("<xsl:value-of select="Name" />", "<xsl:value-of select="Type" />", ParameterDirection.<xsl:value-of select="ParameterModeEnum" />, <xsl:value-of select="NameClr" />));
            </xsl:when>
          </xsl:choose>
        </xsl:for-each>
        return request;
        }
      </xsl:for-each>
      }
    </xsl:for-each>
    #endregion
    }
  </xsl:template>
</xsl:stylesheet>