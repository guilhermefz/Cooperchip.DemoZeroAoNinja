using System.ComponentModel;

namespace Cooperchip.ItDeveloper.Domain.Enuns
{
    public enum TipoEntradaPaciente
    {
        [Description("Internação")] Internacao = 1,
        [Description("Emergência")] Emergencia,
        [Description("Trasnferência")] Transferencia,
        [Description("Ambulatório")] Ambulatorio,
        [Description("Sem Prontuário")] SemProntuario,
    }
}
