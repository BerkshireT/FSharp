module Concurrency

(* agents
let printerAgent = MailboxProcessor.Start(fun inbox-> 
   let rec messageLoop() = async {
      let! msg = inbox.Receive()                        // Read a message
      printfn "Message is: %s" msg
      return! messageLoop()                             // Infinite loop
      }
   messageLoop() 
   )
printerAgent.Post "CPS"
printerAgent.Post "452"


*)