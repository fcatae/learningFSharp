
let name = "fabrIcio"
name = "fabricio"

// returns false

let ToUpper (str:string) = str.ToUpper()

(ToUpper name) = "FABRICIO"
// true

let (|MatchUpper|) (str:string) = str.ToUpper()

match "AA" with
    | "aa" -> "upper"
    | _ -> "other"



