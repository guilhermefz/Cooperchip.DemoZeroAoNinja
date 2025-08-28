using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.ItDeveloper.Domain.Enuns
{
    public enum TipoPaciente
    {
        [Description("Conveniado")] Conveniado = 1,
        [Description("Particular")] Particular,
        [Description("Outros")] Outros 
    }
}
