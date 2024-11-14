using NpgsqlTypes;

namespace API.Database.Models;

public enum ModuleStatus
{
    [PgName("draft")]
    Draft,
    [PgName("on_approval")]
    OnApproval,
    [PgName("hired")]
    Hired
}