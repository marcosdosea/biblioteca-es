using BibliotecaWeb.Models;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MySql.Data.MySqlClient;

namespace BibliotecaWeb.Filter
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IModelMetadataProvider modelMetadataProvider;

        public CustomExceptionFilter(IModelMetadataProvider modelMetadataProvider)
        {
            this.modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var result = new ViewResult { ViewName = "Error" };
            result.ViewData = new ViewDataDictionary(modelMetadataProvider, context.ModelState);

            if (exception is MySqlException mySqlException)
            {
                if (mySqlException.Number == 1451)
                {
                    result.ViewData["ErrorMessage"] = "Não é possível excluir este registro, pois ele está vinculado a outros dados no sistema.";
                }
                else if (mySqlException.Number == 1062)
                {
                    result.ViewData["ErrorMessage"] = "Violação de chave única: já existe um registro com este valor.";
                }
                else if (mySqlException.Number == 1048)
                {
                    result.ViewData["ErrorMessage"] = "Um campo obrigatório não foi preenchido.";
                }
                else if (mySqlException.Number == 1406)
                {
                    result.ViewData["ErrorMessage"] = "Um campo excedeu o tamanho máximo permitido.";
                }
                else if (mySqlException.Number == 1216 || mySqlException.Number == 1217)
                {
                    result.ViewData["ErrorMessage"] = "Violação de chave estrangeira: operação inválida devido a dados relacionados.";
                }
                else if (mySqlException.Number == 1366)
                {
                    result.ViewData["ErrorMessage"] = "Tipo de dado inválido fornecido para um campo.";
                }
                else
                {
                    result.ViewData["ErrorMessage"] = "Ocorreu um erro no banco de dados. Por favor entrar em contato com o adminstrador do sistema.";
                }
            }
            else
            {
                result.ViewData["ErrorMessage"] = "Ocorreu um erro inesperado. Por favor entrar em contato com o administrador do sistema.";
            }

            result.ViewData["Exception"] = exception;

            // mark exception as handled
            context.ExceptionHandled = true;
            context.Result = result;
        }
    }
}
