using IContainer = Autofac.IContainer;

namespace BusinessLayer
{
    public static class InitBL
    {
        internal static IContainer Container { get; set; }

        public static void SetContainer(IContainer c)
        {
            Container = c;
        }
    }
}
