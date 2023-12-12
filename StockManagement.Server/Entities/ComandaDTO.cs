namespace StockManagement.Server.Entities
{
    public class ComandaDTO
    {
        public int Comadna_id { get; set; }

        public int Angajat_id_FK { get; set; }

        public int Furnizor_id_FK { get; set; }

        public string Status { get; set; }

        public string Data {  get; set; }
        public int Nr_produse { get; set; }


    }
}
