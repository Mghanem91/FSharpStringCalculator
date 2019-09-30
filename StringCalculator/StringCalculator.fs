module StringCalculator

open System


type MyCalculator() =

   let  CheckNegative (numbers : int[]) =
     let negativeValues = (numbers |> Array.filter((>) 0)) |> Array.map string
     if negativeValues.Length > 0 then failwith ("negative numbers is not allowed "+ (negativeValues |> String.concat ", "))
     numbers
     
   member x.Add(input) =
  
    match input with

    | null -> nullArg "input cannot be null"

    | "" -> 0

    | _ when input.StartsWith("//") ->
      let splittedByLine = input.Replace("//","").Split("\n")
      splittedByLine.GetValue(1).ToString().Split(splittedByLine.GetValue(0).ToString()) |> Array.map int |> CheckNegative |>  Array.sum
    
    | _ -> input.Split([| ",";"\n" |],StringSplitOptions.None) |> Array.map int |> CheckNegative |> Array.sum    
