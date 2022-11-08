using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace QueryBuilder
{
    
    public class QueryBuilder : IDisposable
    {
        private SqliteConnection connection;
        

        public QueryBuilder(string database)
        {
            connection = new SqliteConnection("Data Source=" + database);
            connection.Open();
        }

        public T Read<T>(int Id) where T : IClassModel, new()
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {typeof(T).Name} WHERE Id= ({Id})";
            var reader = command.ExecuteReader();
            T result= new T();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (typeof(T).GetProperty(reader.GetName(i)).PropertyType == typeof(int))
                        typeof(T).GetProperty(reader.GetName(i)).SetValue(result, Convert.ToInt32(reader.GetValue(i)));
                    else
                        typeof(T).GetProperty(reader.GetName(i)).SetValue(result, reader.GetValue(i));
                }
            }
            return result;
        }

        public List<T> ReadAll<T>() where T : IClassModel, new()
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {typeof(T).Name}";
            var reader = command.ExecuteReader();
            T data;
            var datas = new List<T>();
            while (reader.Read())
            {
                data = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (typeof(T).GetProperty(reader.GetName(i)).PropertyType == typeof(int))
                        typeof(T).GetProperty(reader.GetName(i)).SetValue(data, Convert.ToInt32(reader.GetValue(i)));
                    else
                        typeof(T).GetProperty(reader.GetName(i)).SetValue(data, reader.GetValue(i));
                }
                datas.Add(data);
            }
            return datas;
        }
        
        public void Create<T>(T obj)
        {
            PropertyInfo[] data = typeof(T).GetProperties();

            List<string> names = new List<string>();
            List<string> values = new List<string>();

            foreach (PropertyInfo property in data)
            {
                if (property.PropertyType == typeof (string))
                {
                    values.Add("\"" + property.GetValue(obj) + "\"");
                }
                else
                {
                    values.Add(property.GetValue(obj).ToString());
                }
                names.Add(property.Name);

            }

            StringBuilder sbnames = new StringBuilder();
            StringBuilder sbvalues = new StringBuilder();

            for (int i = 0; i < values.Count; i++)
            {
                if (i == values.Count - 1)
                {
                    sbvalues.Append($"{values[i]}");
                    sbnames.Append($"{names[i]}");
                }
                else
                {
                    sbvalues.Append($"{values[i]},");
                    sbnames.Append($"{names[i]},");
                }
            }

            var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO {typeof(T).Name} ({sbnames}) VALUES ({sbvalues})";
            int insert = command.ExecuteNonQuery();

        }
        
        public void Update<T>(T obj) where T : IClassModel 
        {
            PropertyInfo[] data = typeof(T).GetProperties();

            List<string> names = new List<string>();
            List<string> values = new List<string>();

            foreach (PropertyInfo property in data)
            {
                if (property.PropertyType == typeof (string))
                {
                    values.Add("\"" + property.GetValue(obj) + "\"");
                }
                else
                {
                    values.Add(property.GetValue(obj).ToString());
                }
                names.Add(property.Name);

               
            }
            
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < values.Count; i++)
            {
                if (i == values.Count - 1)
                {
                    sb.Append($"{names[i]}='{values[i]}' ");

                }
                else
                {
                    sb.Append($"{names[i]}='{values[i]}' ,");
                }
            }

            var command = connection.CreateCommand();
            command.CommandText = $"UPDATE {typeof(T).Name} SET {sb} WHERE Id= {obj.Id}";
            var update = command.ExecuteNonQuery();
        }

        public void Delete<T>(T obj) where T : IClassModel
        {
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {typeof(T).Name} WHERE Id= {obj.Id}";
            var update = command.ExecuteNonQuery();
        }
        
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
