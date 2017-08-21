using System;
using Xunit;

namespace Fiver.Design.Builder
{
    public class EmailBuilderTests
    {
        [Fact(DisplayName = "Building_email_sets_up_correct_props")]
        public void Building_a_greeting_sets_up_greeting_message()
        {
            Email email = EmailBuilder
                            .CreateNew()
                            .AddSubject("A simple email builder")
                            .AddFrom("james@bond.com")
                            .AddBody("This pattern could be useful for complex setup")
                            .AddTo("joker@circus.com")
                            .Build();

            Assert.Equal(
                expected: "A simple email builder", 
                actual: email.Subject);
        }

        [Fact(DisplayName = "Building_email_with_missing_values_throws_exception")]
        public void Building_a_greeting_with_missing_values_throws_exception()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Email email = EmailBuilder
                            .CreateNew()
                            .AddSubject("")
                            .AddFrom("james@bond.com")
                            .AddBody("This pattern could be useful for complex setup")
                            .AddTo("joker@circus.com")
                            .Build();
            });

            Assert.Equal(
                expected: "Subject must be set",
                actual: ex.Message);
        }
    }
}
