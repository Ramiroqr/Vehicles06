using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles06.API.Data.Entities;
using Vehicles06.API.Models;

namespace Vehicles06.API.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew);

        UserViewModel ToUserViewModel(User user);
    }
}
