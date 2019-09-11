using System.Collections.Generic;

namespace HelloWorldASPCore.Common.Models
{
    public class DataBaseMemory
    { 
        public List<UserModel> UserModelList;
        public List<GroupModel> GroupModelList;

        public DataBaseMemory()
        {
            UserModelList = new List<UserModel>();
            GroupModelList = new List<GroupModel>();
        }
    }
}
