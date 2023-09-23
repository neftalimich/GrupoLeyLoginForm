namespace GrupoLeyLoginForm
{
    public class OdooDevice
    {
        public int id { get; set; }
        public string identifier { get; set; } = null!;
        public string name { get; set; } = null!;
        public string type { get; set; } = "scale";
        public int iot_id { get; set; }
        public string iot_ip { get; set; } = "192.168.1.80";
    }
}
