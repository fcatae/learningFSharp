
open System
open System.Text.RegularExpressions

"123456" |> Seq.take 2 |> String.Concat

// Regular expressions

open System.Text.RegularExpressions

// warning: new is redundant
let re = new Regex("[a-zA-Z]+")

let m = re.Match ("0101abc111")

m.Captures.[0].Value


let findString str = 
    let re = new Regex("[a-zA-Z]+")
    let m = re.Match str
    m.Captures.[0].Value

findString "0101abc111"


// Diferente forma de sintaxe (mais elegante do que)
let re = new Regex("[a-zA-Z]+")
let findString str = 
    (re.Match str).Captures.[0].Value


// F# way - queria escrever algo assim, na horizontal

("0101abc111" |> re.Match ).Captures.[0].Value

// Entao
let re = new Regex("[a-zA-Z]+")
let getResult (group:Match) = group.Captures.[0].Value

"0101abc111" |> re.Match |> getResult

// Tudo pode se transformar em funcao:

let stringMatch = Regex("[a-zA-Z]+").Match
let getResult = function 
    | (group:Match) -> group.Captures.[0].Value

"0101abc111" |> stringMatch |> getResult


let findString = stringMatch >> getResult

"0101abc111" |> findString



let NumbersToken = Regex("[a-zA-Z]").Match

"abc123def"
|> NumbersToken



