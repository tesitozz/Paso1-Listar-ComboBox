namespace DSWI_CL1_Sanchez_David_Aaron.Models
{
    public class Pacientes
    {
        private string codPaciente;

        private string nombres;

        private string apePaterno;

        private string apaMaterno;

        private string codTipoDocumento;

        private string desTipoDocumento;

        private string telefono;

        private string email;

        private int codiDistrito;

        private string distrito;

        private string direccion;

        private int estadoRegistro;


        public string CodPaciente { get => codPaciente; set => codPaciente = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string ApePaterno { get => apePaterno; set => apePaterno = value; }
        public string ApaMaterno { get => apaMaterno; set => apaMaterno = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Distrito { get => distrito; set => distrito = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int EstadoRegistro { get => estadoRegistro; set => estadoRegistro = value; }
        public string DesTipoDocumento { get => desTipoDocumento; set => desTipoDocumento = value; }
        public string CodTipoDocumento { get => codTipoDocumento; set => codTipoDocumento = value; }
        public int CodiDistrito { get => codiDistrito; set => codiDistrito = value; }
    }
}
