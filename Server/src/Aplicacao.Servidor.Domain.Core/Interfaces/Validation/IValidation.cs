using Aplicacao.Servidor.Domain.Core.Validation;

namespace Aplicacao.Servidor.Domain.Core.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}