namespace GrupoLeyLoginForm
{
    public class OdooHttpBase
    {
        public string Jsonrpc { get; set; } = "2.0";
        public string Method { get; set; } = "call";
        public int Id { get; set; } = 0;
    }
    public class OdooRequest<P> : OdooHttpBase where P : class
    {
        public P? Params { get; set; }
    }

    public class OdooParamsPreAuthenticate
    {
        public string Db { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Credential { get; set; }
        public string? Nip { get; set; }
        public string? Identifier { get; set; }
    }

    public class Dummy { }

    public class OdooResponse<R> : OdooHttpBase where R : class
    {
        public R? Result { get; set; }

        public OdooErrorBase? Error { get; set; }
    }

    public class OdooResultBase
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
    }
    public class OdooResultPreAuthenticate : OdooResultBase
    {
        public int User_id { get; set; }
        public int Log_id { get; set; }
        public DateTime Log_date { get; set; }
        public int? Employee_id { get; set; }
        public string? Employee_name { get; set; }
    }

    public class OdooErrorBase
    {
        public int Code { get; set; }
        public string Message { get; set; } = null!;
        public OdooErrorData? Data { get; set; }
    }

    public class OdooErrorData
    {
        public string Name { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
