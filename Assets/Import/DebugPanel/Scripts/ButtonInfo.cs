using System.Reflection;

namespace DebugPanel
{
    public class ButtonInfo
    {
        public MethodInfo methodInfo;
        public object receiver;

        public ButtonInfo(MethodInfo methodInfo, object receiver)
        {
            this.methodInfo = methodInfo;
            this.receiver = receiver;
        }
    }
}