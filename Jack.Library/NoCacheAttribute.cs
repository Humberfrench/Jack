using System;
using System.Web.Mvc;

namespace Jack.Library
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NoCacheAttribute : OutputCacheAttribute
    {
        public NoCacheAttribute()
        {
            Duration = 1;
        }
    }
}