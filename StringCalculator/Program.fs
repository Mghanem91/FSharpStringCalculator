// Learn more about F# at http://fsharp.org

open System
open StringCalculator

let calc = new MyCalculator()

[<EntryPoint>]
let main argv =
    let cc = calc.Add "//[***][---]\n1***2***3---8"

    printfn "Hello from calculator main method."
    0 // return an integer exit code
