using BaseProject.Application.System.Users;
using BaseProject.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;


        public NotificationService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }


    }
}
