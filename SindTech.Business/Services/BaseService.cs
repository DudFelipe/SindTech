﻿using SindTech.Business.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using SindTech.Business.Models;

namespace SindTech.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            validationResult.Errors.ForEach(e => Notificar(e.ErrorMessage));
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacoes.Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid)
            {
                return true;
            }

            Notificar(validator);

            return false;
        }
    }
}
