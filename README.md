# Json Web Token Tutorial

https://jwt.io/introduction/
https://self-issued.info/docs/draft-ietf-oauth-json-web-token.html#rfc.section.4.1.4
https://blog.codecasts.com.br/mitos-erros-e-verdades-sobre-o-jwt-2804b0bcb29b
https://samueleresca.net/2016/12/developing-token-authentication-using-asp-net-core/

No ASP.NET Core podemos usar o JWT para geração de token, porém do 1.1 para o 2.0 mudou algumas coisinhas e meu objetivo aqui é mostrar como você pode oferecer token para que seu cliente possa ter acesso ao sistema.

“JSON Web Tokens are an open, industry standard RFC 7519 method for representing claims securely between two parties.”. Eu retirei isso do site jwt.io, mas basicamente significa que é um formato de token representando declarações entre duas partes, normalmente uma API e um Client.

Se você acessar o site vai ver que se fala que seguramente o token pode ser transmitido entre partes como um objeto JSON. Mas a verdade é que isso somente acontece por que o token é assinado usando uma “secret” com o algorítimo HMAC (Mas ai é outro tema).

Mas de forma resumida como isso funciona. Bom, uma API não é um sistema normal onde acesso, faço o login e continuo autenticado por causa de cookies, certo? 

Quando vou utilizar uma API, eu nunca estou autenticado. Com isso, normalmente eu preciso de um token, onde esse token tem uma validade, é após isso, qualquer requisição feita na API é necessário enviar junto esse token adquirido. Em resumo é isso.

Para demonstrar isso eu estou utilizando um projeto simples, dotnet new webapi e o postman.

Gerando o Token

Conforme eu expliquei mais acima, a primeira coisa que precisamos é gerar um token para o cliente que deseja acessar a API, para isso eu vou criar uma controller chamada “TokenController”, o código abaixo é um exemplo.

==/token controller

Nessa controller somente temos uma action que usa o verbo POST. No inicio é bem simples, se não tiver meu nome e sobrenome eu mando um não autorizado.

A coisa fica legal depois. Eu criei um builder para gerar meu token (eu vi o código do Tahir Naushad e achei legal dessa forma) e no fim passo esse token para o cliente. 

Abaixo eu mostro a parte mais importante do build, quando eu estou gerando o token.

==/builder build()

A primeira coisa que faço é listar os claims. Se você ainda não sabe direito o que é existe um artigo meu que fala sobre isso aqui. Mas dois claims são importante destacar, “sub” e “jti”:
