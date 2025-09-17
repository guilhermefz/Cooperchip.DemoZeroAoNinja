using Cooperchip.ItDeveloper.Data.Data.ORM;
using Cooperchip.ItDeveloper.Mvc.Extensions.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.ItDeveloper.Mvc.Extensions.ViewComponents.EstadoPaciente
{
    [ViewComponent(Name = "StatusPaciente")]
    public class StatusPacienteViewComponent : ViewComponent
    {
        private readonly ITDeveloperDbContext _context;

        public StatusPacienteViewComponent(ITDeveloperDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string estado)
        {
            var totalGeral = Util.TotReg(_context);
            decimal totalEstado = Util.GetNumRegEstado(_context, estado);
            decimal progress = (totalGeral > 0) ? totalEstado * 100 / totalGeral : 0;
            var percentual = progress.ToString("F1");

            var classContainer = "";
            var iconeLg = "";


            switch (estado)
            {
                case "Crítico":
                    classContainer = "panel panel-warning tile panelClose panelRefresh";
                    iconeLg = "l-basic-geolocalize-05";
                    break;
                case "Grave":
                    classContainer = "panel panel-danger tile panelClose panelRefresh";
                    iconeLg = "l-basic-life-buoy";
                    break;
                case "Estável":
                    classContainer = "panel panel-success tile panelClose panelRefresh";
                    iconeLg = "l-ecommerce-cart-content";
                    break;
                case "Em Observação":
                    classContainer = "panel panel-default tile panelClose panelRefresh";
                    iconeLg = "l-banknote";
                    break;

            }

            ContadorEstadoPaciente model = new()
            {
                Titulo = $"Pacientes {estado}",
                Parcial = (int)totalEstado,
                Progress = progress,
                ClassContainer = classContainer,
                IconeLg = iconeLg,
                IconeSm = "fa fa-arrow-circle-o-up s20 mr5 pull-left"
            };

            return await Task.FromResult(View(model));
        }
    }
}
