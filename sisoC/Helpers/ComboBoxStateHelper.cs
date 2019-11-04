namespace sisoC.Helpers
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

        public void Dispose()
        {
            db.Dispose();
        }
    }
}