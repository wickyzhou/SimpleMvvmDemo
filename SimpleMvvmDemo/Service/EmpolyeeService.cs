using SimpleMvvmDemo.Common;
using SimpleMvvmDemo.Entity;
using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace SimpleMvvmDemo.Service
{
    public class EmpolyeeService
    {

        public bool Insert(Employee employee)
        {
            string sql = @"insert into Employee(Id,Name,Sex,Age,CreateTime) values(@Id,@Name,@Sex,@Age,@CreateTime)";
            using (var connection = SqlDb.UpdateConnection)
            {
                return connection.Execute(sql, employee) > 0;
            }
        }

        public bool Update(Employee employee)
        {
            string sql = @"update Employee set Name=@Name,Sex=@Sex,Age=@Age,CreateTime=@CreateTime where Id=@Id";
            using (var connection = SqlDb.UpdateConnection)
            {
                return connection.Execute(sql, employee) > 0;
            }
        }

        public bool Delete(Guid id)
        {
            string sql = @"delete from Employee where Id=@Id";
            using (var connection = SqlDb.UpdateConnection)
            {
                return connection.Execute(sql, new { Id = id }) > 0;
            }
        }

        public IList<Employee> GetAll()
        {
            string sql = @"select * from Employee";
            using (var connection = SqlDb.UpdateConnection)
            {
                return connection.Query<Employee>(sql).ToList();
            }
        }

    }
}
