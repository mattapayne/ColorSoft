using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ColorSoft.Web.Validation;

namespace ColorSoft.Web.Extensions
{
    public static class ControllerExtensions
    {
        public static IEnumerable<PropertyError> ModelStateErrorsAsJson(this Controller controller)
        {
            if (controller.ModelState.IsValid)
            {
                return Enumerable.Empty<PropertyError>();
            }

            return controller.ModelState.Where(ms => ms.Value.Errors.Any()).Select(ExtractModelStateErrors);
        }

        private static PropertyError ExtractModelStateErrors(KeyValuePair<string, ModelState> ms)
        {
            return new PropertyError
                {
                    PropertyName = ms.Key,
                    ErrorMessage =
                        String.Join(", ",
                                    ms.Value.Errors.Select(
                                        e =>
                                        !String.IsNullOrEmpty(e.ErrorMessage) ? e.ErrorMessage : e.Exception.Message).
                                        ToArray())
                };
        }
    }
}