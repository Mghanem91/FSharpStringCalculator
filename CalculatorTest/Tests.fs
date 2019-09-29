module Tests

open Xunit
open StringCalculator
 
let calc = new MyCalculator()

[<Fact>]
let EmptyStringMustReturnZero() = 
    Assert.Equal(0,(calc.Add ""))

[<Fact>]
let OneNumberShouldReturnTheNumberValue() = 
     Assert.Equal(2,(calc.Add "2"))

[<Fact>]
let OnePlusOneEqualTwo() = 
     Assert.Equal(2,(calc.Add "1,1"))

[<Fact>]
let UnknownAmountOfNumbersShouldBeCalculated() = 
     Assert.Equal(10,(calc.Add "1,1,2,3,3"))

[<Fact>]
let OnePlusOneEqualTwo_NumbersSeperatedByNewLine() = 
     Assert.Equal(2,(calc.Add "1\n1"))

[<Fact>]
let NegativeValuesMustFailAndExceptionMustContainsTheNumbers() = 
     Assert.Equal(2,(calc.Add "1\n-5,-8"))


