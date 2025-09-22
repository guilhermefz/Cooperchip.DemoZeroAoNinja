using System.ComponentModel;

namespace Cooperchip.ItDeveloper.Domain.Enuns
{
    public enum TipoMovimentoPaciente
    {
        [Description("Entrada de Paciente")] Entrada = 1,
        [Description("Saída de Paciente")] Saida
    }
}
