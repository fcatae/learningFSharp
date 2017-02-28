
Tudo no F# é uma função que recebe um único parâmetro.




Na prática, uma função pode receber vários parâmetros:

    let multiply a b = (a * b)

    multiply 5 5

    val it : int = 25

Podemos entender que a função multiply é equivalente a duas funções compostas:

    let quintuplicar = multiply 5

    quintuplicar 5

    val it : int = 25

Isso significa que a função recebeu um único parâmetro 5:

    (multiply 5) 5

Isso permite falar sobre a tipagem de função. No caso, trabalhamos com uma função
do tipo `int -> int -> int` - leia: recebe um inteiro, recebe outro inteiro e
retorna um inteiro.


Que tal tentar:

    multiply 5, 5

Isso talvez não funcione da forma esperada, pois é interpretado como:

    (   (multiply 5), 5   )

QUe pode ser visto como uma tupla (função, inteiro):

    (quintuplicar, 5)


Confuso?

Isso significa que a função é completamente diferente:

    let multiplica (a,b) = (a*b)

Veja a complexidade!!! 

A função multiplica é do tipo (int*int) -> int. Isso significa que ela recebe uma
tuple de inteiros e depois retorna um inteiro. 

Essa função falha se chamada da seguinte forma:

    multiplica 5 5