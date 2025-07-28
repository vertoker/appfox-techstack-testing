namespace Examples.VContainerExample.Factory
{
    public class BarFactory
    {
        private readonly Class1 class1;

        public BarFactory(Class1 class1)
        {
            this.class1 = class1;
        }

        public Bar Create(int number)
        {
            class1.Hi();
            return new Bar(number);
        }
    }
}