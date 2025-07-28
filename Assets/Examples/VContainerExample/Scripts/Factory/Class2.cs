namespace Examples.VContainerExample.Factory
{
    public class Class2
    {
        private readonly Class1 class1;

        public Class2(Class1 class1)
        {
            this.class1 = class1;
        }

        public void Hi() => class1.Hi();
    }
}