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
    public class ReceptoresController : ApiController
    {
        public List<ReceptorBean> GetReceprores()
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                List<Receptor> listOrigin = dc.Receptors.ToList() as List<Receptor>;
                List<ReceptorBean> listSend = new List<ReceptorBean>();
                ReceptorBean receptorBean;
                foreach (Receptor r in listOrigin)
                {
                    receptorBean = new ReceptorBean();
                    receptorBean.CodReceptor = r.CodReceptor.ToString();
                    receptorBean.CodUsuario = r.CodUsuario.ToString();
                    receptorBean.Nombre = r.Nombre.ToString();
                    receptorBean.CorreoElectronico = r.CorreoElectronico.ToString();
                    receptorBean.TelefonoUno = r.TelefonoUno.ToString();
                    receptorBean.TelefonoDos = r.TelefonoDos.ToString();
                    receptorBean.TelefonoTres = r.TelefonoTres.ToString();
                    listSend.Add(receptorBean);
                }
                return listSend;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ReceptorBean GetReceptor(int codReceptor)
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                var receptor = (from r in dc.Receptors
                                where r.CodReceptor == codReceptor
                                select r).SingleOrDefault();
                ReceptorBean receptorBean = new ReceptorBean(); ;
                if (receptor != null)
                {
                    receptorBean.CodReceptor = receptor.CodReceptor.ToString();
                    receptorBean.CodUsuario = receptor.CodUsuario.ToString();
                    receptorBean.Nombre = receptor.Nombre.ToString();
                    receptorBean.CorreoElectronico = receptor.CorreoElectronico.ToString();
                    receptorBean.TelefonoUno = receptor.TelefonoUno.ToString();
                    receptorBean.TelefonoDos = receptor.TelefonoDos.ToString();
                    receptorBean.TelefonoTres = receptor.TelefonoTres.ToString();
                }
                return receptorBean;
            }
            catch (Exception)
            {
                return null;
            }


        }

        public List<ReceptorBean> GetReceptores(int codUsuario)
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                var receptoresToSend = dc.Receptors.ToList().Where(r => r.CodUsuario == codUsuario);

                List<ReceptorBean> listReceptores = new List<ReceptorBean>();
                ReceptorBean receptorBean;
                foreach (var receptor in receptoresToSend)
                {
                    receptorBean = new ReceptorBean(); 

                    receptorBean.CodReceptor = receptor.CodReceptor.ToString();
                    receptorBean.CodUsuario = receptor.CodUsuario.ToString();
                    receptorBean.Nombre = receptor.Nombre.ToString();
                    receptorBean.CorreoElectronico = receptor.CorreoElectronico.ToString();
                    receptorBean.TelefonoUno = receptor.TelefonoUno.ToString();
                    receptorBean.TelefonoDos = receptor.TelefonoDos.ToString();
                    receptorBean.TelefonoTres = receptor.TelefonoTres.ToString();
                    listReceptores.Add(receptorBean);
                }
                return listReceptores;
            }
            catch (Exception)
            {
                return null;
            }


        }

        //Soicitado
        public HttpResponseMessage PostReceptor(Receptor receptor)
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();

                var nuevoReceptor = (from r in dc.Receptors
                                      where r.Nombre.Equals(receptor.Nombre)
                                      select r).SingleOrDefault();
                if (nuevoReceptor == null)
                {
                    dc.Receptors.InsertOnSubmit(receptor as Receptor);
                    dc.SubmitChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, receptor.CodReceptor);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, -1);
                } 
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage PutReceptor([FromBody] Receptor receptor)
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                var user = (from u in dc.Usuarios
                            where u.CodUsuario == receptor.CodUsuario
                                    select u).SingleOrDefault();
                
                if (user != null)
                {
                    var receptorToUpdate = (from r in user.Receptors
                                          where r.Nombre == receptor.Nombre
                                          select r).SingleOrDefault();
                    if (receptorToUpdate != null)
                    {//datos actualizados con exito

                        //receptorToUpdate.Nombre = receptor.Nombre.ToString();
                        receptorToUpdate.CorreoElectronico = receptor.CorreoElectronico.ToString();
                        receptorToUpdate.TelefonoUno = receptor.TelefonoUno.ToString();
                        receptorToUpdate.TelefonoDos = receptor.TelefonoDos.ToString();
                        receptorToUpdate.TelefonoTres = receptor.TelefonoTres.ToString();

                        dc.SubmitChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, 1);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, 0 );
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage DeleteReceptor(String nombre)
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                var receptorEliminar = (from r in dc.Receptors
                                where r.Nombre.Equals(nombre)
                                select r).SingleOrDefault();

                if (receptorEliminar != null)
                {
                    dc.Receptors.DeleteOnSubmit(receptorEliminar as Receptor);
                    dc.SubmitChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, 1 );

                }
                return Request.CreateResponse(HttpStatusCode.NotFound, 0 );
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
