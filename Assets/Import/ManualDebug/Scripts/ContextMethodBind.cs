using System.Reflection;

namespace ManualDebug
{
    public class ContextMethodBind
    {
        public MethodInfo methodInfo;
        public object context;

        public ContextMethodBind(MethodInfo methodInfo, object context)
        {
            this.methodInfo = methodInfo;
            this.context = context;
        }
    }
}