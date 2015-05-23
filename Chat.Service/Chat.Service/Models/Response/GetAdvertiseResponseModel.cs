using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Service.Models.Response
{
    public class GetAdvertiseResponseModel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int Second { get; set; }

    }
}