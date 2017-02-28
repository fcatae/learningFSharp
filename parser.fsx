
let multiply a b = a*b

let a = (5, 2)

let multiply a:int*int = 
    let (a1, a2) = a
    multiply a1 a2


let multiply = function
    | (a1,a2) -> (a1*a2)
    | a1 a2 -> a1 * a2

multiply (5,5)


multiply 5 2

multiply (5, 2)


"1,2,3,4,5"

let mutable str: list<string> = []

open System.Text.RegularExpressions


let getMatchFromString = Regex("[a-zA-Z]+").Match
let getValueFromMatch (m: Match) = m.Captures.[0].Value

let getString = getMatchFromString >> getValueFromMatch


getString "abc def"

let rec reader (line: string) pos =
    match line.[pos] with
    | 'Z' -> str
    | ' ' -> reader line (pos+1)     //| _ when line.Length = (pos-1) -> line.Substring pos
    | ch ->         
        str <- (getString line) :: str
        reader line (pos+1) 

str <- []
reader " abc d Z\n" 0


Framework de teste

abrir arquivo
deserializar objeto

executar a função

comparar os objetos


parse file -> produce a sequence



let rec contador acc = function
    | 0 -> 10+acc
    | n -> contador (n-1) (acc+1)

essa funcao nao existe no C# por causa do Tail Call optimization (!!!)


contador 200000 0



let mutant found = -1
let rec tryParse (buffer: string) (position: int) =

    if buffer.Length >= position then ()

    match (buffer.[position], 
    | '\t'
    | ' ' -> tryParse buffer (position+1) 
    | '\n'
    | 'Z' -> 

let funcCall = function
    | msg -> printf "aaaaaaaaaaaaaaaaaaaa: %s" msg
    
funcCall ()

funcCall  "hell"

let rec tryParseStart (buffer: string) (position: int)  = 
    if buffer.Length <= position then (buffer, position)
    else
    match buffer.[position] with
        | '\t' 
        | ' ' -> tryParseStart buffer (position+1) 
        | _   -> (buffer,position)


let rec tryParseEnd (buffer: string) (position: int)  = 
    if buffer.Length <= position then (buffer, position)
    else
    match buffer.[position] with
        | '\t' 
        | ' ' ->    let msg = funcCall "a"
                    (buffer,position+1)

        | _   -> tryParseEnd buffer (position+1) 


tryParseStart "  abc  " 0
tryParseStart "  " 0



let func (buffer: string) (position: int) =  
    match buffer.[position] with
        | '1' -> 2
        | '2' -> 4
        | _ -> 0


let rec contador n = 
    match n with 
        | 0 -> 0
        | 1 -> 2 
        | _ -> 2 + contador (n-1)
    
contador 5

open System
sprintf "%c%c%c" 'a' 'b' 'd' 



readNum "123,456,789E" 0

let readNum0 str = readNum str 0




let readNum (str:string) (pos:int) = 
    let rec listaNumerosSequenciais (str:string) pos = seq { 
        match str.[pos] with        
        | ',' -> ()
        | _   -> 
                yield str.[pos] 
                yield! listaNumerosSequenciais str (pos+1)
        }
    
    listaNumerosSequenciais str pos
    |> System.String.Concat

let rec reader (str:string) (pos:int) (res:list<string>) = 
    match str.[pos] with
    | '1' | '2' | '3' 
    | '4' | '5' | '6' 
    | '7' | '8' | '9' 
    | '0' -> reader str (pos+3) ((readNum str pos)::res)
    | ',' -> reader str (pos+1) res
    | 'E' -> res // returnar o valor encontrado
    | _ -> failwith "nao deveria cair aqui"


reader "012,111,987E" 0 []


    | '1' | '2' | '3' | '4' | '5' 
    | '6' | '7' | '8' | '9' | '0' -> ler_o_numero


"123456"
|> Seq.filter (fun n -> n < '4')
|> System.String.Concat



parser:

OpenFile
|> splitLines
|> createDataBlock
|> switchBlockType function
    | t1 -> blabla
    | t2 -> blabla
    | t3 -> blablabla

|> analyzeWithExperts [ 
        A; 
        B; 
        C
    ]
