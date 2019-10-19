using System.Collections.Generic;
using HelloWorldASPCore.Common.ViewModels;
using HelloWorldASPCore.Common.Models;

namespace HelloWorldASPCore.Common.Services
{
    public class ListFunctions
    {
        public static List<UserViewModel> ListUserMToListUserMV(List<UserModel> userModelList)
        {
            List<UserViewModel> listUserViewModel = new List<UserViewModel>(); //список VM который будет заполняться
            foreach (var userModel in userModelList)
            {
                var userViewModel = new UserViewModel(userModel);
                listUserViewModel.Add(userViewModel);
            }
            return listUserViewModel;
        }

        public static List<GroupViewModel> ListGroupMToListGroupMV(List<GroupModel> groupModelList)
        {
            List<GroupViewModel> listGroupViewModel = new List<GroupViewModel>(); //список VM который будет заполняться
            foreach (var groupModel in groupModelList)
            {
                var groupViewModel = new GroupViewModel(groupModel);
                listGroupViewModel.Add(groupViewModel);
            }
            return listGroupViewModel;
        }
    }
}
