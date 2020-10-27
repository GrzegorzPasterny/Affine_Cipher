// Learn more about F# at http://fsharp.org

open System

let Affine_Cipher =
    
    let a = 7
    let b = 5
    let aMinus1 = 15

    let text = 
        Console.WriteLine("Type text to process:")
        Console.ReadLine().Replace(" ","").ToLower()

    let dir = 
        Console.WriteLine("To encrypt type '1', to decyrpt type '0', otherwise quit:")
        Console.ReadLine()

    let run = 
        
        let textToInt = 
            text.ToCharArray()
            |> List.ofArray
            |> List.map(fun i -> int i)
            |> List.map(fun i -> i - 97)
    
        let toStringAgain text = 
            text 
            |> List.map(fun i -> i + 97)
            |> List.map (fun i -> char i)
            |> String.Concat

        let encrypt text =
            
            let calculate singleLetter =
                (a * singleLetter + b) % 26
            
            text
            |> List.map(fun i -> calculate i)
            
        let decrypt text = 
            
            let calculate singleLetter =
                (aMinus1 * (singleLetter - b)) % 26
            
            text
            |> List.map(fun i -> calculate i)

        match dir with
        | "1" -> 
            encrypt textToInt
            |> toStringAgain

        | "0" -> 
            decrypt textToInt
            |> toStringAgain

        | _ -> 
            "invalid choose between encrypion and decryption"

    run


[<EntryPoint>]
let main argv =
    Console.WriteLine(Affine_Cipher)
    0
