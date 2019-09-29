module StringCalculator

open System


type MyCalculator() =

  member x.Add(expression) =
  
    match expression with
    | null -> nullArg "expression"
    | "" -> 0
    | _ -> 
     expression.Split([| ",";"\n" |],StringSplitOptions.None) |> Array.map int |> Array.sum
 
      

    
