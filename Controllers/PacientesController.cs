using DSWI_CL1_Sanchez_David_Aaron.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace DSWI_CL1_Sanchez_David_Aaron.Controllers
{
    public class PacientesController : Controller
    {

        private readonly IConfiguration _config; // Llamar al WebConfig


        public PacientesController(IConfiguration config)
        {
            this._config = config; //Llamando al Webconfig
        }

        List<Pacientes> obtenerPacientes()
        {
            List<Pacientes> lstPacientes = new List<Pacientes>();

            SqlConnection cn = new SqlConnection(_config["ConnectionStrings:sql"].ToString()); //Llamando al WebConfig

            SqlCommand cmd = new SqlCommand("usp_listarPacientes", cn); //Llamando al procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //Abrimos la Conexion

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Pacientes reg = new Pacientes();

                reg.CodPaciente = dr.GetString("codPaciente");
                reg.Nombres = dr.GetString("NombreCompleto");
                reg.CodTipoDocumento = dr.GetString("TipoDocumento");
                reg.DesTipoDocumento = dr.GetString("NumeroDocumento");
                reg.Telefono = dr.GetString("telefono");
                reg.Email = dr.GetString("email");
                lstPacientes.Add(reg);
            }

            //Cerramos las Conexiones

            dr.Close();
            cn.Close();

            return lstPacientes;

        }

        public IActionResult ListarPacientes(int? pag = null)
        {
            List<Pacientes> lista = obtenerPacientes();

            int numRegistros = 8;   

            int totalRegistros = lista.Count; 

            int numPaginas = (int)Math.Ceiling((double)totalRegistros / numRegistros);

            int paginaActual = pag ?? 1;

            paginaActual = Math.Max(1, Math.Min(paginaActual,numPaginas));

            int indiceInicio = (paginaActual - 1) * numRegistros;
            int indiceFin = Math.Min(indiceInicio + numRegistros, totalRegistros);

            List<Pacientes> pacientesPagina = lista.Skip(indiceInicio).Take(indiceFin - indiceInicio).ToList();

            ViewBag.paginaActual = paginaActual;
            ViewBag.numPagina = numPaginas;

            return View(pacientesPagina);
        }

        List<Documento> obtenerDocumentos()
        {
            List<Documento> lstDocumentos = new List<Documento>();

            SqlConnection cn = new SqlConnection(_config["ConnectionStrings:sql"].ToString());
            SqlCommand cmd = new SqlCommand("usp_listarDocumentos", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Documento reg = new Documento();
                reg.TipoDocumento = dr.GetInt32("CodTipoDocumento");
                reg.DesTipoDocumento = dr.GetString("DesTipoDocumento");
                lstDocumentos.Add(reg);
            }

            dr.Close(); 
            cn.Close();
            return lstDocumentos;
        }

        List<Distrito> obtenerDistrito()
        {
            List<Distrito> lstDistrito = new List<Distrito>();

            SqlConnection cn = new SqlConnection(_config["ConnectionStrings:sql"].ToString());
            SqlCommand cmd = new SqlCommand("usp_listarDistritos", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Distrito reg = new Distrito();
                reg.CodDistrito = dr.GetInt32(dr.GetOrdinal("codDistrito"));
                reg.DesDistrito = dr.GetString(dr.GetOrdinal("desDistrito"));
                lstDistrito.Add(reg);
            }


            dr.Close();
            cn.Close();
            return lstDistrito;

        }

        public IActionResult crearPaciente()
        {
            ViewBag.listaDocumentos = new SelectList(obtenerDocumentos(), "TipoDocumento", "DesTipoDocumento");
            ViewBag.listaDistritos = new SelectList(obtenerDistrito(), "CodDistrito", "DesDistrito");
            return View(new Pacientes());
        }

     

    }

  
}

