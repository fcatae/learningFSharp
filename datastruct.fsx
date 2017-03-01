
// quanto mais eu sei, menos eu sei!
// https://en.wikibooks.org/wiki/F_Sharp_Programming/Advanced_Data_Structures

type Stack<'a> =
    | EmptyStack
    | StackNode of 'a * Stack<'a>

let b = StackNode(1, StackNode(2, EmptyStack))

// push

let push elem stack =
    StackNode(elem, stack)

let c = b |> push 0

// pop

let pop = function 
    | EmptyStack -> failwith "empty stack"
    | StackNode(el, lst) -> el

printfn "%A" (pop c)

// pop is not immutable

let head = function 
    | EmptyStack -> failwith "empty stack"
    | StackNode(el, lst) -> el

let tl = function 
    | EmptyStack -> failwith "empty stack"
    | StackNode(el, lst) -> lst


// two stacks
let queue = ([],[])

type 'a Queue =
    | QueueList of list<'a>*list<'a>
   

let enqueue el = function 
    | (f,r)  -> (f, el::r) 

([0],[1])
|> enqueue 2

let rec queue_head = function
    | ([], r)  -> queue_head ( r |> List.rev ,[])
    | (e::f,r) -> e

let rec queue_list = function
    | ([], r)  -> queue_head ( r |> List.rev ,[])
    | (e::f,r) -> e

([0],[1]) |> enqueue 2 |> queue_head
([],[1]) |> enqueue 2 |> queue_head

let dequeue = 1

// reimplement tree

type 'a ITree =
    | EmptyNode
    | TreeNode of 'a * 'a ITree * 'a ITree

let tree = TreeNode(5, TreeNode(2, EmptyNode, EmptyNode), TreeNode(7, EmptyNode, EmptyNode))

let rec tree_insert el = function
    | EmptyNode       -> TreeNode(el, EmptyNode, EmptyNode)
    | TreeNode(v,l,r) -> 
            if( el > v ) then
                TreeNode(v, l, tree_insert el r)
            else
                TreeNode(v, tree_insert el l, r)

let rec tree_read (m:'a) best node =
    match node with
    | EmptyNode -> best
    | TreeNode(v, l, r) -> 
            if (v>m) then 
                tree_read m v l
            else   
                tree_read m best r


let rec tree_read2 (m:'a) best node =
    match node with
    | EmptyNode -> 0
    | TreeNode  -> 1

tree_read 7 -1 tree