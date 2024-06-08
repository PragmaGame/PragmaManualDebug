using System;
using System.Collections.Generic;
using System.Reflection;

namespace ManualDebug
{
    public class MethodBind
    {
        protected List<Parameter> parameters;
        protected MethodInfo target;
        protected object context;
        protected string key;

        public string Key => key;
        public object Context => context;
        public IReadOnlyList<Parameter> Parameters => parameters;

        public MethodBind(string key, MethodInfo target, object context, List<Parameter> parameters)
        {
            this.key = key;
            this.target = target;
            this.context = context;
            this.parameters = parameters;
        }

        public void Invoke(object[] args)
        {
            if (args.Length != parameters.Count)
            {
                throw new Exception("The number of parameters does not match");
            }

            var convertedArgs = new object[args.Length];
            
            for (var i = 0; i < args.Length; i++)
            {
                convertedArgs[i] = parameters[i].converter.Convert(args[i]);
            }

            target.Invoke(context, convertedArgs);
        }
    }
}