let l = [10;15;20;80;74;12;01;95;68;42;87;65;12]

// split the list
let split (lst:list<int>) = 
    lst |> List.splitInto 2

// process one part
let proc idx proc (lst:list<list<int>>) = 
    match idx with
    | 0 -> [(proc lst.[0]); lst.[1]]
    | 1 -> [ lst.[0]; (proc lst.[1])]
    | _ -> failwith "only 2 dimensions"

// use show for testing
let show = function
        | a1 :: a2 :: lst -> printfn "%d %d .." a1 a2; lst
        | a1 :: lst -> printfn "%d" a1; lst
        | _ -> [0]

// use order for testing       
let magic_order = function
    | 10 :: lista -> [1; 10; 12; 15; 20; 80; 1000; 2000; 3000]
    | 95 :: lista -> [12; 42; 65; 68; 87; 95; 1000; 2000; 3000]
    | _ -> failwith "wrong value?"

// merge (rec)
let rec merge_it (lst1, lst2) (acc:list<int>) = 
    match (lst1, lst2) with
    | ([], [])  -> acc // done
    | ( [], el :: lst) -> merge_it ([], lst) (el :: acc)
    | ( el :: lst, []) -> merge_it (lst, []) (el :: acc)

    | ( e1 :: ls1, e2 :: ls2 ) -> if (e1 > e2) then 
                                        merge_it (ls1 , e2 :: ls2) ( e1 :: acc )
                                  else
                                        merge_it ( e1 :: ls1, ls2) ( e2 :: acc)

// merge
let merge = function    
    | [lst1; lst2] -> merge_it (lst1, lst2) []
                      |> List.rev
    
    | _ -> failwith "wrong value?"

// order
let rec order = function 
    | []   -> []
    | [el] -> [el]
    | lst  -> lst 
                |> split
                |> proc 0 order
                |> proc 1 order
                |> merge

// [4;5;7;9;81;2] |> order

// solution

l |> order
