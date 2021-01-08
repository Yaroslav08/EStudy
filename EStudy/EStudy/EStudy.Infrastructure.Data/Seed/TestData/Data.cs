using EStudy.Domain.Models;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Infrastructure.Data.Seed.TestData
{
    public static class Data
    {
        public static List<User> GetUsers()=> new List<User>
            {
                new User
                {
                    FirstName = "Ярослав",
                    LastName = "Мудрик",
                    Login = "test01@gmail.com",
                    PasswordHash = "HKFVlsrh^foSJF@IDUFh%OISDfgpsdjfsdfioshgs#d",
                    CreatedAt = DateTime.Now,
                    IsConfirmed = true,
                    ConfirmedAt = DateTime.Now,
                    ConfirmedFromIP = "::1",
                    ConfirmCode = Generator.GetCode(80),
                    Born = new DateTime(2000, 3, 8),
                    Username = "User01",
                    Role = Domain.Models.Enums.RoleType.Admin,
                    CreatedFromIP="::1",
                    Email = "test01@gmail.com",
                    Phone = "+380955555555"
                },
                new User
                {
                    FirstName = "Ярослав",
                    LastName = "Мудрик",
                    Login = "test02@gmail.com",
                    PasswordHash = "HKFVlsrh^foSJF@IDUFh%OISDfgpsdjfsdfioshgs#d",
                    CreatedAt = DateTime.Now,
                    IsConfirmed = true,
                    ConfirmedAt = DateTime.Now,
                    ConfirmedFromIP = "::1",
                    ConfirmCode = Generator.GetCode(80),
                    Born = new DateTime(2000, 1, 1),
                    Username = "User02",
                    Role = Domain.Models.Enums.RoleType.Student,
                    CreatedFromIP="::1",
                    Email = "test01@gmail.com",
                    Phone = "+380955555555"
                },
                new User
                {
                    FirstName = "Ярослав",
                    LastName = "Мудрик",
                    Login = "test03@gmail.com",
                    PasswordHash = "HKFVlsrh^foSJF@IDUFh%OISDfgpsdjfsdfioshgs#d",
                    CreatedAt = DateTime.Now,
                    IsConfirmed = true,
                    ConfirmedAt = DateTime.Now,
                    ConfirmedFromIP = "::1",
                    ConfirmCode = Generator.GetCode(80),
                    Born = new DateTime(2000, 1, 1),
                    Username = "User03",
                    Role = Domain.Models.Enums.RoleType.Student,
                    CreatedFromIP="::1",
                    Email = "test01@gmail.com",
                    Phone = "+380955555555"
                },
                new User
                {
                    FirstName = "Ярослав",
                    LastName = "Мудрик",
                    Login = "test04@gmail.com",
                    PasswordHash = "HKFVlsrh^foSJF@IDUFh%OISDfgpsdjfsdfioshgs#d",
                    CreatedAt = DateTime.Now,
                    IsConfirmed = true,
                    ConfirmedAt = DateTime.Now,
                    ConfirmedFromIP = "::1",
                    ConfirmCode = Generator.GetCode(80),
                    Born = new DateTime(2000, 1, 1),
                    Username = "User04",
                    Role = Domain.Models.Enums.RoleType.Teacher,
                    CreatedFromIP="::1",
                    Email = "test01@gmail.com",
                    Phone = "+380955555555"
                },
                new User
                {
                    FirstName = "Ярослав",
                    LastName = "Мудрик",
                    Login = "test05@gmail.com",
                    PasswordHash = "HKFVlsrh^foSJF@IDUFh%OISDfgpsdjfsdfioshgs#d",
                    CreatedAt = DateTime.Now,
                    IsConfirmed = true,
                    ConfirmedAt = DateTime.Now,
                    ConfirmedFromIP = "::1",
                    ConfirmCode = Generator.GetCode(80),
                    Born = new DateTime(2000, 1, 1),
                    Username = "User05",
                    Role = Domain.Models.Enums.RoleType.Teacher,
                    CreatedFromIP="::1",
                    Email = "test01@gmail.com",
                    Phone = "+380955555555"
                },
                new User
                {
                    FirstName = "Ярослав",
                    LastName = "Мудрик",
                    Login = "test06@gmail.com",
                    PasswordHash = "HKFVlsrh^foSJF@IDUFh%OISDfgpsdjfsdfioshgs#d",
                    CreatedAt = DateTime.Now,
                    IsConfirmed = true,
                    ConfirmedAt = DateTime.Now,
                    ConfirmedFromIP = "::1",
                    ConfirmCode = Generator.GetCode(80),
                    Born = new DateTime(2000, 1, 1),
                    Username = "User06",
                    Role = Domain.Models.Enums.RoleType.Admin,
                    CreatedFromIP="::1",
                    Email = "test01@gmail.com",
                    Phone = "+380955555555"
                },
                new User
                {
                    FirstName = "Ярослав",
                    LastName = "Мудрик",
                    Login = "test07@gmail.com",
                    PasswordHash = "HKFVlsrh^foSJF@IDUFh%OISDfgpsdjfsdfioshgs#d",
                    CreatedAt = DateTime.Now,
                    IsConfirmed = true,
                    ConfirmedAt = DateTime.Now,
                    ConfirmedFromIP = "::1",
                    ConfirmCode = Generator.GetCode(80),
                    Born = new DateTime(2000, 1, 1),
                    Username = "User07",
                    Role = Domain.Models.Enums.RoleType.Student,
                    CreatedFromIP="::1",
                    Email = "test01@gmail.com",
                    Phone = "+380955555555"
                },
                new User
                {
                    FirstName = "Ярослав",
                    LastName = "Мудрик",
                    Login = "test08@gmail.com",
                    PasswordHash = "HKFVlsrh^foSJF@IDUFh%OISDfgpsdjfsdfioshgs#d",
                    CreatedAt = DateTime.Now,
                    IsConfirmed = true,
                    ConfirmedAt = DateTime.Now,
                    ConfirmedFromIP = "::1",
                    ConfirmCode = Generator.GetCode(80),
                    Born = new DateTime(2000, 1, 1),
                    Username = "User08",
                    Role = Domain.Models.Enums.RoleType.Student,
                    CreatedFromIP="::1",
                    Email = "test01@gmail.com",
                    Phone = "+380955555555"
                }
            };
        public static University GetUniversity() => new University
        {
            Name = "Державний Університет Телекомунікацій",
            ShortName = "",
            EnglishName = "State University Of Telecommunication",
            CodeEDEBO = 82,
            Accreditation = "3/4 рівень акредитації",
            AddressInfo = "м. Київ, вул. Солом'янська, 7",
            Area = "Технічна підготовка",
            CodeForStudent = Generator.GetString(10),
            CodeForTeacher = Generator.GetString(10),
            Description = "",
            Locality = "м. Київ",
            Logo = "",
            Type = "Університет",
            Region = "Київська область",
            PostalCode = "03110",
            Logo50 = "http://www.dut.edu.ua/img/logo.png",
            Logo150 = "http://www.dut.edu.ua/img/logo_ny.png",
            Departments = new List<Department>
            {
                new Department
                {
                    Name = "Навчально-науковий інститут Інформаційних технологій",
                    Description = "Деякий опис",
                    Phone = "+044 245 235 34",
                    Shifr = "10101",
                    UniversityId = 1,
                    Specialties = new List<Specialty>
                    {
                        new Specialty
                        {
                            Name = "Інженерія програмного забезпечення",
                            Qualification = Domain.Models.Enums.TypeDiploma.BachelorsDegree,
                            DepartmentId = 1,
                            Groups = new List<Group>
                            {
                                new Group
                                {
                                    Name = "ПД-24",
                                    Course = 2,
                                    StartStudy = new DateTime(2019, 9, 1),
                                    EndStudy = new DateTime(2023, 6, 30),
                                    SpecialtyId = 1
                                },
                                new Group
                                {
                                    Name = "ПД-34",
                                    Course = 3,
                                    StartStudy = new DateTime(2018, 9, 1),
                                    EndStudy = new DateTime(2022, 6, 30),
                                    SpecialtyId = 1
                                }
                            }
                        },
                    }
                },
                new Department
                {
                    Name = "Навчально-науковий інститут Телекомунікацій",
                    Description = "Деякий опис",
                    Phone = "+044 245 235 36",
                    Shifr = "10103",
                    UniversityId = 1,
                    Specialties = new List<Specialty>
                    {
                        new Specialty
                        {
                            Name = "Управління телекомунікаціями",
                            Qualification = Domain.Models.Enums.TypeDiploma.BachelorsDegree,
                            DepartmentId = 2,
                            Groups = new List<Group>
                            {
                                new Group
                                {
                                    Name = "УБД-24",
                                    Course = 2,
                                    StartStudy = new DateTime(2019, 9, 1),
                                    EndStudy = new DateTime(2023, 6, 30),
                                    SpecialtyId = 2
                                },
                                new Group
                                {
                                    Name = "УБД-34",
                                    Course = 3,
                                    StartStudy = new DateTime(2018, 9, 1),
                                    EndStudy = new DateTime(2022, 6, 30),
                                    SpecialtyId = 2
                                }
                            }
                        },
                    }
                }
            }
        };
    }
}