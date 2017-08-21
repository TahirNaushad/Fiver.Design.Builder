using System;
using Xunit;

namespace Fiver.Design.Builder
{
    public class GreetingBuilderTests
    {
        [Fact(DisplayName = "Building_a_greeting_setups_up_greeting_message")]
        public void Building_a_greeting_setups_up_greeting_message()
        {
            Greeting greeting = GreetingBuilder
                                    .CreateNew()
                                    .GreetingTimeOfDay("Morning")
                                    .GreetingTo("James Bond")
                                    .Build();

            Assert.Equal(
                expected: "Good Morning James Bond",
                actual: greeting.Message);
        }

        [Fact(DisplayName = "Building_a_greeting_with_missing_values_throws_exception")]
        public void Building_a_greeting_with_missing_values_throws_exception()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Greeting greeting = GreetingBuilder
                                        .CreateNew()
                                        .GreetingTimeOfDay("")
                                        .GreetingTo("James Bond")
                                        .Build();
            });

            Assert.Equal(
                expected: "Time of Day must be set",
                actual: ex.Message);
        }
    }
}
