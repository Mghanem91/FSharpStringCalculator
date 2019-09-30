module Tests

open Xunit
open StringCalculator
 
let calc = new MyCalculator()

[<Fact>]
let NullInputShouldFailWithExceptionMessage() = 
 Assert.Equal(0,(calc.Add null))
    
[<Fact>]
let EmptyStringMustReturnZero() = 
 Assert.Equal(0,(calc.Add ""))

[<Fact>]
let OneNumberShouldReturnTheSameNumberValue() = 
 Assert.Equal(1,(calc.Add "1"))
     
[<Fact>]
let OneNegativeNumberShouldBeRejected() = 
 Assert.Equal(-1,(calc.Add "-1"))

[<Fact>]
let OnePlusOneEqualTwo() = 
 Assert.Equal(2,(calc.Add "1,1"))

[<Fact>]
let UnknownAmountOfNumbersShouldBeCalculated() = 
 Assert.Equal(10,(calc.Add "1,1,2,3,3"))

[<Fact>]
let SeperatedByNewLineDelimiter () = 
 Assert.Equal(2,(calc.Add "1\n1"))

[<Fact>]
let SeperatedByNewLineAndCommaDelimiter () = 
 Assert.Equal(4,(calc.Add "1\n1,2"))

[<Fact>]
let NegativeValuesMustFailAndExceptionMessageMustMentionTheNegativeNumbers() = 
 Assert.Equal(-5,(calc.Add "1\n5,-8,-3"))
     
[<Fact>]
let DifferentDelimitersShouldBeSupported() = 
 Assert.Equal(3,(calc.Add "//;\n1;2"))


[<Fact>]
let AnyNumberGreaterThan1000WillBeIgnored() = 
 Assert.Equal(1,(calc.Add "1001\n1"))
  
[<Fact>]
let MultipleDifferentOneCharacterDelimiters () = 
 Assert.Equal(23,(calc.Add "//[*][-][$]\n2*3-8$10"))
  
[<Fact>]
let MultipleDifferentAnyLenghtDelimiters () = 
 Assert.Equal(23,(calc.Add "//[***][---][$]\n2***3---8$10"))

[<Fact>]
let MultipleDifferentDelimitersBesideNumbersGreaterThan1000 () = 
 Assert.Equal(14,(calc.Add "//[***][---]\n1***2***3---8---1008"))



