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
    public class AlertasController : ApiController
    {
        public List<AlertaBean> GetAlertas()
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();

                var alertas = dc.Alertas.ToList();

                List<AlertaBean> listToSend = new List<AlertaBean>();
                AlertaBean ab;

                foreach (Alerta a in (alertas as List<Alerta>)  )
                {
                    ab = new AlertaBean();
                    ab.CodAlerta = a.CodAlerta.ToString();
                    ab.CodUsuario = a.CodUsuario.ToString();
                    ab.Latitud = a.Latitud.ToString();
                    ab.Longitud = a.Longitud.ToString();
                    ab.Fecha = a.Fecha.ToString();
                    ab.HusoHorario = a.HusoHorario.ToString();
                    ab.Tipo = a.Tipo.ToString();
                    listToSend.Add(ab);
                    
                }
                return listToSend;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DatEstTipoAlerta GetDatosEstadisticosTipo(string tipo)
        {
            int param1 = 0; // 0 boton              | AM
            int param2 = 0; // 1 acelerometro       | PM

            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();

                var alertas = dc.Alertas.ToList();
                foreach (var alerta in alertas)
                {
                    if (alerta.Tipo == 0) param1++;
                    else param2++;
                }
                DatEstTipoAlerta dt = new DatEstTipoAlerta();
                dt.Titulo = "TipoAlerta";
                dt.Boton = param1;
                dt.Acelerometro = param2;
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DatEstTipoAlertaFecha GetDatosEstadisticosFecha(string fecha)
        {
            int param1 = 0; // 0 boton              | AM
            int param2 = 0; // 1 acelerometro       | PM

            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();

                var alertas = dc.Alertas.ToList();
                foreach (var alerta in alertas)
                {
                        if (alerta.Fecha.Contains("AM")) param1++;
                        else param2++;
                }
               
                    DatEstTipoAlertaFecha dtf = new DatEstTipoAlertaFecha();
                    dtf.Titulo = "TipoFecha";
                    dtf.Dia = param1;
                    dtf.Noche = param2;
                    return dtf;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Solicitado
        public List<AlertaBean> GetAlertasUsuario(int codUsuario)
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                var usuario = (from u in dc.Usuarios
                               where u.CodUsuario == codUsuario
                               select u).SingleOrDefault();
                List<AlertaBean> listToSend = new List<AlertaBean>();
                AlertaBean ab;

                foreach (Alerta a in (usuario as Usuario).Alertas)
                {
                    ab = new AlertaBean ();
                    ab.CodAlerta   = a.CodAlerta.ToString();   
                    ab.CodUsuario  = a.CodUsuario .ToString();
                    ab.Latitud     = a.Latitud    .ToString();
                    ab.Longitud    = a.Longitud    .ToString();
                    ab.Fecha       = a.Fecha       .ToString();
                    ab.HusoHorario = a.HusoHorario .ToString();
                    ab.Tipo = a.Tipo.ToString();
                    listToSend.Add(ab);
                }
                return listToSend;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AlertaBean GetAlerta(int codAlerta)
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                var alerta = (from u in dc.Alertas
                              where u.CodAlerta == codAlerta
                              select u).SingleOrDefault();
                if (alerta != null)
                {
                    AlertaBean ab = new AlertaBean();
                    ab.CodAlerta = alerta.CodAlerta.ToString();
                    ab.CodUsuario = alerta.CodUsuario.ToString();
                    ab.Latitud = alerta.Latitud.ToString();
                    ab.Longitud = alerta.Longitud.ToString();
                    ab.Fecha = alerta.Fecha.ToString();
                    ab.HusoHorario = alerta.HusoHorario.ToString();
                    ab.Tipo = alerta.Tipo.ToString();

                    return ab;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //Soliciado y regresa el Codigo de la alerta GENERADA pero no se muestra en la barra de herramientass
        public HttpResponseMessage PostAlerta(Alerta alerta)
        {
           
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                /*
                Alerta 
                if (alerta.Tipo == 0)
                {
 
                }
                */
                dc.Alertas.InsertOnSubmit(alerta as Alerta);
                dc.SubmitChanges();
                return Request.CreateResponse(HttpStatusCode.Created, alerta.CodAlerta);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //Put Alerta no re requiere por motivos de intergrdad de datos

        /*por evaluar si se necesita este servicio
        public HttpResponseMessage DeleteAlerta(int codAlerta)
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                var alerta = (from a in dc.Alertas
                              where a.CodAlerta == codAlerta
                              select a).SingleOrDefault();
                if (alerta != null)
                {
                    dc.Alertas.DeleteOnSubmit(alerta as Alerta);
                    dc.SubmitChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, alerta.CodAlerta);

                }
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        */
    }
}
