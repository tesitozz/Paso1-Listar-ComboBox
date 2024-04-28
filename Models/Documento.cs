namespace DSWI_CL1_Sanchez_David_Aaron.Models
{
    public class Documento
    {
        private int tipoDocumento;

        private string desTipoDocumento;


        public Documento(){}

        public string DesTipoDocumento { get => desTipoDocumento; set => desTipoDocumento = value; }
        public int TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
    } 
}
