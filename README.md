<h1>Apresentação do Repositório - Gerenciamento de Produtos e Categorias</h1>
Bem-vindo ao Repositório de Gerenciamento de Produtos e Categorias! Aqui, você encontrará uma poderosa API que simplifica o cadastro, edição e exclusão de produtos, além de permitir a associação desses produtos a categorias específicas. Este projeto foi desenvolvido para facilitar o gerenciamento eficiente de inventários de produtos.

Objetivo
O objetivo principal deste repositório é fornecer uma solução robusta e flexível para o gerenciamento de produtos, permitindo que desenvolvedores integrem facilmente esses recursos em seus sistemas. Com uma API intuitiva, este projeto se destaca pela sua capacidade de escalabilidade e facilidade de uso.

Funcionalidades Principais
1. Cadastro de Produtos
Utilize o endpoint POST /api/produtos para cadastrar novos produtos. Especifique o nome, preço e a categoria associada ao produto.

2. Edição de Produtos
Atualize as informações de qualquer produto utilizando o endpoint PUT /api/produtos/:id. A flexibilidade desta funcionalidade permite a adaptação rápida a mudanças nos dados do produto.

3. Exclusão de Produtos
Remova produtos do sistema de maneira simples e eficaz usando o endpoint DELETE /api/produtos/:id.

4. Associação a Categorias
Categorize seus produtos com o endpoint POST /api/categorias. Associando produtos a categorias específicas, você organiza seu inventário de maneira lógica e eficiente.

5. Consulta de Produtos por Categoria
Recupere todos os produtos associados a uma categoria utilizando o endpoint GET /api/categorias/:id/produtos.

Como Começar
Configuração Inicial:

Clone o repositório.
Instale as dependências utilizando o npm.
Configure as variáveis de ambiente.
Documentação Detalhada:

Explore a documentação incluída no código-fonte para obter informações detalhadas sobre os endpoints, parâmetros e respostas.
Exemplos de Uso:

Consulte os exemplos fornecidos para entender como interagir com a API utilizando cURL ou outras ferramentas.
