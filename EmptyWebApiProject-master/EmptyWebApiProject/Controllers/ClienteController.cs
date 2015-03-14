using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using EmptyWebApiProject.Models;
using Newtonsoft.Json;

namespace EmptyWebApiProject.Controllers
{
    public class ClienteController : ApiController
    {
        public string GetClientes()
        {
            alert360dbDataContext dc = new alert360dbDataContext();
            try
            {
                return JsonConvert.SerializeObject(dc.Clientes, Formatting.Indented,
                            new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }


        public string GetClienteCod(int cod)
        {


            alert360dbDataContext dc = new alert360dbDataContext();
            var cliente = dc.Clientes.Where(c => c.CodCliente == cod);
            if (cliente == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return JsonConvert.SerializeObject(cliente, Formatting.Indented,
                            new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

        }

        /*  
          public HttpResponseMessage PostCliente(string jCliente)
          {

              alert360dbDataContext dc = new alert360dbDataContext();

              Cliente nuevoCliente = JsonConvert.DeserializeObject<Cliente>(jCliente);

              dc.Clientes.InsertOnSubmit(nuevoCliente);
              dc.SubmitChanges();

              Cliente ClienteAgregado = dc.Clientes.Where(c => c.Nombre.Equals(nuevoCliente.Nombre) &&
                                                               c.Apellido.Equals(nuevoCliente.Apellido)) as Cliente;
              /////
              // person = databasePlaceholder.Add(person);
              string apiName = App_Start.WebApiConfig.DEFAULT_ROUTE_NAME;
              var response = this.Request.CreateResponse<Cliente>(HttpStatusCode.Created, ClienteAgregado);
              string uri = Url.Link(apiName, new { id = ClienteAgregado.CodCliente });
              response.Headers.Location = new Uri(uri);
              return response;

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
        

          public void DeleteCliente(int cod)
          {

              alert360dbDataContext dc = new alert360dbDataContext();
              Cliente cliente = dc.Clientes.Where(c => c.CodCliente == cod) as Cliente;
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
