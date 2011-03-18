using System;

namespace Machine.Specifications.Specs
{
    public class when_comparing_two_different_strings
    {
        static Exception Exception;
        static string Foo;
        static string Bar;

        Establish context = () =>
        {
            Foo = "foo";
            Bar = "bar";
        };

        Because of = () => Exception = Catch.Exception(() => Foo.ShouldEqual(Bar));

        It should_be_a_specification_exception = () => Exception.ShouldBeOfType<SpecificationException>();
    }
}