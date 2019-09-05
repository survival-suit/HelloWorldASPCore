using System;
using System.Collections.Generic;
using System.Text;
using HelloWorldASPCore.Common.Models;


namespace HelloWorldASPCore.Common.Models
{
    public class DataBaseMemory
    { 
        public List<UserModel> UserModelList;

        public DataBaseMemory(){ UserModelList = new List<UserModel>(); }
    }
}
