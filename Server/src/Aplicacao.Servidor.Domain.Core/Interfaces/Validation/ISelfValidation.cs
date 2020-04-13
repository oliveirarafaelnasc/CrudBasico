using Aplicacao.Servidor.Domain.Core.Validation;

namespace Aplicacao.Servidor.Domain.Core.Interfaces.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}