using System;
using System.Collections.Generic;
using System.Text;

namespace FagronTech.Infrastructure.Repository
{
    [AttributeUsage(System.AttributeTargets.Method)]
    public class TransactionalAttribute : Attribute
    {
    }
}
