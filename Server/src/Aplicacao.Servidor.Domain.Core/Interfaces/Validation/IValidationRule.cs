﻿namespace Aplicacao.Servidor.Domain.Core.Interfaces.Validation
{
    public interface IValidationRule<in TEntity>
    {
        string ErrorMessage { get; }
        bool Valid(TEntity entity);
    }
}