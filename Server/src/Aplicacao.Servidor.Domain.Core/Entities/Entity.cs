using Aplicacao.Servidor.Domain.Core.Interfaces.Validation;
using Aplicacao.Servidor.Domain.Core.Validation;
using System;

namespace Aplicacao.Servidor.Domain.Core.Entities
{
    public abstract class Entity<T> : ISelfValidation where T : Entity<T>
    {
        public Guid Id { get; protected set; }

        public abstract ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid { get; }
    }
}
