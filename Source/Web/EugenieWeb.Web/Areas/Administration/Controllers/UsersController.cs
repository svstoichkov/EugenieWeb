﻿namespace EugenieWeb.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Common;

    using Data.Models;

    using Eugenie.Data;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : Controller
    {
        private readonly IRepository<User> usersRepository;

        public UsersController(IRepository<User> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.usersRepository.All().ToDataSourceResult(request, user => new {
                Id = user.Id,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEndDateUtc = user.LockoutEndDateUtc,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount,
                UserName = user.UserName
            });

            return this.Json(result);
        }

        protected override void Dispose(bool disposing)
        {
            this.usersRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
