
insert_row

search_row



type Table = {
    mutable data : list<int>
}    

let table = {
      data = []  
}

//let mutable table : list<int> = []

let insert table row =
    table.data <- row :: table.data

let select (table : Table) =
    table.data

insert table 6

select table

// sort

let nums = [5;4;7;2;3]

// Get the minimum value
let rec min m = function
    | []        -> m
    | e1 :: ls  -> let n = if (m > e1) then e1 else m 
                   min n ls

// min 100 [9;5;8;2;10]

// Get the minimum value and bring to the front
let rec min2 m acc1 = function
    | []        -> m :: acc1 
    | e :: ls  -> if ( e < m ) then
                       min2 (e) (m :: acc1) ls
                   else
                       min2 (m) (e :: acc1) ls

// min2 100 [] [9;5;8;2;10]

let min3 = function
    | [] -> []
    | [e] -> [e]
    | e::lst -> min2 e [] lst

// min3 [9;5;8;2;10]
// min3 [10;9]

// Repeat the process
let rec sort acc = function
    | []  -> acc
    | lst -> let m :: pre = (min3 lst)
             sort (m :: acc) pre

let sort2 = function
    | lst -> lst
            |> sort [] 
            |> List.rev

sort2 [9;5;8;2;10]

// sort []  [9;5;8;2;10]
// sort [] []
// sort [] [1]
//   min2 1000 [] [1]

[9;5;8;2;10] 
|> sort2


let split lst = 
    List.splitInto 2 lst


type Node = {
    node: int
    mutable left: Node
    mutable right: Node
}

let rec NodeNull = {
    node = -1;
    left = NodeNull;
    right = NodeNull;
}

let rec create_node  = function
    | []        -> failwith "invalid tree" // NodeNull
    | [e]       -> { node = e ; left = NodeNull ; right = NodeNull }
    | e1 :: [e2]  -> { node = e2; left = (create_node [e1]); right = (create_node [e2])}
    | e1 :: e2 :: [e3] -> { node = e2; left = (create_node [e1]); right = (create_node [e2;e3])}
    | lst ->    let l = lst 
                        |> sort2
                        |> split                
                let [l1; e2:: l3] = l
                { node = e2; left = (create_node l1); right = (create_node l3)}
                
let tree = create_node [10;20;30;40;50;60;70;80]

tree

let rec find_first (tree:Node) stackTree = 
    printfn "dbg: %d ->(%d, %d)" tree.node tree.left.node tree.right.node
    match (tree.node, tree.left, stackTree) with
    | (-1, _, f::l ) -> (f, l)
    | (e,root, _) -> find_first (root) ( tree :: stackTree )


let find_first_tree tree = 
    let (f,s) = find_first tree []
    (f.node,f,s)

   
let print_tree (n,f,s) =
    printfn "CURRENT VALUE=%d=============================" n
    (n,f,s)

find_first_tree tree
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> ignore


let rec find_next (n, (current:Node), stackTree) =
    printfn "dbg: %d ->(%d, %d) search min=%d" current.node current.left.node current.right.node n
    match ( stackTree ) with
    | _ when (current.left.node > n)  -> find_next (n ,(current.left), (current::stackTree)) // push left
    | _ when (current.node > n )      -> (current.node, current, stackTree)              // current node
    | _ when (current.right.node > n) -> find_next (n, (current.right), (current::stackTree)) // push right
    | par :: stackLeft -> find_next (n, par, stackLeft)
    | _ -> (-1,current,stackTree) // failwith "not found subtree2"

let (n,f,p::p2::s)=
    find_first_tree tree
    |> print_tree
    |> find_next

find_next (n,p,s)



let rec generator = seq {
    yield 1
    yield! generator
}



let rec generator (f,n,s) = 
    seq {   
        if (f>=0) then
            yield f
            let next = find_next (f,n,s)
            yield! generator next        
    }


let generator2 tree =
    let (f,n,s) = find_first_tree tree
    generator (f,n,s)

let all = generator2 tree

for a in all do
    printfn " val=%d" a

printf "%d, "


find_first_tree tree
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> find_next
|> print_tree
|> ignore