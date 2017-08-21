using System;

namespace Fiver.Design.Builder
{
    public interface IGreetingBuilderSetTimeOfDay
    {
        IGreetingBuilderSetTo GreetingTimeOfDay(string timeOfDay);
    }

    public interface IGreetingBuilderSetTo
    {
        IGreetingBuilder GreetingTo(string to);
    }

    public interface IGreetingBuilder
    {
        Greeting Build();
    }

    public sealed class GreetingBuilder :
        IGreetingBuilderSetTimeOfDay,
        IGreetingBuilderSetTo,
        IGreetingBuilder
    {
        private string timeOfDay = "";
        private string to = "";

        private GreetingBuilder() {}

        public static IGreetingBuilderSetTimeOfDay CreateNew()
        {
            return new GreetingBuilder();
        }

        public IGreetingBuilderSetTo GreetingTimeOfDay(string timeOfDay)
        {
            this.timeOfDay = timeOfDay;
            return this;
        }

        public IGreetingBuilder GreetingTo(string to)
        {
            this.to = to;
            return this;
        }

        public Greeting Build()
        {
            return new Greeting(timeOfDay, to);
        }
    }
}