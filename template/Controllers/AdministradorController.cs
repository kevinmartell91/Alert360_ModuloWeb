using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using template.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace template.Controllers
{
    public class AdministradorController : ApiController
    {

        /*comentar
        public List<Administrador> GetAdministrador()
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                return dc.Administradors.ToList() as List<Administrador>;
            }
            catch (Exception)
            {
                return null;
            }


        }
        */

        //Solicitado
        public HttpResponseMessage Post(Administrador administrador)
        {
            //http://alert360-001-site1.smarterasp.net/api/administrador   ?IDAdministrador=admin&passAdministrador=admin
            try
            {   
                alert360dbDataContext dc = new alert360dbDataContext();
                var AdministradorExiste = (from u in dc.Administradors
                                           where u.IDAdministrador == administrador.IDAdministrador
                                           select u).SingleOrDefault();

                if (AdministradorExiste != null)
                {

                    if (AdministradorExiste.Contrasena == administrador.Contrasena)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, 1 );
                        //correcto validado
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, 0 );
                        // Pass incorrecto
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK,-1);
                    // no exite usuario
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        /*
       public string GetAdministradores()
       {
           alert360dbDataContext dc = new alert360dbDataContext();
           try
           {
               return JsonConvert.SerializeObject(dc.Administradors, Formatting.Indented,
                           new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
           }
           catch (Exception e)
           {
               return e.ToString();
           }
       }

       public string GetAdministrador(int codAdministrador)
       {


           alert360dbDataContext dc = new alert360dbDataContext();
           var cliente = dc.Administradors.Where(c => c.CodAdministrador == codAdministrador);
           if (cliente == null)
           {
               throw new HttpResponseException(HttpStatusCode.NotFound);
           }
           return JsonConvert.SerializeObject(cliente, Formatting.Indented,
                           new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

       }

       public void DeleteAdministrador(int codAdministrador)
       {

           alert360dbDataContext dc = new alert360dbDataContext();
           Administrador administrador = dc.Administradors.Where(c => c.CodAdministrador == codAdministrador).FirstOrDefault() as Administrador;
           if (administrador == null)
           {
               throw new HttpResponseException(HttpStatusCode.NotFound);
           }
           dc.Administradors.DeleteOnSubmit(administrador);
           dc.SubmitChanges();
       }
        * */
    }
}
