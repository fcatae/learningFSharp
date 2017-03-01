
[<Measure>]
type kg

let peso = 100<kg>

let p2 = peso*peso


let (|UpperCase|) (x:string) = x.ToUpper()

let a (t:string) = t.ToUpper()

let result = match "foo" with       
             | UpperCase "FOO" -> true
             | _ -> false

             
{ 
    streaming -> lines
    read in loop
    streaming -> Data
}

for..Array
{
    read generic block
    parser rules
    multiplex parser
}
