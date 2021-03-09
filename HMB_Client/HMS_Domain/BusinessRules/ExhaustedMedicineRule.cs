using Csla.Core;
using Csla.Reflection;
using Csla.Rules;
using System;

namespace HMB_Domain.BusinessRules
{
   public class ExhaustedMedicineRule : AuthorizationRule
    {

        private IMemberInfo ValueTo { get; set; }
        public ExhaustedMedicineRule(AuthorizationActions action, IMemberInfo element, IMemberInfo valueTo)
          : base(action, element)
        {
            ValueTo = valueTo;
            CacheResult = false;
        }

        protected override void Execute(IAuthorizationContext context)
        {
            var valueTo = (DateTime)MethodCaller.CallPropertyGetter(context.Target, ValueTo.Name);
            context.HasPermission = DateTime.Today.CompareTo(valueTo) > 0;
        }
    }
}
