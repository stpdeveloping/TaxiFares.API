using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiFares.API.Test.ClassLibrary.Extensions
{
    public static class ObjectListExtension
    {
        public static object GetObjWithType(this IList<object> list, 
            Type type) => list.SingleOrDefault(listObj => 
                    listObj.GetType().IsAssignableTo(type));
    }
}
