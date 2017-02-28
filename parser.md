



Reader:

let rec reader line pos res =
    match line[pos] with
    | ' ' -> reader line (pos+1) res
    | _ -> line


    