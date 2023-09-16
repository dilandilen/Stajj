using Business.CrossCuttingConcerns.Validation;
using Business.Utilities.Intercepter;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Aspect.Autofac.Validation
{
    public class ValidationAspect:MethodIntercepton
    {
        Type _validatorType;
        public ValidationAspect(Type validatorType) {
            if(!typeof(IValidator).IsAssignableFrom(validatorType))
            {//MAGİC STRİNG
                throw new Exception("wrong type");
            }
            _validatorType=validatorType;
        }
        //method cağrılmadan önce
        protected override void OnBefore(Castle.DynamicProxy.IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach(var entity in entities) { 
            ValidationTool.Validate(validator, entity);
                    
                    }
        
        
        }




    }
}
