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
    public class UsuariosController : ApiController
    {

        public List<UsuarioBean> GetUsuarios()
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                List<Usuario> listOrigin = dc.Usuarios.ToList() as List<Usuario>;
                List<UsuarioBean> listSend = new List<UsuarioBean>();
                UsuarioBean userBean;
                foreach (Usuario o in listOrigin)
                {
                    userBean = new UsuarioBean();
                    userBean.CodUsuario = o.CodUsuario.ToString();
                    userBean.Nombres = o.Nombres;
                    userBean.Apellidos = o.Apellidos;
                    userBean.IDUsuario = o.IDUsuario;
                    userBean.Contrasena = o.Contrasena;
                    userBean.Activo = o.Activo.ToString();
                    userBean.Alertas = o.Alertas.Count().ToString();
                    userBean.Receptors = o.Receptors.Count().ToString();
                    listSend.Add(userBean);
                }
                return listSend;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //Cambiar el nombre del pametro COD para que no se confunda con el postCredenciales
        public UsuarioBean GetUsuario(string IDUsuario)
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                var usuario = (from u in dc.Usuarios
                               where u.IDUsuario == IDUsuario
                               select u).SingleOrDefault();
                if (usuario != null)
                {
                    UsuarioBean userBean = new UsuarioBean();
                    userBean.CodUsuario = usuario.CodUsuario.ToString();
                    userBean.Nombres = usuario.Nombres;
                    userBean.Apellidos = usuario.Apellidos;
                    userBean.IDUsuario = usuario.IDUsuario;
                    userBean.Contrasena = usuario.Contrasena;
                    userBean.Activo = usuario.Activo.ToString();
                    userBean.Alertas = usuario.Alertas.Count().ToString();
                    userBean.Receptors = usuario.Receptors.Count().ToString();

                    return userBean;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public UsuarioBean GetUsuarioCod(string CodUsuario)
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                var usuario = (from u in dc.Usuarios
                               where u.CodUsuario.ToString().Equals( CodUsuario)
                               select u).SingleOrDefault();
                if (usuario != null)
                {
                    UsuarioBean userBean = new UsuarioBean();
                    userBean.CodUsuario = usuario.CodUsuario.ToString();
                    userBean.Nombres = usuario.Nombres;
                    userBean.Apellidos = usuario.Apellidos;
                    userBean.IDUsuario = usuario.IDUsuario;
                    userBean.Contrasena = usuario.Contrasena;
                    userBean.Activo = usuario.Activo.ToString();
                    userBean.Alertas = usuario.Alertas.Count().ToString();
                    userBean.Receptors = usuario.Receptors.Count().ToString();

                    return userBean;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //Soicitado
        public HttpResponseMessage PostUsuario(Usuario usuario)//todos los paramtros
        {
            try
            {

                alert360dbDataContext dc = new alert360dbDataContext();
                Usuario usuarioExiste = ((from u in dc.Usuarios
                                          where u.IDUsuario == usuario.IDUsuario
                                          select u).SingleOrDefault()) as Usuario;
                // Para la cracion de usuarios
                if (usuarioExiste == null)
                {
                    if (usuario.Nombres.Equals("login"))
                    {//usuario no existe
                        return Request.CreateResponse(HttpStatusCode.NotFound, -3);
                    }

                    //Registramos al usuario y devolvemos el Codigo Generado
                    dc.Usuarios.InsertOnSubmit(usuario as Usuario);
                    dc.SubmitChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, usuario.CodUsuario);

                }
                else
                {//usuario existente

                    if (usuario.Nombres.Equals("login"))
                    { // Para el Login >>> Si exite. y si envia los demas parametros en blanco

                        if (usuarioExiste.Activo == 1)
                        { // usuario ya logado
                            return Request.CreateResponse(HttpStatusCode.OK, -1);
                        }


                        if (usuarioExiste.Activo == 0 && usuarioExiste.Contrasena == usuario.Contrasena)
                        { //correcto Login 

                            usuarioExiste.Activo = 1;
                            dc.SubmitChanges();
                            // usuario activo y no podra loguearse desde otro android

                           
                            return Request.CreateResponse(HttpStatusCode.Accepted, GetUsuario(usuario.IDUsuario));

                        }
                        else
                        {// Pass incorrecto
                            return Request.CreateResponse(HttpStatusCode.OK, 0);

                        }
                    }
                    else
                    {//usuario ya registrado
                        return Request.CreateResponse(HttpStatusCode.OK, -2);
                    }
                }

            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //Solicitado
        //public HttpResponseMessage PostCredencialUsuario(Credencial user)
        //{
        //    try
        //    {
        //        alert360dbDataContext dc = new alert360dbDataContext();
        //        var usuarioExiste = (from u in dc.Usuarios
        //                             where u.IDUsuario == user.IDUsuario
        //                             select u).SingleOrDefault();

        //        if (usuarioExiste != null)
        //        {
        //            if(usuarioExiste.Activo == 1)
        //            {
        //                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "-2");
        //                // usuario ya logado
        //            }
        //            if(usuarioExiste.Contrasena == user.Contrasena)
        //            {
        //                var userToUpdate = (from u in dc.Usuarios
        //                                    where u.IDUsuario == user.IDUsuario
        //                                    select u).SingleOrDefault();
        //                userToUpdate.Activo = 1;
        //                dc.SubmitChanges();
        //                // usuario activo y no podra loguearse desde otro android

        //                return Request.CreateResponse(HttpStatusCode.OK, "1");
        //                //correcto validado
        //            }
        //            else
        //            {
        //                return Request.CreateResponse(HttpStatusCode.NotFound, "0");
        //                // Pass incorrecto
        //            }
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound, "-1");
        //            // no exite usuario
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
        //    }

        //}

        [HttpPatch]
        [HttpPut]
        public HttpResponseMessage PutUsuario([FromBody] Usuario user)  //{"Nombres":"signout", "IDUsuario": "polo5",  "Contrasena": "1234"  }
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                var userToUpdate = (from u in dc.Usuarios
                                    where u.IDUsuario == user.IDUsuario
                                    select u).SingleOrDefault();

                if (userToUpdate != null)
                {//"Nombres" es un flag para saber si el PUT es de SIGNOUT o de Actualizar Usuario 

                    if (user.Nombres.Equals("signout"))
                    {//signout exitoso  -  activo setesado a 0 para que luego se conecte desde cualquier otro android simultaneamente 

                        userToUpdate.Activo = 0;
                        dc.SubmitChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, 1);

                    }

                    else //Nombres distinto de SIGNOUT
                    {// si envia todos los parametros es una actualizacion del usuarios 

                        userToUpdate.Nombres = user.Nombres;
                        userToUpdate.Apellidos = user.Apellidos;
                        userToUpdate.Contrasena = user.Contrasena;
                        dc.SubmitChanges();
                        return Request.CreateResponse(HttpStatusCode.Accepted, 2);
                    }
                }
                //usuario no existe
                return Request.CreateResponse(HttpStatusCode.NotFound, 0);


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        /*
        public HttpResponseMessage DeleteUsuario(int codUsuario)
        {
            try
            {
                alert360dbDataContext dc = new alert360dbDataContext();
                var usuario = (from u in dc.Usuarios
                               where u.CodUsuario == codUsuario
                                 select u).SingleOrDefault();
                if (usuario != null)
                {
                    dc.Usuarios.DeleteOnSubmit(usuario as Usuario);
                    dc.SubmitChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);

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