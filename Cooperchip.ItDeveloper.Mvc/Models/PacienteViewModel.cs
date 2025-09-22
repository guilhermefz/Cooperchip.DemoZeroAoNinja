using Cooperchip.ItDeveloper.Domain.Entities;
using Cooperchip.ItDeveloper.Domain.Enuns;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.ItDeveloper.Mvc.Models
{
    public class PacienteViewModel 
    {
        [Key]
        [DisplayName("Id do Paciente")]
        public Guid Id { get; set; }
        [DisplayName("Estado do paciente")]
        public Guid? EstadoPacienteId { get; set; }
        public IEnumerable<SelectListItem>? EstadosPaciente { get; set; }
        public virtual EstadoPaciente? EstadoPaciente { get; set; }
        [DisplayName(displayName: "Nome do Paciente")]
        [StringLength(maximumLength: 80, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string? Nome { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "o campo {0} está inválido")]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Data de Internação")]
        [DataType(DataType.DateTime, ErrorMessage = "o campo {0} está inválido")]
        public DateTime DataInternacao { get; set; }

        //[DisplayName(displayName: "Data Inclusão")]
        //public DateTime? DataInclusao { get; set; }
        //[DisplayName(displayName: "Data Útima Modificação")]
        //public DateTime? DataUltimaModificacao { get; set; }
        //[DisplayName(displayName: "Usuário Inclusão")]
        //public string? UsuarioInclusao { get; set; }
        //[DisplayName(displayName: "Usuário Última Modificação")]
        //public string UsuarioUltimaModificação { get; set; }    


        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Inválido")]
        public string? Email { get; set; }
        public bool Ativo { get; set; }
        [DisplayName("CPF")]
        [Required(ErrorMessage = "Campo {0} é requerido")]
        [StringLength(11, ErrorMessage = "O campo {0} tem de ter {1} caracteres", MinimumLength = 11)]
        public string? Cpf { get; set; }
        [DisplayName("Tipo de Paciente")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public TipoPaciente? TipoPaciente { get; set; }
        [DisplayName("Sexo")]
        [Required(ErrorMessage = "O campo {0} é requerido. ")]
        public Sexo? Sexo { get; set; }
        [DisplayName("RG")]
        [MaxLength(15, ErrorMessage = "O campo {0} não pode ter mais que (1) caracteres. ")]
        public string? Rg { get; set; }
        public string? RgOrgao { get; set; }
        [Display(Name = "Data de Emissão da RG")]
        [DataType(DataType.DateTime, ErrorMessage = "o campo {0} está inválido")]
        public DateTime? RgDataEmissao { get; set; }
        public string? Motivo { get; set; }
    }
}
