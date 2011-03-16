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
        static string result =
            "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                      original =
                          "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aaliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                      expectedMessage = "Expected string length 591 but was 592. Strings differ at index 123." +
                                        Environment.NewLine +
                                        "  Expected: \"...nt ut labore et dolore magna aliquyam erat, sed diam volup...\"" +
                                        Environment.NewLine +
                                        "  But was:  \"...nt ut labore et dolore magna aaliquyam erat, sed diam volu...\"" +
                                        Environment.NewLine +
                                        "  --------------------------------------------^",
                      actualMessage;

        Because of = () =>
        {
            actualMessage = NUnitExceptionMessageFormatter.Compare(original, result);
        };

        It should_return_an_NUnit_style_exception_message = () => actualMessage.ShouldEqual(expectedMessage);
    }

    [Subject("NUnit exception message formatter")]
    public class when_I_pass_two_strings_with_different_length
    {
        static string actualMessage2,
                        input2 = "Hallo welt!",
                        input1 = "Hallo",
                        expectedMessage2 = "Expected string length 11 but was 5.";

        Because of2 = () =>
        {
            actualMessage2 = NUnitExceptionMessageFormatter.Compare(input1, input2);
        };

        It should_return_the_length_of_the_expected_and_the_actual_strings =
            () => actualMessage2.ShouldContain(expectedMessage2);
    }

    [Subject("NUnit exception message formatter")]
    public class when_I_pass_two_different_strings_same_length
    {
        static string actualMessage2,
                        input2 = "Hallo welt!",
                        input1 = "Hallo Welt!" ,
                        expectedMessage2 = "Strings differ at index 6.";

        Because of2 = () =>
        {
            actualMessage2 = NUnitExceptionMessageFormatter.Compare(input1, input2);
        };

        It should_return_the_Position_of_the_different_char =
            () => actualMessage2.ShouldContain(expectedMessage2);
    }

    public class NUnitExceptionMessageFormatter
    {
        public static string Compare(string original, string result)
        {
            return string.Format("Expected string length {0} but was {1}. Strings differ at index {2}." + Environment.NewLine +
                   "  Expected: \"...nt ut labore et dolore magna aliquyam erat, sed diam volup...\"" +
                   Environment.NewLine +
                   "  But was:  \"...nt ut labore et dolore magna aaliquyam erat, sed diam volu...\"" +
                   Environment.NewLine +
                   "  --------------------------------------------^", result.Length, original.Length, FirstDifferentChar(original, result));

        }

        private static int FirstDifferentChar(string original, string result)
        {
            for (int i = 0; i < original.Length; i++)
            {
                if (result.Length < i)
                    return i;

                if(result[i] != original[i])
                    return i;
            }
            return 0;
        }

    }
}
