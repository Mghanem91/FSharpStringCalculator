// Learn more about F# at http://fsharp.org

open System
open StringCalculator

let calc = new MyCalculator()

[<EntryPoint>]
let main argv =
    //let cc = calc.Add "1\n1,-1,-2,-3,-4"
    printfn "Hello from calculator main method."
    0 // return an integer exit code
