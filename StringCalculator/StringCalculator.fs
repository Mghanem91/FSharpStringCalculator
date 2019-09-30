module StringCalculator
open System

type MyCalculator() =

   let  CheckNegative (numbers : int[]) =
     let negativeValues = (numbers |> Array.filter((>) 0)) |> Array.map string
     if negativeValues.Length > 0
     then failwith ("negative numbers is not allowed "+ (negativeValues |> String.concat ", "))
     numbers

   let  ExecludeGreaterThanThousand (numbers : int[]) =
     numbers |> Array.filter (fun x -> x <= 1000)

   member x.Add(input) =
    match input with
    | null -> nullArg "input cannot be null"
    | "" -> 0
    | allowMultipleDelimiters when input.StartsWith("//[") ->
     let mutable listOfDelms = []
     let mutable inputToProcess = input

     while inputToProcess.IndexOf("[") > -1  do
      let startIndex = inputToProcess.IndexOf("[")
      let endIndex = inputToProcess.IndexOf("]")
      listOfDelms <- inputToProcess.Substring(startIndex + 1,(endIndex - startIndex) - 1) :: listOfDelms
      inputToProcess <- inputToProcess.Replace("["+inputToProcess.Substring(startIndex + 1,(endIndex - startIndex) - 1)+"]","") 

     let splittedByLine = inputToProcess.Replace("//","").Split("\n")
     splittedByLine.GetValue(1).ToString()
      .Split((listOfDelms|> List.toArray),StringSplitOptions.None)
      |> Array.map int
      |> CheckNegative
      |> ExecludeGreaterThanThousand
      |> Array.sum

    | supportdifferentdelimiters when input.StartsWith("//") ->
      let splittedByLine = input.Replace("//","").Split("\n")
      splittedByLine.GetValue(1).ToString()
       .Split(splittedByLine.GetValue(0).ToString())
       |> Array.map int
       |> CheckNegative
       |> ExecludeGreaterThanThousand
       |>  Array.sum

    | defaultCase -> input.Split([| ",";"\n" |],StringSplitOptions.None) |> Array.map int |> CheckNegative |> ExecludeGreaterThanThousand |> Array.sum    
