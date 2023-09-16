using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Business.Utilities.Intercepter;
using Castle.DynamicProxy;

namespace Business.Aspect.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodIntercepton
    {
        //BAŞINDA SONUNDA DEĞİL METODUN YAŞAM ÖYKÜSÜNDE 
        public override void Intercept(IInvocation invocation)
        { //DİSP. PATTERN
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
