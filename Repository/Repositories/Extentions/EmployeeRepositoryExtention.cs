﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Extentions
{
    public static class EmployeeRepositoryExtention
    {
        public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee> employees, int minAge, int maxAge)
        {
            return employees.Where(e => e.Age >= minAge && e.Age <= maxAge);
        }

        public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm) || string.IsNullOrWhiteSpace(searchTerm))
            {
                return employees;
            }

            var handledSearchTirm = searchTerm.ToLower().Trim();    
            return employees.Where(e=> e.Name.ToLower().Contains(handledSearchTirm));
        }
    }
}
