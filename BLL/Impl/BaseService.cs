using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class BaseService
    {
        private List<Error> errors = new List<Error>();

        protected void AddError(string fieldName, string message)
        {
            errors.Add(new Error() { FieldName = fieldName, Message = message });
        }
        protected void CheckErrors()
        {
            //APÓS VALIDAR TODOS OS CAMPOS, VERIFIQUE SE POSSUIMOS ERROS
            if (errors.Count > 0)
            {
                throw new NecoException(errors);
            }
        }
    }
}
