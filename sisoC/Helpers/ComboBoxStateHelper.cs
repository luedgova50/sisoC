﻿namespace sisoC.Helpers
{
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using sisoC.Models;

    public class ComboBoxStateHelper : IDisposable
    {
        private static SisoCdataContext db = new SisoCdataContext();

        public static List<State> GetStates()
        {
            var states = db.States.ToList();

            states.Add(new State
            {
                StateID = 0,
                Name = "[Seleccionar un Departamento...]",
            });

            return states.OrderBy(d => d.Name).ToList();
        }

        public static List<City> GetCities(int stateID)
        {
            var cities = db.Cities.
                Where(c => c.StateID == stateID).ToList();

            cities.Add(new City
            {
                StateID = 0,
                Name = "[Seleccionar una Ciudad...]",
            });

            return cities.OrderBy(d => d.Name).ToList();
        }

        public static List<DocumentType> GetDocumentTypes()
        {
            var documents = db.DocumentTypes.ToList();

            documents.Add(new DocumentType
            {
                DocumentTypeID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return documents.OrderBy(d => d.Description).ToList();
        }

        public static List<Gender> GetGenders()
        {
            var genders = db.Genders.ToList();

            genders.Add(new Gender
            {
                GenderID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return genders.OrderBy(d => d.Description).ToList();
        }

        public static List<Civil> GetCivils()
        {
            var civils = db.Civils.ToList();

            civils.Add(new Civil
            {
                CivilID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return civils.OrderBy(d => d.Description).ToList();
        }

        public static List<FactorRh> GetFactors()
        {
            var factors = db.FactorRhs.ToList();

            factors.Add(new FactorRh
            {
                FactorRhID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return factors.OrderBy(d => d.Description).ToList();
        }

        public static List<SchoolLevel> GetLevels()
        {
            var levels = db.SchoolLevels.ToList();

            levels.Add(new SchoolLevel
            {
                SchoolLevelID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return levels.OrderBy(d => d.Description).ToList();
        }

        public static List<Profession> GetProfessions()
        {
            var professions = db.Professions.ToList();

            professions.Add(new Profession
            {
                ProfessionID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return professions.OrderBy(d => d.Description).ToList();
        }

        public static List<MilitaryService> GetMilitaries()
        {
            var militaries = db.MilitaryServices.ToList();

            militaries.Add(new MilitaryService
            {
                MilitaryServiceID = 0,
                Options = "[Seleccionar una Opción...]",
            });

            return militaries.OrderBy(d => d.Options).ToList();
        }

        public static List<DriveLicense> GetLicenses()
        {
            var licenses = db.DriveLicenses.ToList();

            licenses.Add(new DriveLicense
            {
                DriveLicenseID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return licenses.OrderBy(d => d.Description).ToList();
        }

        public static List<Epsa> GetEpsas()
        {
            var epsas = db.Epsas.ToList();

            epsas.Add(new Epsa
            {
                EpsaID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return epsas.OrderBy(d => d.Description).ToList();
        }

        public static List<Arpr> GetArps()
        {
            var arps = db.Arprs.ToList();

            arps.Add(new Arpr
            {
                ArprID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return arps.OrderBy(d => d.Description).ToList();
        }

        public static List<Afpe> GetAfpes()
        {
            var afps = db.Afpes.ToList();

            afps.Add(new Afpe
            {
                AfpeID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return afps.OrderBy(d => d.Description).ToList();
        }

        public static List<UserRoles> GetRoles()
        {
            var roles = db.UserRoles.ToList();

            roles.Add(new UserRoles
            {
                UserRolesID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return roles.OrderBy(d => d.Description).ToList();
        }

        public static List<Users> GetUsers()
        {
            var users = db.Users.ToList();

            users.Add(new Users
            {
                UsersID = 0,
                LastName = "[Seleccionar una Opción...]",
            });

            return users.OrderBy(d => d.LastName).ToList();
        }

        public static List<University> GetUniversities()
        {
            var university = db.Universities.ToList();

            university.Add(new University
            {
                UniversityID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return university.OrderBy(d => d.Description).ToList();
        }

        public static List<Pacient> GetPacients()
        {
            var pacient = db.Pacients.ToList();

            pacient.Add(new Pacient
            {
                PacientID = 0,
                Document = "[Seleccionar una Opción...]",
            });

            return pacient.OrderBy(d => d.Document).ToList();
        }

        public static List<Enterprise> GetEnterprises()
        {
            var enterprise = db.Enterprises.ToList();

            enterprise.Add(new Enterprise
            {
                EnterpriseID = 0,
                Document = "[Seleccionar una Opción...]",
            });

            return enterprise.OrderBy(d => d.Document).ToList();
        }

        public static List<ExActivo> GetActivoes()
        {
            var activos = db.ExActivoes.ToList();

            activos.Add(new ExActivo
            {
                ExActivoID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return activos.OrderBy(d => d.Description).ToList();
        }

        public static List<ExamenLevel> GetELevels()
        {
            var elevels = db.ExamenLevels.ToList();

            elevels.Add(new ExamenLevel
            {
                ExamenLevelID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return elevels.OrderBy(d => d.Description).ToList();
        }

        public static List<ExamenType> GetETypes()
        {
            var etypes = db.ExamenTypes.ToList();

            etypes.Add(new ExamenType
            {
                ExamenTypeID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return etypes.OrderBy(d => d.Description).ToList();
        }

        public static List<ExFono> GetEFonos()
        {
            var efonos = db.ExFonoes.ToList();

            efonos.Add(new ExFono
            {
                ExFonoID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return efonos.OrderBy(d => d.Description).ToList();
        }

        public static List<ExMedico> GetEMedicos()
        {
            var emedicos = db.ExMedicoes.ToList();

            emedicos.Add(new ExMedico
            {
                ExMedicoID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return emedicos.OrderBy(d => d.Description).ToList();
        }

        public static List<ExOpto> GetEOptos()
        {
            var eoptos = db.ExOptoes.ToList();

            eoptos.Add(new ExOpto
            {
                ExOptoID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return eoptos.OrderBy(d => d.Description).ToList();
        }

        public static List<ExPsico> GetEPsicos()
        {
            var epsicos = db.ExPsicoes.ToList();

            epsicos.Add(new ExPsico
            {
                ExPsicoID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return epsicos.OrderBy(d => d.Description).ToList();
        }

        public static List<OtherExam> GetOthers()
        {
            var others = db.OtherExams.ToList();

            others.Add(new OtherExam
            {
                OtherExamID = 0,
                Description = "[Seleccionar una Opción...]",
            });

            return others.OrderBy(d => d.Description).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}