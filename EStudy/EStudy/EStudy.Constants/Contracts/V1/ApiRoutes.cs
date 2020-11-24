using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Constants.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Identity
        {
            public const string Login = "/identity/login";

            public const string Register = "/identity/register";
        }

        public static class User
        {
            public const string Create = Base + "/users";

            public const string Update = Base + "/users/{id}";

            public const string Delete = Base + "/users/{id}";

            public const string Get = Base + "/users/{id}";

            public const string GetAll = Base + "/users";

            public const string GetByName = Base + "/users/{name}";
        }

        public static class University
        {
            public const string Create = Base + "/universities";

            public const string Update = Base + "/universities/{id}";

            public const string Delete = Base + "/universities/{id}";

            public const string Get = Base + "/universities";
        }

        public static class Department
        {
            public const string Create = Base + "/departments";

            public const string Update = Base + "/departments/{id}";

            public const string Delete = Base + "/departments/{id}";

            public const string GetAll = Base + "/departments";

            public const string Get = Base + "/departments/{id}";
        }

        public static class Specialty
        {
            public const string Create = Base + "/specialties";

            public const string Update = Base + "/specialties/{id}";

            public const string Delete = Base + "/specialties/{id}";

            public const string GetAll = Base + "/specialties";

            public const string Get = Base + "/specialties/{id}";
        }

        public static class Group
        {
            public const string Create = Base + "/groups";

            public const string Update = Base + "/groups/{id}";

            public const string Delete = Base + "/groups/{id}";

            public const string GetAll = Base + "/groups";

            public const string Get = Base + "/groups/{id}";

            public const string CreateEmail = Base + "/groups/emails";

            public const string GetEmails = Base + "/groups/{id}/emails";

            public const string UpdateEmail = Base + "/groups/{id}/emails";

            public const string DeleteEmail = Base + "/groups/{id}/emails/{emailId}";
        }
    }
}