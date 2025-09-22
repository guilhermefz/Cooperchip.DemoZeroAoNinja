using System.ComponentModel;

namespace Cooperchip.ItDeveloper.Domain.Enuns
{
    public enum TipoSaidaPaciente
    {
        [Description("Recebeu Alta")] Alta = 1,
        [Description("Transferido")] Transferencia,
        [Description("Saiu à Revelia")] ARevelia,
        [Description("Veio a Óbito")] Obito,
        Outros

    }
}
