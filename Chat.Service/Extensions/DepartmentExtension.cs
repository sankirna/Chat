using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Service.Models.Response;
using Chat.Service.Entity;
using AutoMapper;

namespace Chat.Service.Extensions
{
    public static class DepartmentExtension
    {
        public static DepartmentResponseModel ToModel(this Department_Master entity)
        {
            DepartmentResponseModel model = Mapper.Map<Department_Master, DepartmentResponseModel>(entity);
            model.Department = entity.Department;
            model.DeptID = entity.DeptId;
            return model;

        }

    }
}