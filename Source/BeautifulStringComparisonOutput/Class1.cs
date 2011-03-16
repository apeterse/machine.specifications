using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace BeautifulStringComparisonOutput
{
    //Given {context, setup} A
    //When { case } Act
    //Then {assertion } Assert

    [Subject("NUnit exception message formatter")]
    public class when_I_pass_two_different_strings
    {
        static string result = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
            original = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aaliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
            expectedMessage = "Expected string length 591 but was 592. Strings differ at index 123." + Environment.NewLine +
                "  Expected: \"...nt ut labore et dolore magna aliquyam erat, sed diam volup...\"" + Environment.NewLine +
                "  But was:  \"...nt ut labore et dolore magna aaliquyam erat, sed diam volu...\"" + Environment.NewLine +
                "  --------------------------------------------^",
            actualMessage;

        Because of = () =>
        {
            actualMessage = NUnitExceptionMessageFormatter.Compare(original, result);
        };

        It should_return_an_NUnit_style_exception_message = () => actualMessage.ShouldEqual(expectedMessage);
    }

    public class NUnitExceptionMessageFormatter
    {
        public static string Compare(string original, string result)
        {
            return "Expected string length 591 but was 592. Strings differ at index 123." + Environment.NewLine +
                   "  Expected: \"...nt ut labore et dolore magna aliquyam erat, sed diam volup...\"" +
                   Environment.NewLine +
                   "  But was:  \"...nt ut labore et dolore magna aaliquyam erat, sed diam volu...\"" +
                   Environment.NewLine +
                   "  --------------------------------------------^";

        }
    }
}
