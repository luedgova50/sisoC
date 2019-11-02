namespace sisoC.Helpers
{
    
    using System;
    using sisoC.Models;

    public class DBHelper
    {
        public static Response SaveChanges(SisoCdataContext db)
        {
            try
            {
                db.SaveChanges();

                return new Response { Succeeded = true, };
            }
            catch (Exception ex)
            {
                var response = new Response { Succeeded = false, };
                if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("_Index"))
                {
                    response.Message = "Ya Existe un Registro con el Mismo Valor";
                }
                else if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = 
                        "El Registro Seleccionado no Se Puede Eliminar, Porque Ya Posee Registros Relacionados";
                }
                else
                {
                    response.Message = ex.Message;
                }

                return response;
            }
        }

    }
}