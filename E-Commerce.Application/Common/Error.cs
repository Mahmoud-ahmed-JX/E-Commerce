using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Common
{
    public record Error(string Code, string Description, ErrorType Type = ErrorType.Failure)
    {
        public static Error Failure(string code= "General.Failure", string description = "General Failure Desc") 
            => new(code, description, ErrorType.Failure);
        public static Error Validation(string code = "General.Validation", string description = "General Validation Desc")
            => new(code, description, ErrorType.Validation);
        public static Error NotFound(string code = "General.NotFound", string description = "General NotFound  Desc")
            => new(code, description, ErrorType.NotFound);
        public static Error UnAuthorized(string code = "General.UnAuthorized", string description = "General UnAuthorized Desc")
            => new(code, description, ErrorType.UnAuthorized);
        public static Error Forbidden(string code = "General.Forbidden", string description = "General Forbidden Desc")
            => new(code, description, ErrorType.Forbidden);
        public static Error InvalidCredentials(string code = "General.InvalidCredentials", string description = "General InvalidCredentials Desc")
            => new(code, description, ErrorType.InvalidCredentials);
    }
}
