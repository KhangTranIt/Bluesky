using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bluesky.Web.Models.Install;
using FluentValidation;

namespace Bluesky.Web.Validators.Install
{
    public class InstallValidator : AbstractValidator<InstallModel>
    {
        public InstallValidator()
        {
            RuleFor(x => x.AdminEmail).NotEmpty().WithMessage("Admin email required.");
            RuleFor(x => x.AdminEmail).EmailAddress();
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Admin password required.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm password required.");
            RuleFor(x => x.AdminPassword).Equal(x => x.ConfirmPassword).WithMessage("Passwords do not match.");
            RuleFor(x => x.SqlServerName).NotEmpty().WithMessage("Sql server name required.");
            RuleFor(x => x.SqlDatabaseName).NotEmpty().WithMessage("Database name required.");
            RuleFor(x => x.SqlServerUsername).NotEmpty().WithMessage("Sql server username required.");
            RuleFor(x => x.SqlServerPassword).NotEmpty().WithMessage("Sql server password required.");
        }
    }
}