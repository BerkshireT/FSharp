module Misc

let run() =
    // ** Lazy evaluation
    let x = 100
    let result = lazy ((1 / 0) + 10)
 //   printfn "%A" (result)

    // ** Sequences
    let seq1 = seq { for x in 1 .. 1000 do yield x * x }
    let seq2 = seq { for x in 1 .. 1000 -> x * x }              // equivalent
//    printfn "%A" seq1
//    printfn "%A" seq2

    // ** Closures
    let simpleClosure = 
        let scope = "old scope" 
        let enclose() = 
            sprintf "%s" scope 
        let scope = "new scope" 
        sprintf "%s ---  %s" scope (enclose())
//    printfn "%A" simpleClosure

    // ** Tail Recursion
    let rec fact x =
        if x <= 1 then
            1
        else
            x * fact (x - 1)

    let factTail x =
        let rec factTailHelp x acc =
            if x <= 1 then acc
            else factTailHelp (x - 1) (acc * x)
        factTailHelp x 1
//    printfn "%A" (factTail 5)

    printfn "*** End of Misc demo **"
