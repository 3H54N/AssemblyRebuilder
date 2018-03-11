using dnlib.DotNet;

namespace AssemblyRebuilder
{
    internal class IManagedEntryPointWrapper
    {
        public IManagedEntryPoint ManagedEntryPoint { get; set; }

        public IManagedEntryPointWrapper(IManagedEntryPoint managedEntryPoint) => ManagedEntryPoint = managedEntryPoint;

        public override string ToString()
        {
            string str;

            str = ManagedEntryPoint.ToString();
            str = str.Replace("System.Void", "void").Replace("System.Integer", "int");
            return ManagedEntryPoint.MDToken.ToString() + " " + str;
        }
    }
}
