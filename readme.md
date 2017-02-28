
Programando em F#
===================

# Cenários

Fibonacci
Strings
Parser

# Do mundo C# para F#

Quem está acostumado com a programação C#, não vai estranhar (muito) o F#. 
As bibliotecas seguem o padrão e podem ser utilizadas com o `open`:

    open System

Dizem que a linguagem funcional é completamente diferente do que estamos acostumados.
Isso porque as construções ficam diferentes. Por exemplo, veja esse comando em F#:

    "123456" |> Seq.take 3 |> String.Concat

Hoje resolvi fazer uma brincadeira em F# como primeira experiência. Queria construir
um parser, então nada mais razoável de incluir a biblioteca de Regular Expression:

    open System.Text.RegularExpressions

Em seguida, escrevi uma rotina `findString` simples:

    open System.Text.RegularExpressions

    let findString str = 
        let re = new Regex("[a-zA-Z]+")
        let m = re.Match(str)
        m.Captures.[0].Value

    findString "0101abc111"

Ambiente: 

    Para rodar o programa, estou usando o F# Interactive (FSI). Eu coloquei o Visual Studio Code
    com a extensão `Ionide-fsharp`. Criei um arquivo com extensão `.fsx` e rodo os comandos
    usando o atalho `Alt-Enter`. 

Explicação passo a passo:

Referência ao namespace (igual ao `using` do C#)

    open System.Text.RegularExpressions

Em seguida, faço a criação do objeto de Regular Expression. Note que o compilador gera um warning
sobre a redundância do keyword `new`.

    // warning: new is redundant
    let re = new Regex("[a-zA-Z]+")

Em seguida, executamos o método `Match`. Note que os parênteses são opcionais.

    let m = re.Match(str)

Por fim, retornamos o valor.

    m.Captures.[0].Value

Escrevemos, assim, um código F# usando a estruturação tradicional. Observando o layout do código, 
parece mais um código C# do que F#.


# Escrevendo com mais elegância

Tudo no F# é função.

Assim, começo separando o código em diferentes funções:

    let re = new Regex("[a-zA-Z]+")
    let findString str = 
        (re.Match str).Captures.[0].Value

Agora tenho uma função (objecto) `re` e outra `findString`. 
Posso escrever no estilo horizontal do F# algo assim:

    ("0101abc111" |> re.Match ).Captures.[0].Value

Retorna:

    "abc"

Poderia definir as funções chamadas `stringMatch` e `getResult`. 

    let stringMatch = Regex("[a-zA-Z]+").Match
    let getResult (group:Match) = group.Captures.[0].Value

Agora tenho a seguinte construção:

    "0101abc111" |> stringMatch |> getResult

Por fim, por que não criar uma composição de função:

    let findString = stringMatch >> getResult

Finalmente, posso fazer executar meu programa:
    "0101abc111" |> findString
