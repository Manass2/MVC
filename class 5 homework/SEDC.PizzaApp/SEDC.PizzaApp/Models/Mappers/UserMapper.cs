﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class UserMapper
    {
        public static UserDDViewModel ToUserDDViewModel(User user)
        {
            return new UserDDViewModel
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            };
        }

        public static UserViewModel ToUserViewModel(User user)
        {

            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address
            };
        }

        public static User ToUser(UserViewModel userViewModel)
        {

            return new User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Address = userViewModel.Address
            };
        }
    }
}
