module Concurrency
open System.Threading // only needed for cancellation tokens

let run() = 
    // ** Async workflows
    let asyncTimer x =
        let timer = new System.Timers.Timer(x)
        let timerEvent = Async.AwaitEvent (timer.Elapsed) |> Async.Ignore
        timer.Start()

        // Do other work
        for x in [1..2..10] do printfn "Simulate work"
        
        printfn "Waiting for timer to finish..."
        Async.RunSynchronously timerEvent           // blocks i.e. WaitGroup in Go
        printfn "Back in sync!"

//    asyncTimer 5000.0

    let manualAsync x = async {
        printfn "Started async workflow"
        do! Async.Sleep(x)                          // await
        printfn "Finished async work"
    }

    //Async.Start(manualAsync 5000)                  // don't wait for result
   // Async.RunSynchronously (manualAsync 5000)

    let cancellationSource = new CancellationTokenSource()      // it's possible to cancel async tasks
   // Async.Start(manualAsync 5000, cancellationSource.Token)     // useful for cancel buttons, errors
   // Thread.Sleep(2500)
  //  cancellationSource.Cancel()
 //   printfn "Cancelled async task"

    // ** Actor model
    let mutable messages = []
    let printerAgent = MailboxProcessor.Start(fun inbox -> 
       let rec messageLoop() = async {
          let! msg = inbox.Receive()                        // Read a message
          printfn "Agent 1 got message: %s" msg
          messages <- [msg] |> List.append messages
          return! messageLoop()                             // Infinite loop
          }
       messageLoop() 
       )

    let printerAgent2 = MailboxProcessor.Start(fun inbox -> 
       let rec messageLoop() = async {
          let! msg = inbox.Receive()
          printfn "Agent 2 got message: %s" msg
          messages <- [msg] |> List.append messages
          return! messageLoop()
          }
       messageLoop() 
       )

//    printerAgent.Post "CPS"
//    printerAgent.Post "452"
//    printerAgent.Post "is"
//    printerAgent.Post "cool"

//    printerAgent.Post "CPS"
//    printerAgent2.Post "452"
//    printerAgent.Post "is"
//    printerAgent2.Post "cool"
    Thread.Sleep(2000)
    printfn "%A" messages

    printfn "*** End of Concurrency demo ***"
