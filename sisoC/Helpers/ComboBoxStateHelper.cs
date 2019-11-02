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

        public void Dispose()
        {
            db.Dispose();
        }
    }
}