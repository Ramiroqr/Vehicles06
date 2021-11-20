using System;
using System.Threading.Tasks;
using Vehicles06.API.Data;
using Vehicles06.API.Data.Entities;
using Vehicles06.API.Models;


namespace Vehicles06.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<User> ToUserAsync(UserViewModel user, Guid imageId, bool isNew)
        {
            return new User
            {
                Address = user.Address,
                Document = user.Document,
                DocumentType = await _context.DocumentTypes.FindAsync(user.DocumentTypeId),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = isNew ? Guid.NewGuid().ToString() : user.Id,
                ImageId = imageId,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.Email,
                UserType = user.UserType,
            };
        }

        public UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Address = user.Address,
                Document = user.Document,
                DocumentTypeId = user.DocumentType.Id,
                DocumentTypes = _combosHelper.GetComboDocumentTypes(),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                //ImageId = user.imageId,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
            };
        }

    }
}
