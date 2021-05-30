using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }

    [WebMethod]
    public DataSet alumno(int bci)
    {

        SqlConnection con = new SqlConnection();
        SqlDataAdapter ada = new SqlDataAdapter();
        con.ConnectionString = "server=(local);user=sa;pwd=123456;database=materias";
        ada.SelectCommand = new SqlCommand();
        ada.SelectCommand.CommandText = "select A.nombre,A.apellido,M.nombreM from alumnoE A, materiaE M , asignacion S where A.ci = S.ci and S.id = M.id and A.ci = " + bci;
        ada.SelectCommand.CommandType = CommandType.Text;
        ada.SelectCommand.Connection = con;
        DataSet ds = new DataSet();
        ada.Fill(ds);
        return ds;
    }
    
}
