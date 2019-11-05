module Piping_etc

(* Piping etc
let main() =
    let list = [1 .. 10 ] |> Seq.filter (fun x -> x % 2 <> 0)
                          |> Seq.map (fun x -> x * x)
                          |> Seq.sum
    printfn "%A" list

    let composed = Seq.filter (fun x -> x % 2 <> 0)
                   >> Seq.map (fun x -> x * x)
                   >> Seq.sum
    printfn "%A" (composed [1 .. 10])
    //printfn "%A" <| composed [1 .. 10]

    let printTwo a b = printfn "%A and %A" a b
    printTwo "CPS" 452

    let printTwoCurried a =
        let printTwoSecond b =
            printfn "%A and %A" a b
        printTwoSecond
    printTwoCurried "CPS" 452

    let filterEvens = List.filter (fun x -> x % 2 = 0)
    printfn "%A" <| filterEvens [ 1 .. 5 ] 

    let replace oldStr newStr (s:String) = s.Replace(oldValue = oldStr, newValue = newStr)   // Input string is now the last parameter
    let result =
        "CPS"
        |> replace "CPS" "452"
    printfn "%A" result
    
main()
*)