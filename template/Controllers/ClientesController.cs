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
    public class ClientesController : ApiController
    {
        /*
        public List<Cliente> GetClientes()
        {
            alert360dbDataContext dc = new alert360dbDataContext();
            try
            {
               //return JsonConvert.SerializeObject(dc.Clientes, Formatting.Indented,
               //            new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
                return dc.Clientes.ToList() as List<Cliente>;
            }
            catch (Exception e)
            {
               // return e.ToString();
                return null;
            }
        }

        public Cliente GetCliente(int codCliente)
        {


            alert360dbDataContext dc = new alert360dbDataContext();
            var cliente = (from c in dc.Clientes
                          where c.CodCliente == codCliente
                          select c).SingleOrDefault();
            if (cliente == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return cliente as Cliente;
        }

        public HttpResponseMessage Post([FromBody]Cliente nuevoCliente) // recibir un objeto directamente (internamente ya lo serializa)
        { 

            alert360dbDataContext dc = new alert360dbDataContext();


            dc.Clientes.InsertOnSubmit(nuevoCliente as Cliente);
            dc.SubmitChanges();

            Cliente ClienteAgregado = dc.Clientes.Where(c => c.Nombre.Equals(nuevoCliente.Nombre) &&
                                                             c.Apellido.Equals(nuevoCliente.Apellido)) as Cliente;
            /////
            // person = databasePlaceholder.Add(person);
            //string apiName = App_Start.WebApiConfig.DEFAULT_ROUTE_NAME;
            
            //var response = this.Request.CreateResponse<Cliente>(HttpStatusCode.Created, ClienteAgregado);
            //string uri = Url.Link("api", new { id = ClienteAgregado.CodCliente });
            //response.Headers.Location = new Uri(uri);
            //return response;
            return Request.CreateResponse(HttpStatusCode.Created,nuevoCliente);

        }

         public bool PutPerson(string jCliente)
            {

                alert360dbDataContext dc = new alert360dbDataContext();

                Cliente clienteActualizado = JsonConvert.DeserializeObject<Cliente>(jCliente);

                Cliente cliente = dc.Clientes.Where(c => c.CodCliente == clienteActualizado.CodCliente) as Cliente;

                if (cliente == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                cliente.Nombre = clienteActualizado.Nombre;
                cliente.Apellido = clienteActualizado.Apellido;
                dc.SubmitChanges();
                  

                return true;
            }
        

            public void DeleteCliente(int codCliente)
            {

                alert360dbDataContext dc = new alert360dbDataContext();
                Cliente cliente = dc.Clientes.Where(c => c.CodCliente == codCliente).SingleOrDefault() as Cliente;
                if (cliente == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                dc.Clientes.DeleteOnSubmit(cliente);
                dc.SubmitChanges();
            }
             
        */
    }
}
