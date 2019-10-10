using CodeSmith.Engine;
using SchemaExplorer;
using System;
using System.Windows.Forms.Design;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace Common {
	
	
	public class CommonSqlCode : CodeTemplate {  
         
        /** 
		 * 字段转java规范属性  TEST_AIORIA => testAioria
		 **/
        public string getPropertiesName(string columnName){
			string returnName = ""; 
			string[] strArr = columnName.Split('_');
			string str = "" , firstChar = "" , secondChar = "";
			for(int i = 0 ; i < strArr.Length ; i++){
				str = strArr[i];
				if(i==0){
					str = str.ToLower();
					returnName+=str;
				}else{
					firstChar = str.Substring(0,1).ToUpper();
					secondChar =  str.Substring(1,str.Length-1).ToLower(); 
					returnName+=firstChar + secondChar;
				}
			}
			return returnName ; 
        }

		
		//返回对应的Java类型
		public string getHibernateJavaType(DataObjectBase column){
			switch (column.NativeType.ToLower()){
				case "bigint": return "Long";
				case "bit": return "Boolean";
				case "char": return "String";
				case "longtext": return "String";
				case "datetime": return "java.util.Date";
				case "decimal": return "BigDecimal";
				case "float": return "Double"; 
				case "int": return "Integer";
                case "tinyint": return "Integer";
				case "nchar": return "String";
				case "ntext": return "byte[]";
				case "number": return "Double";
				case "numeric": return "Double"; 
				case "smallint": return "Integer";
				case "text": return "byte[]";
				case "timestamp": return "java.util.Date";
				case "date": return "String";
				case "varchar2": return "String";
				case "varchar": return "String";
				default: return "找不到对应的类型" + column.NativeType;
			}
		}
		
		//返回对应的Java类型
		public string getPropertiesJavaType(DataObjectBase column){
			switch (column.NativeType.ToLower()){
				case "bigint": return "Long";
				case "longtext": return "String";
				case "bit": return "Boolean";
				case "char": return "String";
                case "double": return "Double";
				case "datetime": return "java.util.Date";
				case "decimal": return "java.math.BigDecimal";
				case "float": return "Double"; 
				case "int": return "Integer";
				case "nchar": return "String";
				case "ntext": return "byte[]";
				case "number": return "Double";
                case "tinyint": return "Integer";
				case "numeric": return "Double"; 
				case "smallint": return "Integer";
				case "text": return "String";
				case "timestamp": return "java.util.Date";
				case "varchar2": return "String";
				case "varchar": return "String";
				case "date": return "String";
				default: return "找不到对应的类型" + column.NativeType;
			}
		}
		
		/** 
		 * 字段转属性XXX方法  TEST_AIORIA => XXXTestAioria
		 **/
        public string getPropertiesXXXname(string columnName,string xxx){ 
			string returnName = xxx; 
			string[] strArr = columnName.Split('_');
			string str = "" , firstChar = "" , secondChar = "";
			for(int i = 0 ; i < strArr.Length ; i++){
				str = strArr[i]; 
				firstChar = str.Substring(0,1).ToUpper();
				secondChar =  str.Substring(1,str.Length-1).ToLower(); 
				returnName+=firstChar + secondChar; 
			}
			return returnName ; 
        }
		
		/**
		 ** 返回首字母大写的表名
		 ** ABC_XYZ_T  --> AbcXyzT
		 **/
		public string getTableJavaFirstUpperName(string tableName) {
			string returnName = ""; 
			string[] strArr = tableName.Split('_');
			string str = "" , firstChar = "" , secondChar = "";
			for(int i = 0 ; i < strArr.Length ; i++){
				str = strArr[i]; 
				firstChar = str.Substring(0,1).ToUpper();
				secondChar =  str.Substring(1,str.Length-1).ToLower(); 
				returnName += firstChar + secondChar; 
			}
			return returnName ;  
		}
		
        /**
		 ** 砍尾巴
		 ** 
		 **/
		public string cut(string str) {
			
			return str.Substring(0,str.Length-1) ;  
		}
    
        
		/**
		 ** 返回首字母小写的表名
		 ** ABC_XYZ_T  --> abcXyzT
		 **/
		public string getTableJavaFirstLowerName(string tableName) {
			string returnName = ""; 
			string[] strArr = tableName.Split('_');
			string str = "" , firstChar = "" , secondChar = "";
			for(int i = 0 ; i < strArr.Length ; i++){
				str = strArr[i]; 
				if(i==0){
					str = str.ToLower();
					returnName+=str;
				}else{
					firstChar = str.Substring(0,1).ToUpper();
					secondChar =  str.Substring(1,str.Length-1).ToLower(); 
					returnName+=firstChar + secondChar;
				}
			}
			return returnName ;  
		}
		
		//判断一个字段是否日期类型
		public bool IsDataColumn(DataObjectBase column) {
			String strCol=column.Name;
			int len=strCol.Length;
			if(len<6) return false;
			if(strCol.Substring(len-4).ToLower()=="date") return true;
            if(strCol.Substring(len-4).ToLower()=="time") return true;
			else return false;
		}
		
	}
}